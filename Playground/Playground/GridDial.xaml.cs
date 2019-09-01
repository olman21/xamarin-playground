using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GridDial : ContentPage
	{

		public GridDial ()
		{
			InitializeComponent ();
		}

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            DialLabel.Text += button.Text;
        }
    }
}