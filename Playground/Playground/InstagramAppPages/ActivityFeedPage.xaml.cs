using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.Models;
using Playground.Services;
using Playground.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground.InstagramAppPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActivityFeedPage : ContentPage
	{
        public ActivityViewModel ViewModel { get; set; }
        private UserService _service = new UserService();
		public ActivityFeedPage ()
		{
			InitializeComponent ();
            BindingContext = ViewModel = new ActivityViewModel();
        }

        protected async override void OnAppearing()
        {
            if(ViewModel.Activities.Count == 0)
                await ViewModel.LoadTasks();
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedActivity = e.SelectedItem as Activity;
            if (selectedActivity == null) return;

            var selectedUser = await _service.GetUser(selectedActivity.UserId);

            await Navigation.PushModalAsync(new NavigationPage(new UserProfilePage(selectedUser)));

            ListView.SelectedItem = null;
        }
    }
}