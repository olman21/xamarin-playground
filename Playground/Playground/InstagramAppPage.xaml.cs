using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.InstagramAppPages;
using Playground.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InstagramAppPage : TabbedPage
	{
        private UserService _userService = new UserService();
		public InstagramAppPage ()
		{
			InitializeComponent ();

        }
	}
}