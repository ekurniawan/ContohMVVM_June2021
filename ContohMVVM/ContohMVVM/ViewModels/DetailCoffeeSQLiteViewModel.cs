using ContohMVVM.Shared.Models;
using ContohMVVM.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContohMVVM.ViewModels
{
    [QueryProperty(nameof(CoffeeId),nameof(CoffeeId))]
    public class DetailCoffeeSQLiteViewModel : ViewModelBase
    {
        public string CoffeeId { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand DoneCommand { get; }
        public DetailCoffeeSQLiteViewModel()
        {
            Title = "Detail Coffee";
            RefreshCommand = new AsyncCommand(Refresh);
            DoneCommand = new AsyncCommand(Done);
        }

        private async Task Done()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async Task Refresh()
        {
            int.TryParse(CoffeeId, out var result);
            var coffee = await CoffeeService.GetCoffeeById(result);

            Id = coffee.Id;
            Name = coffee.Name;
            Roaster = coffee.Roaster;
            Image = coffee.Image;
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string roaster;
        public string Roaster
        {
            get { return roaster; }
            set { SetProperty(ref roaster, value); }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }


    }
}
