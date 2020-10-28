using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BlahaPong.Model
{
    public class Ball : Sprite
    {
        public Ellipse BallItem { get; }= new Ellipse();
        public Ball(int xPosition, int yPosition, int speed, int height, int width) : base(speed)
        {
            BallItem.Fill = Brushes.Red;
            BallItem.Stroke = Brushes.Black;
            BallItem.Width = width;
            BallItem.Height = height;
            Canvas.SetLeft(BallItem, xPosition);
            Canvas.SetTop(BallItem, yPosition);
        }

        public override void Move(double windowHeight)
        {
            MessageBox.Show("move");
        }
        
    }
}