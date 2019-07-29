
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleInputDataValidator.UI.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorSummaryView : ContentView
    {
        public ErrorSummaryView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ErrorStateManagerProperty =
            BindableProperty.Create(nameof(ErrorStateManager), typeof(ErrorStateManager),
                typeof(ErrorSummaryView), null, BindingMode.OneWay,
                null, null, null, null, null);

        public ErrorStateManager ErrorStateManager
        {
            get { return (ErrorStateManager)GetValue(ErrorStateManagerProperty); }
            set { SetValue(ErrorStateManagerProperty, value); }
        }
    }
}