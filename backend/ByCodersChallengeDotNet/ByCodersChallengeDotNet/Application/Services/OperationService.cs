using ByCodersChallengeDotNet.Core.Entities.Operation;
using ByCodersChallengeDotNet.Core.Enums;
using ByCodersChallengeDotNet.Core.Exceptions;
using ByCodersChallengeDotNet.Core.Models;
using ByCodersChallengeDotNet.Core.Repositories;
using ByCodersChallengeDotNet.Core.Services;
using System.Buffers;
using System.Text;

namespace ByCodersChallengeDotNet.Application.Services
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;

        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public bool ImportOperations(Stream fileStream)
        {
            var span = GetSpanChar(fileStream);

            var text = span.ToString();

            if (string.IsNullOrEmpty(text))
            {
                throw new NoDataException();
            }

            List<Operation> operations = [];

            var operationsText = text.Split('\n');

            foreach (var operationText in operationsText.Where(o => !string.IsNullOrEmpty(o)))
            {
                ReadOnlySpan<char> slice = operationText.AsSpan();

                var operation = new Operation()
                {
                    Type = new(slice),
                    Time = new(slice),
                    Value = new(slice),
                    Cpf = new(slice),
                    Card = new(slice),
                    StoreOwner = new(slice),
                    StoreName = new(slice),
                };

                operations.Add(operation);
            }

            var saved = _operationRepository.Save(operations);

            return saved;
        }

        public IEnumerable<OperationGroupModel> ListOperationsByStore()
        {
            var operations = _operationRepository.List();

            foreach (var operation in operations)
            {
                if(operation.Sign[0].Equals((char)TransactionSign.Negative))
                {
                    operation.Value *= -1m;
                }
            }

            return operations
                .GroupBy(o => o.StoreName)
                .Select(g => new OperationGroupModel
                {
                    Operations = g,
                    Name = g.Key,
                    AccountBalance = g.Sum(s => s.Value)
                });
        }

        private static ReadOnlySpan<char> GetSpanChar(Stream fileStream)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent((int)fileStream.Length);

            int bytesRead = fileStream.Read(buffer, 0, (int)fileStream.Length);

            ReadOnlySpan<byte> fileContent = new(buffer, 0, bytesRead);

            // Choose the appropriate encoding (e.g., UTF8)
            Encoding encoding = Encoding.UTF8;

            // Determine the maximum number of characters that might be produced
            int maxCharCount = encoding.GetMaxCharCount(fileContent.Length);

            // Create a char array to store the decoded characters
            char[] charBuffer = new char[maxCharCount];

            // Decode the bytes into the char buffer
            int charsWritten = encoding.GetChars(fileContent, charBuffer);

            // Return a ReadOnlySpan<char> from the populated portion of the buffer
            return new ReadOnlySpan<char>(charBuffer, 0, charsWritten);
        }
    }
}
