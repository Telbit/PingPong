using System;
using BlahaPong.View;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;
using BlahaPong.Model;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BlahaPong.ViewModel
{
    public class MainWindowViewModel
    {
        public Paddle playerOne { get; } = new Paddle(20, 115, 5, 200, 10);
        public Paddle playerTwo { get; } = new Paddle(750, 115, 5, 200, 10);
        public Ball _ball { get; } = new Ball(380, 197, 5, 20, 20);


        public Image PauseImage { get; } = new Image()
        {
            Height = 206,
            Width = 708,
            Visibility = Visibility.Hidden,
            Source = new BitmapImage(new Uri("C:/Users/J/source/repos/c-sharp-pingpong-blahapong/BlahaPong/Resources/pauseTwo.png"))
        };
        
        private DispatcherTimer timer;
        public void KeydownEvent(KeyEventArgs e, double botBorder){
            switch (e.Key)
            {
                case Key.W:
                    playerOne.Direction = -1;
                    playerOne.PaddleMove = true;
                    break;
                case Key.S:
                    playerOne.Direction = 1;
                    playerOne.PaddleMove = true;
                    break;
                case Key.Down:
                    playerTwo.Direction = 1;
                    playerTwo.PaddleMove = true;
                    break;
                case Key.Up:
                    playerTwo.Direction = -1;
                    playerTwo.PaddleMove = true;
                    break;
                case Key.Space:
                    if (PauseImage.Visibility == Visibility.Visible)
                    {
                        PauseImage.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        PauseImage.Visibility = Visibility.Visible;
                    }
                    timer.IsEnabled = !timer.IsEnabled;
                    //PauseWindowViewModel.GetPauseWindowViewModel().ShowPauseWindow();
                    break;
                case Key.Escape:
                    ShowExitMessageBox();
                    //_exitWindowViwModel.ShowExitWindow();
                    break;    
            }
        }
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
        
        public void KeyUpEvent(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    playerOne.PaddleMove = false;
                    break;
                case Key.S:
                    playerOne.PaddleMove = false;
                    break;
                case Key.Down:
                    playerTwo.PaddleMove = false;
                    break;
                case Key.Up:
                    playerTwo.PaddleMove = false;
                    break;
            }
        }

        public void StartGameLoop()
        {
            Canvas.SetLeft(PauseImage, 46);
            Canvas.SetTop(PauseImage, 104);
            timer = new DispatcherTimer();
            timer.Tick += UpdateGame;
            timer.Interval = new TimeSpan(0, 0, 0,0,25);
            timer.Start();
        }

        private void UpdateGame(object sender, EventArgs e)
        {
            playerOne.Move();
            playerTwo.Move();
        }
    }
}