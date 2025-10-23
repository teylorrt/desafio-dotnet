using ByCodersChallengeDotNet.Core.Enums;
using ByCodersChallengeDotNet.Core.Exceptions;

namespace ByCodersChallengeDotNet.Core.Entities.Operation
{
    public abstract class OperationField<T> : ValueObject<T, ReadOnlySpan<char>>
    {
        protected readonly Field Field;

        public OperationField(Field field, ReadOnlySpan<char> value) : base(GetSlice(field, value))
        {
            Field = field;
        }

        public OperationField(Field field, ReadOnlySpan<char> value, Func<ReadOnlySpan<char>, ReadOnlySpan<char>> getSlice) : base(getSlice.Invoke(value))
        {
            Field = field;
        }

        public static ReadOnlySpan<char> GetSlice(Field field, ReadOnlySpan<char> value)
        {
            int start = field.Start;
            int end = (field.End + 1);
            
            AssertSliceSize(field.Type, start, end, value);

            return value[start..end];
        }

        public static bool AssertSliceSize(FieldType type, int start, int end, ReadOnlySpan<char> value)
        {
            
            if (start > value.Length - 1 || end > value.Length)
            {
                throw new InvalidFieldException(type);
            }

            return true;
        }

        protected override void SetValue(ReadOnlySpan<char> value)
        {
            SetFieldValue(value);
        }

        public override bool Validate(ReadOnlySpan<char> value)
        {
            if(!ValidateField(value))
            {
                throw new InvalidFieldException(Field.Type);
            }
            return true;
        }

        public abstract bool ValidateField(ReadOnlySpan<char> value);
        protected abstract void SetFieldValue(ReadOnlySpan<char> value);
    }
}
