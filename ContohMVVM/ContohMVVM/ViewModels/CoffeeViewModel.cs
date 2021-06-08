using ContohMVVM.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContohMVVM.ViewModels
{
    public class CoffeeViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }

        public AsyncCommand RefreshCommand { get; }

        public CoffeeViewModel()
        {
            Title = "Coffee Equipment";
            Coffee = new ObservableRangeCollection<Coffee>();
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            Coffee.Add(new Coffee { Roaster="Dark Roast",Name="Italian Roast", Image=image });
            Coffee.Add(new Coffee { Roaster="Medium Roast",Name="Colombia",Image=image});
            Coffee.Add(new Coffee { Roaster = "Medium Roast", Name = "Pike Place", Image = image });
            Coffee.Add(new Coffee { Roaster = "Medium Roast", Name = "Brazilian", Image = image });

            RefreshCommand = new AsyncCommand(Refresh);
        }

        private async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }
    }
}
