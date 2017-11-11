using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ToolBar.Templates
{
   public partial class MinimizeWindowTemplate
    {
       private void EnterMinWindow(object sender, RoutedEventArgs e)
       {
           sender.InvokeSizingForWindow(w => w.WindowState = WindowState.Minimized);

           foreach (Window window in App.Current.Windows)
               if (window is MainView)
                   window.WindowState = WindowState.Normal;
       }
    }
}
