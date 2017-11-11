using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ToolBar.Templates;
using StructureMap;
using ToolBar.Models;
using ToolBar.DataAccess;
using ToolBar.ViewModels;
using ToolBar.Views;
namespace ToolBar
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Container container = new Container(x =>
            { x.For<IModelList>().Use<ModelList>(); x.For<IXamlScriptGenerator>().Use<XamlScriptGenerator>(); });
            var window = container.GetInstance<MainView>();
            window.DataContext = container.GetInstance<ViewModel>();
            window.Top = (SystemParameters.FullPrimaryScreenHeight - window.Height) / 2;
            window.Left = 0;
            window.WindowState = WindowState.Minimized;
            window.Show();
            var minwindow = new MinimizeWindow();
            minwindow.Top = (SystemParameters.FullPrimaryScreenHeight - minwindow.Height) / 2;
            minwindow.Left = 0;
          
            minwindow.Show();

        }

        
    }
}
