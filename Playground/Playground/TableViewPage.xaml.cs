using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground
{
    public class DateRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string StartLabel { get; set; }
    }

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TableViewPage : ContentPage
	{
		public TableViewPage ()
		{
			InitializeComponent ();
            BindingContext = new DateRange
            {
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(1),
                StartLabel = "Start"
            };
        }
	}
}