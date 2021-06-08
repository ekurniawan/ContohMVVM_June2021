using ContohMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContohMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeePage : ContentPage
    {
        public CoffeePage()
        {
            InitializeComponent();
            //BindingContext = new CoffeeViewModel();
        }
       
    }
}