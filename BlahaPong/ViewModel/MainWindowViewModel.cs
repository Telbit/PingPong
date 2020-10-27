using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BlahaPong.ViewModel
{
    public class MainWindowViewModel
    {
        public void KeydownEvent(object sender, KeyEventArgs e, UIElement rect)
        {
            switch (e.Key)
            {
                case Key.W: Canvas.SetTop(rect, Canvas.GetTop(rect) - 5);
                    break;
                case Key.S: Canvas.SetTop(rect, Canvas.GetTop(rect) + 5);
                    break;
            }
        }
    }
}