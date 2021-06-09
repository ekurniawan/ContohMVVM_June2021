using ContohMVVM.Models;
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
    public partial class CoffeeCollectionViewPage : ContentPage
    {
        public CoffeeCollectionViewPage()
        {
            InitializeComponent();
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection[0] as Coffee;
            await DisplayAlert("Favorite Coffee", data.Name, "OK");
        }
    }
}