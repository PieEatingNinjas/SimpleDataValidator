using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleInputDataValidator.UI.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class DefaultTemplates : ResourceDictionary
    {
        public DefaultTemplates()
        {
            InitializeComponent();
        }
    }
}