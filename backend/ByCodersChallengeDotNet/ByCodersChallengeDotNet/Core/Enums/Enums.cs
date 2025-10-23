namespace ByCodersChallengeDotNet.Core.Enums
{
    public enum TransactionNature
    {
        Income = 'I',
        Expense = 'E',
    }

    public enum TransactionSign
    {
        Positive = '+',
        Negative = '-',
    }

    public enum FieldType
    {
        Type,
        Date,
        Value,
        Cpf,
        Card,
        Time,
        StoreOwner,
        StoreName,
    }
}
