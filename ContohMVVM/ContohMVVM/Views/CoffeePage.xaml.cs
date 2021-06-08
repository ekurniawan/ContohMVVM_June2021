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
        public ICommand IncreaseCount { get; }

        public CoffeePage()
        {
            InitializeComponent();
            IncreaseCount = new Command(OnIncrease);
            
            BindingContext = this;

        }

        int count = 0;
        private void OnIncrease()
        {
            count++;
            CountDisplay = $"Anda klik {count} time";
        }

        private string countDisplay="Click Me";
        public string CountDisplay
        {
            get { return countDisplay; }
            set {
                if (value == countDisplay)
                    return;

                countDisplay = value;
                OnPropertyChanged();
            }
        }


        
       
    }
}