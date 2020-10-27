using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace BlahaPong.Model
{
    public abstract class Sprite
    {
        protected int xPosition;
        protected int yPosition;
        protected int speed;
        protected int height;
        protected int width;
        protected Canvas canvas;

        protected Sprite(int xPosition, int yPosition, int speed, int height, int width, Canvas canvas)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.speed = speed;
            this.height = height;
            this.width = width;
            this.canvas = canvas;
        }

        public abstract void Move(int xDirection, int yDirection);
        public abstract void IsOnBorder();
    }
}
