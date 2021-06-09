using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using System.Threading.Tasks;
using ContohMVVM.Services;

namespace ContohMVVM.ViewModels
{
    public class AddCoffeeSQLiteViewModel : ViewModelBase
    {
        public AsyncCommand SaveCommand { get; set; }

        public AddCoffeeSQLiteViewModel()
        {
            Title = "Add Coffee";
            SaveCommand = new AsyncCommand(Save);
        }

        private async Task Save()
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(roaster))
            {
                return;
            }
            await CoffeeService.AddCoffee(name, roaster);
        }

        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string roaster;
        public string Roaster
        {
            get => roaster;
            set => SetProperty(ref roaster, value);
        }


    }
}
