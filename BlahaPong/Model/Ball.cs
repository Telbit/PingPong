using System.Windows;
using System.Windows.Controls;

namespace BlahaPong.Model
{
    public class Ball : Sprite
    {
        public Ball(int xPosition, int yPosition, int speed, int height, int width) : base(speed)
        {
        }

        public override void Move()
        {
            MessageBox.Show("move");
        }

        public override void IsOnBorder()
        {
            throw new System.NotImplementedException();
        }
    }
}