using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground.InstagramAppPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProfilePage : ContentPage
	{
		public UserProfilePage (User user)
		{
            InitializeComponent();
            BindingContext = user ?? throw new ArgumentNullException(nameof(user));
            Title = user.Name;
        }
	}
}