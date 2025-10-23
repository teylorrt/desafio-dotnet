using ByCodersChallengeDotNet.Core.Exceptions;

namespace ByCodersChallengeDotNet.Core.Entities.Operation
{
    public abstract class OperationField<T> : ValueObject<T, ReadOnlySpan<char>>
    {
        protected readonly Field Field;

        public OperationField(Field field, ReadOnlySpan<char> value) : base(GetSlice(field, value))
        {
            Field = field;

            AssertFieldSize(field, GetSlice(field, value));
        }

        public OperationField(Field field, ReadOnlySpan<char> value, Func<ReadOnlySpan<char>, ReadOnlySpan<char>> getSlice) : base(getSlice.Invoke(value))
        {
            Field = field;

            AssertFieldSize(field, getSlice.Invoke(value));
        }

        protected static ReadOnlySpan<char> GetSlice(Field field, ReadOnlySpan<char> value)
        {
            return value[field.Start..(field.End + 1)];
        }

        public static bool AssertFieldSize(Field field, ReadOnlySpan<char> value)
        {
            if (value.Length != field.Size)
            {
                throw new InvalidFieldException(field.Type);
            }

            return true;
        }

        protected override void SetValue(ReadOnlySpan<char> value)
        {
            SetFieldValue(value);
        }

        protected override bool Validate(ReadOnlySpan<char> value)
        {
            if(!ValidateField(value))
            {
                throw new InvalidFieldException(Field.Type);
            }
            return true;
        }

        protected abstract bool ValidateField(ReadOnlySpan<char> value);
        protected abstract void SetFieldValue(ReadOnlySpan<char> value);
    }
}
