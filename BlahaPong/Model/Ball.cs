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

        public override void Move(double windowHeight)
        {
            Console.WriteLine(windowHeight);
            if (Canvas.GetTop(this.BallItem) < 0 || Canvas.GetTop(this.BallItem) > windowHeight)
            {
                xDirection = -xDirection;
            }
            Canvas.SetTop(BallItem, Canvas.GetTop(BallItem) + xDirection * speed);
        }
    }
}