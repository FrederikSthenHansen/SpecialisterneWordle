using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WordleWPF.Model;
using WordleWPF.ViewModel;

namespace WordleWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            GameMaster GM= new GameMaster();
            WordleViewModel myViewModel = new WordleViewModel();
        }
    }
}
