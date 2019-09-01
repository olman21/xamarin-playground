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
	public partial class GalleryPage : ContentPage
    {
        private int ImageIndex = 1;
        private const int MaxImageIndex = 10;
		public GalleryPage ()
		{
			InitializeComponent();

            AssignImageSource();
        }

        private void BtnBack_OnClicked(object sender, EventArgs e)
        {
            if (ImageIndex == 1)
                return;

            ImageIndex--;
            AssignImageSource();
        }

        private void BtnForward_OnClicked(object sender, EventArgs e)
        {
            if (ImageIndex == MaxImageIndex)
                return;

            ImageIndex++;
            AssignImageSource();
        }

        private void AssignImageSource()
        {
            image.Source = new UriImageSource
            {
                Uri = new Uri($"http://lorempixel.com/1920/1080/city/{ImageIndex}"),
                CachingEnabled = false
            };
        }
    }
}