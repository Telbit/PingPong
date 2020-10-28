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
        public Paddle playerOne { get; } = new Paddle(20, 115, 5, 200, 10);
        public Paddle playerTwo { get; } = new Paddle(750, 115, 5, 200, 10);
        public Ball _ball { get; } = new Ball(380, 197, 5, 20, 20);
        public void KeydownEvent(KeyEventArgs e, double botBorder)
        {
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
            DispatcherTimer timer = new DispatcherTimer();
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