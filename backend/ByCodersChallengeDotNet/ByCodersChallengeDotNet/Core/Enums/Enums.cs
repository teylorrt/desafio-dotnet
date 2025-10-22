namespace ByCodersChallengeDotNet.Core.Enums
{
    public enum TransactionNature
    {
        Income,
        Expense,
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
        CPF,
        Card,
        Time,
        StoreOwner,
        StoreName,
    }
}
