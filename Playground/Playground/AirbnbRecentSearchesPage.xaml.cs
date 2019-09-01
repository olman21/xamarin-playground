using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.Models;
using Playground.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AirbnbRecentSearchesPage : ContentPage
	{
		public AirbnbRecentSearchesPage ()
		{
			InitializeComponent ();

            BindingContext = new AirbnbSearchViewModel();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedSearch = e.SelectedItem as AirbnbSearch;
            if (selectedSearch == null)
                return;

            DisplayAlert("Selected", selectedSearch.Place, "OK");

            ListView.SelectedItem = null;
        }
    }
}