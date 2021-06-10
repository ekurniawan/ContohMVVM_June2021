using ContohMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContohMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //[QueryProperty(nameof(CoffeeId),nameof(CoffeeId))]
    public partial class DetailCoffeeSQLitePage : ContentPage
    {
        public string CoffeeId { get; set; }
        public DetailCoffeeSQLitePage()
        {
            InitializeComponent();
        }

        /*protected async override void OnAppearing()
        {
            base.OnAppearing();
            int.TryParse(CoffeeId, out var result);

            BindingContext = await CoffeeService.GetCoffeeById(result);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }*/
    }
}