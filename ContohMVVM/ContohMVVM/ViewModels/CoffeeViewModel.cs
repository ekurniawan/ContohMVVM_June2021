using ContohMVVM.Shared.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContohMVVM.ViewModels
{
    public class CoffeeViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string,Coffee>> CoffeeGroup { get; set; }

        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Coffee> FavoriteCommand { get;  }
        public AsyncCommand<object> SelectedCommand { get; }
        public CoffeeViewModel()
        {
            Title = "Coffee Equipment";
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroup = new ObservableRangeCollection<Grouping<string, Coffee>>();

            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            Coffee.Add(new Coffee { Roaster="Dark Roast",Name="Italian Roast", Image=image });
            Coffee.Add(new Coffee { Roaster="Medium Roast",Name="Colombia",Image=image});
            Coffee.Add(new Coffee { Roaster = "Medium Roast", Name = "Pike Place", Image = image });
            Coffee.Add(new Coffee { Roaster = "Medium Roast", Name = "Brazilian", Image = image });

            CoffeeGroup.Clear();
            CoffeeGroup.Add(new Grouping<string, Coffee>("Dark Roast", 
                Coffee.Where(c => c.Roaster == "Dark Roast")));
            CoffeeGroup.Add(new Grouping<string, Coffee>("Medium Roast", 
                Coffee.Where(c => c.Roaster == "Medium Roast")));

            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Coffee>(Favorite);
            SelectedCommand = new AsyncCommand<object>(Selected);
        }

        private async Task Selected(object arg)
        {
            var coffee = arg as Coffee;
            if (coffee == null)
                return;
            SelectedCoffee = null;
            await Application.Current.MainPage.DisplayAlert("Favorite", coffee.Name, "OK");
        }

        private async Task Favorite(Coffee coffee)
        {
            if (coffee == null)
                return;
            await Application.Current.MainPage.DisplayAlert("Favorite", coffee.Name, "OK");
        }

        private Coffee selectedCoffee;
        public Coffee SelectedCoffee
        {
            get => selectedCoffee;
            set => SetProperty(ref selectedCoffee, value);
        }


        private async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }
    }
}
