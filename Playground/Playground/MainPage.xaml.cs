using Playground.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Playground
{
    public partial class MainPage : ContentPage
    {
        private const int MinFontSize = 16;
        private QuoteNavigatorViewModel ViewModel;

        private double _SliderValue = 0;

        public double SliderValue
        {
            get => _SliderValue;
            set
            {
                _SliderValue = value;
                ViewModel.FontSize = GetFontSizeFromDouble(value);
            }
        }

        List<string> Quotes = new List<string>
        {
            "Quote 1",
            "Quote 2",
            "Quote 3",
            "Quote 4",
            "Quote 5",
        };
        public int CurrentNoteIndex { get; set; } = 0;

        public MainPage()
        {

            InitializeComponent();
            slider.BindingContext = this;
            int fontSize = (int)(slider?.Value ?? 0) * 10 + MinFontSize;
            BindingContext = ViewModel =
                new QuoteNavigatorViewModel(Quotes[CurrentNoteIndex], fontSize);

        }

        private void BtnForward_OnClicked(object sender, EventArgs e)
        {
            if (CurrentNoteIndex >= Quotes.Count -1) return;

            CurrentNoteIndex++;
            ViewModel.Quote = Quotes[CurrentNoteIndex];

            HandleButtonsEnableState();
        }

        private void BtnBack_OnClicked(object sender, EventArgs e)
        {
            if (CurrentNoteIndex == 0) return;

            CurrentNoteIndex--;
            if (CurrentNoteIndex < Quotes.Count -1)
                ViewModel.Quote = Quotes[CurrentNoteIndex];

            HandleButtonsEnableState();

        }

        private int GetFontSizeFromDouble(double value)
        {
            return (int)(value * 10) + MinFontSize;
        }

        private void HandleButtonsEnableState()
        {
            ViewModel.CanGoForward = CurrentNoteIndex < Quotes.Count - 1;
            ViewModel.CanGoBack = CurrentNoteIndex > 0;
        }
    }
}
