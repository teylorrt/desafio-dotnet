
namespace ByCodersChallengeDotNet.Core.Entities
{
    public abstract class ValueObject<TValue, TInput> where TInput : notnull, allows ref struct
    {
        public TValue? Value { get; protected set; }
        public abstract bool Validate(TInput? value);
        protected abstract void SetValue(TInput? value);

        public ValueObject(TInput? value)
        {
            Validate(value);
            SetValue(value);
        }
    }
}
