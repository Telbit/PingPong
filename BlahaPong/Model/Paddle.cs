using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BlahaPong.Model
{
    public class Paddle : Sprite
    {
        private Rectangle rectangle = new Rectangle();
        public Key KeyUp { get; }
        public Key KeyDown { get; }

        public Paddle(int xPosition, int yPosition, int speed, int height, int width, Canvas canvas, Key keyUp, Key keyDown) : base(xPosition, yPosition, speed, height, width, canvas)
        {
            KeyUp = keyUp;
            KeyDown = keyDown;
            this.canvas = canvas;
            rectangle.Fill = Brushes.Black;
            rectangle.Width = width;
            rectangle.Height = height;
            canvas.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, xPosition);
            Canvas.SetTop(rectangle, yPosition);
        }

        public override void Move(int xDirection, int yDirection)
        {
            MessageBox.Show("move");
        }

        public override void IsOnBorder()
        {
            throw new System.NotImplementedException();
        }
    }
}