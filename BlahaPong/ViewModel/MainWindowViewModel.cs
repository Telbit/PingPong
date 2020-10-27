using BlahaPong.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BlahaPong.ViewModel
{
    public class MainWindowViewModel
    {
        ExitWindowViewModel _exitWindowViwModel = new ExitWindowViewModel();
        //PauseWindowViewModel _pauseWindowViwModel = new PauseWindowViewModel();

        public void ShowExitMessageBox()
        {
            var result = MessageBox.Show("Do you want to quit ?", "Goodbye?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Application.Current.Shutdown();
                    break;
                case MessageBoxResult.No:

                    break;
            }
        }

            public void KeydownEvent(object sender, KeyEventArgs e, UIElement rect, Image pauseImage)
        {
            switch (e.Key)
            {
                case Key.W: Canvas.SetTop(rect, Canvas.GetTop(rect) - 5);
                    break;
                case Key.S: Canvas.SetTop(rect, Canvas.GetTop(rect) + 5);
                    break;
                case Key.Escape:
                    ShowExitMessageBox();
                    //_exitWindowViwModel.ShowExitWindow();
                    break;
                case Key.Space:
                    if (pauseImage.Visibility == Visibility.Visible)
                    {
                        pauseImage.Visibility = Visibility.Hidden;
                    }else
                    {
                        pauseImage.Visibility = Visibility.Visible;
                    }
                    //PauseWindowViewModel.GetPauseWindowViewModel().ShowPauseWindow();
                    break;
            }
        }
    }
}