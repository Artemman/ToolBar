using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToolBar.Helpers
{
    public static class Behaviors 
    {
        #region DandBehaviour
        public static readonly DependencyProperty DragBehaviourProperty =
            DependencyProperty.RegisterAttached("DragBehaviour", typeof(ICommand), typeof(Behaviors),
                new FrameworkPropertyMetadata(null,
                    FrameworkPropertyMetadataOptions.None,
                    OnDragBehaviourChanged));
        public static ICommand GetDragBehaviour(DependencyObject d)
        {
            return (ICommand)d.GetValue(DragBehaviourProperty);
        }
        public static void SetDragBehaviour(DependencyObject d, ICommand value)
        {
            d.SetValue(DragBehaviourProperty, value);
        }
        private static void OnDragBehaviourChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Grid g = d as Grid;
            if (g != null)
            {
                g.Drop += (s, a) =>
                    {
                        ICommand iCommand = GetDragBehaviour(d);
                        if (iCommand != null)
                        {
                            if (iCommand.CanExecute(a.Data))
                            {
                                iCommand.Execute(a.Data);
                            }
                        }
                    };
            }
            else
            {
                throw new ApplicationException("Non grid");
            }
        }
        #endregion
       
      

    }
}

