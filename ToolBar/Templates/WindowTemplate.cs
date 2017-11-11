using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using ToolBar.Views;

namespace ToolBar.Templates
{
    internal static class LocalExtensions
    {
        public static void InvokeSizingForWindow(this object FrameElement, Action<Window> action)
        {
            Window window = ((FrameworkElement)FrameElement).TemplatedParent as Window;
            if (window != null) action(window);
        }
    }

    public partial class WindowTemplate
    {
        #region CommandWindow
    
        private void MinWindow(object sender, RoutedEventArgs e)
        {
            sender.InvokeSizingForWindow(w => w.WindowState = WindowState.Minimized);
            foreach (Window window in App.Current.Windows)
                if (window is MinimizeWindow)
                    
                    window.WindowState = WindowState.Normal;
            
        }
        
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            foreach (Window window in App.Current.Windows)
                    window.Close();
        }
      

        #endregion CommandWindow

        #region P/Invoke

        const int WM_SYSCOMMAND = 0x112;
        const int SC_SIZE = 0xF000;
        const int SC_KEYMENU = 0xF100;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        #endregion  P/Invoke

    }
}
