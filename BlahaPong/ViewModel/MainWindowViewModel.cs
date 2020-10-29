using System;
using System.Reflection;
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
using Path = System.IO.Path;

namespace BlahaPong.ViewModel
{
    public class MainWindowViewModel
    {

        public MainWindowViewModel(Canvas canv, Boolean isOnePlayerMode)
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)?.Replace(@"bin\Debug\netcoreapp3.1", @"Resources\images\bg.png") ?? throw new InvalidOperationException()));
            canv.Background = ib;
            

            canv.Children.Add(playerOne.Rectangle);
            canv.Children.Add(playerTwo.Rectangle);
            canv.Children.Add(_ball.BallItem);
            canv.Children.Add(PauseImage);
            canv.Children.Add(PlayerOneScore);
            canv.Children.Add(PlayerTwoScore);
        }

        private bool isOnePlayerMode;

        private readonly static int SCORE_BOX_HEIGHT = 45;

        private readonly static int SCORE_BOX_WIDTH = 46;

        private readonly static int SCORE_BOX_FONT_SIZE = 36;

        private readonly static string SCORE_BOX_BASICS_TEXT = "0";
        
        private readonly static FontFamily SCORE_BOX_FONT_FAMILY = new FontFamily("Bahnschrift SemiBold");

        private double WindowHeight;
        private double WindowWidth;
        public Paddle playerOne { get; } = new Paddle(20, 115, 10, 100, 10);
        public Paddle playerTwo { get; } = new Paddle(750, 115, 10, 100, 10);
        public Ball _ball { get; } = new Ball(380, 197, 10, 20, 20);

        public void SetWindowHeightAndWidth(double height, double width)
        {
            this.WindowHeight = height;
            this.WindowWidth = width;
        }


        private TextBox PlayerOneScore { get; set; } = new TextBox() {
            Height = SCORE_BOX_HEIGHT,
            Width = SCORE_BOX_WIDTH,
            Text= SCORE_BOX_BASICS_TEXT,
            TextWrapping = TextWrapping.Wrap,
            FontSize = SCORE_BOX_FONT_SIZE,
            FontFamily = SCORE_BOX_FONT_FAMILY,
            IsReadOnly = true,
            BorderThickness = new Thickness(0),
            TextAlignment = TextAlignment.Center,
            Background = Brushes.Transparent
        };
        private TextBox PlayerTwoScore { get; set; } = new TextBox() {
            Height = SCORE_BOX_HEIGHT,
            Width = SCORE_BOX_WIDTH,
            Text = SCORE_BOX_BASICS_TEXT,
            TextWrapping = TextWrapping.Wrap,
            FontSize = SCORE_BOX_FONT_SIZE,
            FontFamily = SCORE_BOX_FONT_FAMILY,
            IsReadOnly = true,
            BorderThickness = new Thickness(0),
            TextAlignment = TextAlignment.Center,
            Background = Brushes.Transparent
        };

        private Image PauseImage { get; } = new Image()
        {
            Height = 206,
            Width = 708,
            Visibility = Visibility.Hidden,
            Source = new BitmapImage(new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)?.Replace(@"bin\Debug\netcoreapp3.1", @"Resources\pauseTwo.png") ?? throw new InvalidOperationException()))
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
            if (e.Key == Key.W || e.Key == Key.S)
            {
                playerOne.PaddleMove = false;
                playerOne.Direction = 0;
            }
            else if (e.Key == Key.Down || e.Key == Key.Up)
            {
                playerTwo.PaddleMove = false;
                playerTwo.Direction = 0;
            }
        }

        public void StartGameLoop(Boolean isOnePLayerMode)
        {

            this.isOnePlayerMode = isOnePLayerMode;

            _ball.SetPlayers(playerOne,playerTwo);

            Canvas.SetLeft(PauseImage, 46);
            Canvas.SetTop(PauseImage, 104);
            
            Canvas.SetLeft(PlayerOneScore, 338);
            Canvas.SetTop(PlayerOneScore, 10);
            
            Canvas.SetLeft(PlayerTwoScore, 412);
            Canvas.SetTop(PlayerTwoScore, 10);
            
            timer = new DispatcherTimer();
            timer.Tick += UpdateGame;
            timer.Interval = new TimeSpan(0, 0, 0,0,25);
            timer.Start();
        }

        private void UpdateGame(object sender, EventArgs e)
        {
            _ball.Move(WindowHeight, WindowWidth);
            playerOne.Move(WindowHeight, WindowWidth);
            playerTwo.Move(WindowHeight, WindowWidth);
        }
    }
}