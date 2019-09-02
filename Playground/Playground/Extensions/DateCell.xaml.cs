using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Playground.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateCell : ViewCell
    {
        public static readonly BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(string),
            typeof(DateCell));

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set
            {
                SetValue(LabelProperty, value);
            }
        }
        public static readonly BindableProperty ValueProperty = BindableProperty.Create("Value", typeof(DateTime), typeof(DateCell));
        public DateTime Value
        {
            get => (DateTime)GetValue(ValueProperty);
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        public DateCell()
        {
            InitializeComponent();
        }

        //protected override void OnPropertyChanged(string propertyName)
        //{
        //    if (propertyName == "Label")
        //        label.Text = Label;
        //    else if (propertyName == "Value")
        //        datePicker.Date = Value;
        //}


        private static void HandleLabelValueChange(BindableObject bindable, object oldValue, object newValue)
        {
            var targetView = (DateCell)bindable;
            if (targetView != null)
                targetView.label.Text = (string) newValue;
        }

    }
}