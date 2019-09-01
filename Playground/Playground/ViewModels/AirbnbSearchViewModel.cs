using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Playground.Models;
using Xamarin.Forms;

namespace Playground.ViewModels
{
    public class AirbnbSearchViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<AirbnbSearch> Searches { get; set; } = new ObservableCollection<AirbnbSearch>();
        private string _searchTerm;
        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                LoadList();
            }
        }
        public ICommand DeleteSearchCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        private bool _isBusy = false;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
        }

        private List<AirbnbSearch> FullList = new List<AirbnbSearch>
        {
            new AirbnbSearch
            {
                Id = Guid.NewGuid().ToString(),
                Place = "West Hollywood, CA, United States",
                Dates = "Sep 1, 2016 - Nov 1, 2016"
            },

            new AirbnbSearch
            {
                Id = Guid.NewGuid().ToString(),
                Place = "Santa Monica, CA, United States",
                Dates = "Sep 1, 2016 - Nov 1, 2016"
            },
            new AirbnbSearch{
                Id = Guid.NewGuid().ToString(),
                Place = "Alberta, CA, United States",
                Dates = "Sep 1, 2016 - Nov 1, 2016"
            },
            new AirbnbSearch{
                Id = Guid.NewGuid().ToString(),
                Place = "Los Angeles, CA, United States",
                Dates = "Sep 1, 2016 - Nov 1, 2016"
            }
        };

        public event PropertyChangedEventHandler PropertyChanged;

        public AirbnbSearchViewModel()
        {
            LoadList();
            DeleteSearchCommand = new Command<string>(DeleteSearch);
            RefreshCommand = new Command(async () => await LoadMore());
        }

        public Task LoadMore()
        {
            IsBusy = true;
            return Task.Run(() =>
            {
                Task.Delay(2000);
                FullList.Add(new AirbnbSearch
                {
                    Id = Guid.NewGuid().ToString(),
                    Place = "Miami, FL, United States",
                    Dates = "Sep 1, 2016 - Nov 1, 2016"
                });
                LoadList();
                IsBusy = false;
            });
        }

        public void LoadList()
        {
            var filteredList = FullList;
            if (!string.IsNullOrWhiteSpace(SearchTerm)) filteredList = FullList.Where(s => s.Place.Contains(SearchTerm)).ToList();

            Searches.Clear();
            foreach (var search in filteredList)
            {
                Searches.Add(search);
            }
        }


        public void DeleteSearch(string id)
        {
            var target = FullList.FirstOrDefault(e => e.Id == id);
            if (target != null)
            {
                FullList.Remove(target);
                LoadList();
            }
        }
    }
}
