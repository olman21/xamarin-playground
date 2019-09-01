using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Playground.Models;

namespace Playground.ViewModels
{
    public class QuoteNavigatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private QuoteNavigator QuoteNavigator;

        public string Quote
        {
            get => QuoteNavigator.Quote;
            set
            {
                QuoteNavigator.Quote = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Quote"));
            }
        }

        public int FontSize
        {
            get => QuoteNavigator.FontSize;
            set
            {
                QuoteNavigator.FontSize = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("FontSize"));
            }
        }

        public bool CanGoForward
        {
            get => QuoteNavigator.CanGoForward;
            set
            {
                QuoteNavigator.CanGoForward = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("CanGoForward"));
            }
        }

        public bool CanGoBack
        {
            get => QuoteNavigator.CanGoBack;
            set
            {
                QuoteNavigator.CanGoBack = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("CanGoBack"));
            }
        }


        public QuoteNavigatorViewModel(string Quote, int FontSize, bool CanGoForward = true, bool CanGoBack = false)
        {
            QuoteNavigator = new QuoteNavigator
            {
                FontSize = FontSize,
                Quote = Quote,
                CanGoForward = CanGoForward,
                CanGoBack = CanGoBack
            };
        }
    }
}
