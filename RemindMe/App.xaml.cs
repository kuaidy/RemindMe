using RemindMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RemindMe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() 
        {
            RemindMeView remindMeView = new RemindMeView();
            RemindMeViewModel remindMeViewModel = new RemindMeViewModel(remindMeView);
            remindMeView.DataContext = remindMeViewModel;
            remindMeView.Show();
        }
    }
}
