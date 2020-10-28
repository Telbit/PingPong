using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BlahaPong.Model
{
    public class Ball : Sprite
    {
        public Ellipse BallItem { get; }= new Ellipse();
        private int xDirection;
        private int yDirection;
        private Paddle playerOne;
        private Paddle playerTwo;
        public Ball(int xPosition, int yPosition, int speed, int height, int width) : base(speed)
        {
            xDirection = -1;
            yDirection = 1;
            BallItem.Fill = Brushes.Red;
            BallItem.Stroke = Brushes.Black;
            BallItem.Width = width;
            BallItem.Height = height;
            Canvas.SetLeft(BallItem, xPosition);
            Canvas.SetTop(BallItem, yPosition);
        }

        public void SetPlayers( Paddle playerOne, Paddle playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
        }

        public override void Move(double windowHeight, double windowWidth)
        {
            CollisionCheck();
            if (Canvas.GetTop(this.BallItem) < 0 || Canvas.GetTop(this.BallItem) > windowHeight)
            {
                xDirection = -xDirection;
            }

            if (Canvas.GetLeft(this.BallItem) < 0 || Canvas.GetLeft(this.BallItem) > windowWidth)
            {
                yDirection = -yDirection;
            }

            Canvas.SetTop(BallItem, Canvas.GetTop(BallItem) + xDirection * speed);
            Canvas.SetLeft(BallItem, Canvas.GetLeft(BallItem) + yDirection * speed);
        }

        private void CollisionCheck()
        {
            CollidePlayer(playerOne);
            // if ()
            // {
            //     xDirection = -xDirection;
            //     yDirection = -yDirection;
            // }
        }

        private void CollidePlayer(Paddle player)
        {
            if (Canvas.GetTop(playerOne.Rectangle).Equals(Canvas.GetTop(BallItem)) )
            {
                Console.WriteLine($"paddle: {Canvas.GetTop(BallItem)} {Canvas.GetLeft(BallItem)} ball: {Canvas.GetTop(BallItem)} {Canvas.GetLeft(BallItem)}");
            }
        }
    }
}