using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Playground.Models;
using Playground.Services;

namespace Playground.ViewModels
{
    public class ActivityViewModel
    {
        public ObservableCollection<Activity> Activities { get; set; }
        private readonly ActivityService _activityService = new ActivityService();

        public ActivityViewModel()
        {
            Activities = new ObservableCollection<Activity>();
        }

        public async Task LoadTasks()
        {
            var listOfActivities = await _activityService.GetActivities();
            foreach (var activity in listOfActivities)
            {
                Activities.Add(activity);
            }
        }
    }
}
