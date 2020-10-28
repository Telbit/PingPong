using System.Windows;
using System.Windows.Controls;

namespace BlahaPong.Model
{
    public class Ball : Sprite
    {
        public Ball(int xPosition, int yPosition, int speed, int height, int width, Canvas canvas) : base(xPosition, yPosition, speed, height, width, canvas)
        {
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