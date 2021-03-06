using ContohMVVM.Shared.Models;
using ContohMVVM.Services;
using ContohMVVM.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContohMVVM.ViewModels
{
    public class CoffeeSQLiteViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get;  }
        public AsyncCommand AddCommand { get;  }
        public AsyncCommand<Coffee> RemoveCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }

        

        public CoffeeSQLiteViewModel()
        {
            Title = "My Coffee SQLite";
            Coffee = new ObservableRangeCollection<Coffee>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Coffee>(Remove);
            SelectedCommand = new AsyncCommand<object>(Selected);
        }

        private async Task Selected(object arg)
        {
            var coffee = arg as Coffee;
            if (coffee == null)
                return;
            var route = $"{nameof(DetailCoffeeSQLitePage)}?CoffeeId={coffee.Id}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task Remove(Coffee coffee)
        {
            await CoffeeService.RemoveCoffee(coffee.Id);
            await Refresh();
            //await App.Current.MainPage.DisplayAlert("Keterangan", coffee.Name, "OK");
        }

        private async Task Add()
        {
            //var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Coffee Name");
            //var roaster = await App.Current.MainPage.DisplayPromptAsync("Roaster", "Coffee Roaster");
            //await CoffeeService.AddCoffee(name, roaster);
            var route = $"{nameof(AddCoffeeSQLitePage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task Refresh()
        {
            IsBusy = true;
            //await Task.Delay(1000);

            Coffee.Clear();
            var results = await CoffeeService.GetCoffee();
            Coffee.AddRange(results);


            IsBusy = false;
        }
    }
}
