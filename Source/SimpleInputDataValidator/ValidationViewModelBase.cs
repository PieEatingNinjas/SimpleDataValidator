using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SimpleInputDataValidator
{
    public abstract class ValidationViewModelBase : INotifyPropertyChanged
    {
        public ErrorStateManager ErrorStateManager { get; }
        public IEnumerable<IValidator> Validators { get; protected set; } = new List<IValidator>();

        public ValidationViewModelBase()
        {
            ErrorStateManager = new ErrorStateManager();
        }

        public virtual void ValidateAll()
        {
            ErrorStateManager.Clear();

            Validate(Validators);
        }

        public virtual void Validate([CallerMemberName]string propertyName = null)
        {
            var existingErrorMessages = ErrorStateManager[propertyName]?.Messages;

            Validate(Validators
                .Where(v => v.PropertyName == propertyName));
        }

        private void Validate(IEnumerable<IValidator> validators)
        {
            foreach (var validator in validators)
                Validate(validator);
        }

        private void Validate(IValidator validator)
        {
            if (!validator.Validate())
                ErrorStateManager.Add(validator.PropertyName, validator.Message);
            else
                ErrorStateManager.Remove(validator.PropertyName, validator.Message);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string property = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
