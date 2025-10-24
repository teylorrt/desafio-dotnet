using ByCodersChallengeDotNet.Core.Entities.Operation;
using ByCodersChallengeDotNet.Core.Enums;
using ByCodersChallengeDotNet.Core.Exceptions;
using System.Text.RegularExpressions;

namespace ByCodersChallengeDotNet.UnitTests.Entities.Operation
{
    public abstract class FieldTestsBase<T, T2> where T : OperationField<T2>
    {
        private const string LineBase = "3201903010000012200845152540736777****1313172712MARCOS PEREIRAMERCADO DA AVENIDA";

        public readonly string PlaceHolder;
        public readonly string ValidValue;
        public readonly string LineTest;
        public readonly FieldType _FieldType;
        public readonly T2 ExpectedValidValue;

        public FieldTestsBase(FieldType fieldType, string placeHolder, string validValue, T2 expectedValidValue) 
        {
            PlaceHolder = placeHolder;
            ValidValue = validValue;
            LineTest = Regex.Replace(LineBase, validValue, PlaceHolder);
            _FieldType = fieldType;
            ExpectedValidValue = expectedValidValue;
        }

        public abstract string GetInvalidValue();

        private T? CreateField(ReadOnlySpan<char> value)
        {
            return _FieldType switch
            {
                FieldType.Card => new Card(value) as T,
                FieldType.Cpf => new Cpf(value) as T,
                FieldType.StoreName => new Core.Entities.Operation.StoreName(value) as T,
                FieldType.StoreOwner => new StoreOwner(value) as T,
                FieldType.Time => new Time(value) as T,
                FieldType.Type => new Core.Entities.Operation.Type(value) as T,
                FieldType.Value => new Value(value) as T,
                _ => null,
            };
        }

        [Fact, Trait("Category", "Unit")]
        public virtual void TestInvalidSize()
        {
            var expectedMessage = new InvalidFieldException(_FieldType).Message;
            var caughtException = Assert.Throws<InvalidFieldException>(() => CreateField(ValidValue.AsSpan(0, ValidValue.Length - 1)));

            Assert.Equal(expectedMessage, caughtException.Message);
        }

        [Fact, Trait("Category", "Unit")]
        public void TestValidValue()
        {
            var field = CreateField(LineTest.Replace(PlaceHolder, ValidValue));

            Assert.NotNull(field);
            Assert.Equal(ExpectedValidValue, field.Value);
        }

        [Fact, Trait("Category", "Unit")]
        public void TestInvalidValidValue()
        {
            var expectedMessage = new InvalidFieldException(_FieldType).Message;
            var caughtException = Assert.Throws<InvalidFieldException>(() => CreateField(LineTest.Replace(PlaceHolder, GetInvalidValue())));

            Assert.Equal(expectedMessage, caughtException.Message);
        }
    }
}
