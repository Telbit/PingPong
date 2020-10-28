using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;
using BlahaPong.Model;

namespace BlahaPong.ViewModel
{
    public class MainWindowViewModel
    {
        public Paddle playerOne = new Paddle(20, 115, 5, 200, 10);
        public void KeydownEvent(KeyEventArgs e, double botBorder)
        {
            switch (e.Key)
            {
                case Key.W:
                    playerOne.Direction = -1;
                    playerOne.PaddleMove = true;
                    break;
                case Key.S:
                    playerOne.Direction = +1;
                    playerOne.PaddleMove = true;
                    break;
            }
        }

        public void StartGameLoop()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += UpdateGame;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void UpdateGame(object sender, EventArgs e)
        {
            playerOne.Move();
        }
    }
}