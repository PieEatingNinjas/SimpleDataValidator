using System;

namespace SimpleInputDataValidator.Validators
{
    public class StringNotNullOrEmptyValidator : ValidatorBase<string>
    {
        public StringNotNullOrEmptyValidator(string propertyName, Func<string> propertyValueFunc, string message) 
            : base(propertyName, propertyValueFunc, message)
        { }

        protected override bool Validate(string value)
         => !string.IsNullOrEmpty(value);
    }
}
