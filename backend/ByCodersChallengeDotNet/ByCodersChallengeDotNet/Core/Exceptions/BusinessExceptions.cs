using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.Core.Exceptions
{
    public class BusinessException(string message) : Exception(message)
    {
    }


    public class NoDataException : BusinessException
    {
        public NoDataException() : base("NO_DATA_TO_IMPORT") { }
    }

    public class InvalidFieldException(FieldType fieldType) : BusinessException($"INVALID_FIELD_{fieldType.ToString().ToUpper()}")
    {
    }
}
