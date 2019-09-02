using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Menu = Playground.Models.Menu;

namespace Playground.ViewModels
{
    public class MenuViewModel
    {
        public ICommand NavigateCommand { get; set; }
        private MasterDetailPage Context => ((MasterDetailPage) App.Current.MainPage);
        public List<Menu> Menus => new List<Menu>
        {
            new Menu
            {
                Id = 1,
                Label = "Absolute Layout",
                Page = typeof(AbsoluteLayoutPage)
            },
            new Menu
            {
                Id = 2,
                Label = "List View",
                Page = typeof(AirbnbRecentSearchesPage)
            },
            new Menu
            {
                Id = 3,
                Label = "Images",
                Page = typeof(GalleryPage)
            },
            new Menu
            {
                Id = 4,
                Label = "Grid Layout",
                Page = typeof(GridPage)
            },
            new Menu
            {
                Id = 5,
                Label = "Stack Layout",
                Page = typeof(StackLayoutPage)
            },
            new Menu
            {
                Id = 6,
                Label = "Relative Layout",
                Page = typeof(RelativeLayoutPage)
            },
            new Menu
            {
                Id = 7,
                Label = "Navigation",
                Page = typeof(InstagramAppPage)
            },
            new Menu
            {
                Id = 8,
                Label = "Table View",
                Page = typeof(TableViewPage)
            },
            new Menu
            {
                Id = 9,
                Label = "Forms",
                Page = typeof(ContactListPage)
            }
        };

        public MenuViewModel()
        {
            NavigateCommand = new Command<int>(Navigate);
        }

        public async void Navigate(int id)
        {
            var selectedMenu = Menus.FirstOrDefault(e => e.Id == id);
            var p = (Page)Activator.CreateInstance(selectedMenu.Page);
            await Context.Detail.Navigation.PushAsync(p);
            Context.IsPresented = false;
        }
    }
}
