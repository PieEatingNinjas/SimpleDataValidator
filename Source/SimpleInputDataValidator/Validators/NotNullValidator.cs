using System;

namespace SimpleInputDataValidator.Validators
{
    public class NotNullValidator<T> : ValidatorBase<T>
    {
        public NotNullValidator(string propertyName, Func<T> propertyValueFunc, string message) 
            : base(propertyName, propertyValueFunc, message)
        {
        }

        protected override bool Validate(T value)
            => value != null;
    }
}
