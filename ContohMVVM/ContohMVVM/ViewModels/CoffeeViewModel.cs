using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContohMVVM.ViewModels
{
    public class CoffeeViewModel : BindableObject
    {
        public ICommand IncreaseCount { get; }
        private string countDisplay = "Click Me";

        public CoffeeViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
        }

        public string CountDisplay
        {
            get { return countDisplay; }
            set
            {
                if (value == countDisplay)
                    return;

                countDisplay = value;
                OnPropertyChanged();
            }
        }

        int count = 0;
        private void OnIncrease()
        {
            count++;
            CountDisplay = $"Anda klik {count} time";
        }
    }
}
