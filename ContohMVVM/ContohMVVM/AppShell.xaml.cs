using ContohMVVM.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ContohMVVM
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddCoffeeSQLitePage),
                typeof(AddCoffeeSQLitePage));
        }
    }
}
