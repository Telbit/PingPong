using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BlahaPong.Model
{
    public class Paddle : Sprite
    {
        public Rectangle Rectangle {get;} = new Rectangle();
        public int Direction {get; set;}
        public bool PaddleMove {get; set;}

        public Paddle(int xPosition, int yPosition, int speed, int height, int width) : base(speed)
        {
            Rectangle.Fill = Brushes.Black;
            Rectangle.Width = width;
            Rectangle.Height = height;
            Canvas.SetLeft(Rectangle, xPosition);
            Canvas.SetTop(Rectangle, yPosition);
        }

        public override void Move(double windowHeight)
        {
            if (PaddleMove && CanMove(windowHeight))
            {
                Canvas.SetTop(Rectangle, Canvas.GetTop(Rectangle) + Direction * speed);
            }
        }
        
        private bool CanMove(double botBorder)
        {
            if (Canvas.GetTop(Rectangle) < 0 && Direction == -1)
            {
                return false;
            } else if (Canvas.GetTop(Rectangle) + Rectangle.Height > botBorder && Direction == 1)
            {
                return false;
            }
            return true;
        }
    }
}