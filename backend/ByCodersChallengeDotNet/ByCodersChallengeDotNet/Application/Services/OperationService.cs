using ByCodersChallengeDotNet.Application.Models;
using ByCodersChallengeDotNet.Core.Entities;
using ByCodersChallengeDotNet.Core.Enums;
using ByCodersChallengeDotNet.Core.Exceptions;
using ByCodersChallengeDotNet.Core.Repositories;
using ByCodersChallengeDotNet.Core.Services;

namespace ByCodersChallengeDotNet.Application.Services
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;
        private static readonly List<Field> Fields =
            [
                new Field(FieldType.Type, 0, 0, 1),
                new Field(FieldType.Date, 1, 8, 8),
                new Field(FieldType.Value, 9, 18, 10),
                new Field(FieldType.CPF, 19, 29, 11),
                new Field(FieldType.Card, 30, 41, 12),
                new Field(FieldType.Time, 42, 47, 6),
                new Field(FieldType.StoreOwner, 48, 61, 14),
                new Field(FieldType.StoreName, 62, 80, 19),
            ];

        private const int NumberOfFields = 8;

        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public bool ImportOperations(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new NoDataException();
            }

            List<Operation> operations = [];

            var operationsText = text.Split('\n');

            foreach (var operationText in operationsText.Where(o => !string.IsNullOrEmpty(o)))
            {
                ReadOnlySpan<char> slice = operationText.AsSpan();

                var operation = new Operation();

                foreach (var field in Fields.OrderBy(f => f.Type))
                {
                    var i = 1;

                    if (field.Type is FieldType.StoreName)
                    {
                        i = 0; 
                    }

                    var value = slice[field.Start.. (field.End+i)];
                    operation.SetField(field.Type, value.ToString());
                }

                operations.Add(operation);
            }

            var saved = _operationRepository.Save(operations);

            return saved;
        }

        public IEnumerable<Operation> ListOperations()
        {
            return _operationRepository.List();
        }
    }
}
