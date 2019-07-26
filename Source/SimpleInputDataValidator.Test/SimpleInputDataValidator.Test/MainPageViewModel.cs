using SimpleInputDataValidator.Validators;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleInputDataValidator.Test
{
    public class MainPageViewModel : ValidationViewModelBase
    {
        private string _input;

        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                RaisePropertyChanged();
                Validate();
                Validate(nameof(Input2));
            }
        }

        private string _input2;

        public string Input2
        {
            get { return _input2; }
            set
            {
                _input2 = value;
                RaisePropertyChanged();
                Validate();
            }
        }

        private string _input3;

        public string Input3
        {
            get { return _input3; }
            set
            {
                _input3 = value;
                RaisePropertyChanged();
                Validate();
            }
        }

        private bool _showValidationSummary;

        public bool ShowValidationSummary
        {
            get { return _showValidationSummary; }
            set { _showValidationSummary = value; RaisePropertyChanged(); }
        }


        ICommand _submitCommand;
        public ICommand SubmitCommand
        {
            get => _submitCommand ?? (_submitCommand = new Command(ValidateAndSave));
        }

        public MainPageViewModel()
        {
            Validators = new List<IValidator>()
            {
                new StringNotNullOrEmptyValidator(nameof(Input), () => Input, "Value cannot be null or empty"),
                new ValidatorBase(nameof(Input), InputShouldBeInterger, "Value should be a valid number"),
                new ValidatorBase(nameof(Input2), InputsShouldBeDifferent, "Value should not be the same as the previous one"),
                new RegexValidator(nameof(Input3), () => Input3, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", "Not a valid email address")
            };
        }

        private void ValidateAndSave(object obj)
        {
            ValidateAll();
            if (ErrorStateManager.HasError)
            {
                ShowValidationSummary = true;
            }
            else
            {
                ShowValidationSummary = false;
            }
        }

        private bool InputsShouldBeDifferent()
            => Input != Input2;

        private bool InputShouldBeInterger()
            => int.TryParse(Input, out int _);
    }
}
