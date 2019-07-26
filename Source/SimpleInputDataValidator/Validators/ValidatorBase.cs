using System;

namespace SimpleInputDataValidator
{
    public class ValidatorBase : IValidator
    {
        private Func<bool> validationFunc;
        public string Message { get; }
        public string PropertyName { get; }

        public ValidatorBase(string propertyName, Func<bool> validationFunc, string message)
        {
            this.PropertyName = propertyName;
            this.validationFunc = validationFunc;
            this.Message = message;
        }

        public bool Validate()
            => validationFunc();
    }

    public abstract class ValidatorBase<T> : IValidator
    {
        private Func<T> propertyValueFunc;
        public string Message { get; }
        public string PropertyName { get; }

        public ValidatorBase(string propertyName, Func<T> propertyValueFunc, string message)
        {
            PropertyName = propertyName;
            Message = message;
            this.propertyValueFunc = propertyValueFunc;
        }

        public bool Validate()
            => Validate(propertyValueFunc());

        protected abstract bool Validate(T value);

    }
}
