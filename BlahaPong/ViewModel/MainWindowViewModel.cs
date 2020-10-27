using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace BlahaPong.ViewModel
{
    public class MainWindowViewModel
    {
        public void KeydownEvent(object sender, KeyEventArgs e, Rectangle rect, double botBorder)
        {
            switch (e.Key)
                {
                    case Key.W:
                        if (Canvas.GetTop(rect) > 0)
                        {
                            Canvas.SetTop(rect, Canvas.GetTop(rect) - 5);
                        }
                        break;
                    case Key.S:
                        if (Canvas.GetTop(rect) + rect.Height + 35 < botBorder)
                        {
                            Canvas.SetTop(rect, Canvas.GetTop(rect) + 5);
                        }
                        break;
                }
        }
    }
}