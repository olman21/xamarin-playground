using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.ContactPages;
using Playground.Models;
using Playground.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactListPage : ContentPage
    {
        public ContactViewModel ViewModel { get; set; }
        public ContactListPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new ContactViewModel();
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!ViewModel.Contacts.Any())
                await ViewModel.LoadContacts();

            ViewModel.StopEditing();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as Contact;
            if (contact == null) return;

            ViewModel.StartEditing(contact);
            ListView.SelectedItem = null;

            Navigation.PushAsync(new ContactDetailPage(ViewModel));
        }

        private void Add_OnClicked(object sender, EventArgs e)
        {
            ViewModel.StartEditing(new Contact());
            Navigation.PushAsync(new ContactDetailPage(ViewModel));
        }
    }
}