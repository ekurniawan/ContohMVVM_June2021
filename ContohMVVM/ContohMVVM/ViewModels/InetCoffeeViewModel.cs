using ContohMVVM.Services;
using ContohMVVM.Shared.Models;
using ContohMVVM.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContohMVVM.ViewModels
{
    public class InetCoffeeViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Coffee> RemoveCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }

        private ICoffee coffeeServices;

        public InetCoffeeViewModel()
        {
            Title = "My Coffee SQLite";
            Coffee = new ObservableRangeCollection<Coffee>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Coffee>(Remove);
            SelectedCommand = new AsyncCommand<object>(Selected);

            coffeeServices = new InetCoffeeService();
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
            await coffeeServices.RemoveCoffee(coffee.Id);
            await Refresh();
            //await App.Current.MainPage.DisplayAlert("Keterangan", coffee.Name, "OK");
        }

        private async Task Add()
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Coffee Name");
            var roaster = await App.Current.MainPage.DisplayPromptAsync("Roaster", "Coffee Roaster");
            await coffeeServices.AddCoffee(name, roaster);
            await Refresh();
            //var route = $"{nameof(AddCoffeeSQLitePage)}";
            //await Shell.Current.GoToAsync(route);
        }

        private async Task Refresh()
        {
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("Keterangan",
                    "Tidak ada koneksi internet !", "OK");
            }

            IsBusy = true;
            //await Task.Delay(1000);

            Coffee.Clear();
            var results = await coffeeServices.GetCoffee();
            Coffee.AddRange(results);


            IsBusy = false;
        }
    }
}
