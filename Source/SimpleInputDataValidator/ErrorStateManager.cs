using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SimpleInputDataValidator
{
    public class ErrorStateManager : INotifyPropertyChanged
    {
        Dictionary<string, ErrorState> states = new Dictionary<string, ErrorState>();

        public event PropertyChangedEventHandler PropertyChanged;

        public void Add(string key, string description)
        {
            if (states.ContainsKey(key))
            {
                if (!states[key].Messages.Contains(description))
                {
                    states[key].Append(description);
                    NotifyMessagesChanged();
                }
            }
            else
            {
                states.Add(key, new ErrorState(description));
                NotifyErrorStateCollectionChanged();
                NotifyMessagesChanged();
            }
        }

        public void Clear()
        {
            states = new Dictionary<string, ErrorState>();
            NotifyErrorStateCollectionChanged();
            NotifyMessagesChanged();
        }

        public void Clear(string propertyName)
        {
            if (states.ContainsKey(propertyName))
            {
                states.Remove(propertyName);
                NotifyErrorStateCollectionChanged();
                NotifyMessagesChanged();
            }
        }


        public ErrorState this[string key]
        {
            get
            {
                if (states.ContainsKey(key))
                {
                    return states[key];
                }
                return null;
            }
        }

        public IReadOnlyList<string> AllMessages
        {
            get
            {
                return states.SelectMany(s => s.Value.Messages).ToList().AsReadOnly();
            }
        }

        public bool HasError
        {
            get => states.Any();
        }

        internal void Remove(string propertyName, string message)
        {
            if (states.ContainsKey(propertyName) && states[propertyName].Messages.Contains(message))
            {
                states[propertyName].Remove(message);
                NotifyMessagesChanged();

                if (!states[propertyName].HasError)
                    Clear(propertyName);
            }
        }

        private void NotifyMessagesChanged()
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AllMessages)));

        private void NotifyErrorStateCollectionChanged()
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item"));
    }
}
