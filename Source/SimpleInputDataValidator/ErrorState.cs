using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SimpleInputDataValidator
{
    public class ErrorState : INotifyPropertyChanged
    {
        public IReadOnlyCollection<string> Messages { get; private set; }
        readonly List<string> messages;

        public ErrorState()
        {
            messages = new List<string>();
            Messages = messages.AsReadOnly();
        }

        public ErrorState(string message)
        {
            messages = new List<string>
            {
                message
            };
            Messages = messages.AsReadOnly();
            UpdateHasError();
        }

        public void Append(string message)
        {
            messages.Add(message);
            Messages = messages.AsReadOnly();
            RaisePropertyChanged(nameof(Messages));
            UpdateHasError();
        }

        private void UpdateHasError()
            => HasError = messages?.Any() ?? false;

        bool _hasError;
        public bool HasError
        {
            get => _hasError;
            set
            {
                if (_hasError != value)
                {
                    _hasError = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void RaisePropertyChanged([CallerMemberName]string property = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public event PropertyChangedEventHandler PropertyChanged;

        internal void Remove(string message)
        {
            if (messages.Contains(message))
            {
                messages.Remove(message);
                Messages = messages.AsReadOnly();
                RaisePropertyChanged(nameof(Messages));
                UpdateHasError();
            }
        }
    }
}
