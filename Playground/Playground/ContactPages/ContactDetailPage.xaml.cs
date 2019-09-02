using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.Models;
using Playground.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground.ContactPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailPage : ContentPage
    {
        private ContactViewModel ViewModel;
		public ContactDetailPage (ContactViewModel viewModel)
		{
			InitializeComponent ();
            BindingContext = ViewModel = viewModel;
        }

        private async void Save_OnClicked(object sender, EventArgs e)
        {
            var errors = await ViewModel.Save();
            if (errors.Any())
            {
                await DisplayAlert("Missing Fields", string.Join(Environment.NewLine, errors), "OK");
                return;
            }
            await Navigation.PopAsync();
        }
    }
}