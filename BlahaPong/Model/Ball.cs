﻿using System;
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
        // player references for collision check and later for scores
        private Paddle playerOne;
        private TextBox playerOneTextBox;

        private Paddle playerTwo;
        private TextBox playerTwoTextBox;

        private bool isOnePlayerMode;
        public Ball(int xPosition, int yPosition, int speed, int height, int width, bool isOnePlayerMode) : base(speed)
        {
            xDirection = -1;
            yDirection = 1;
            BallItem.Fill = Brushes.Red;
            BallItem.Stroke = Brushes.Black;
            BallItem.Width = width;
            BallItem.Height = height;
            Canvas.SetLeft(BallItem, xPosition);
            Canvas.SetTop(BallItem, yPosition);
            this.isOnePlayerMode = isOnePlayerMode;
        }

        public void SetPlayers( Paddle playerOne, Paddle playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
        }
        public void SetPlayers( Paddle playerOne)
        {
            this.playerOne = playerOne;
        }

        public void SetPlayerTextBox(TextBox PlayerOne)
        {
            playerOneTextBox = PlayerOne;
        }

        public void SetPlayerTextBox(TextBox PlayerOne, TextBox PlayerTwo)
        {
            playerOneTextBox = PlayerOne;
            playerTwoTextBox = PlayerTwo;
        }

        public override void Move(double windowHeight, double windowWidth)
        {
            CollisionCheck(); //Check if players touch the ball
            
            // Detect Collision with wall, Score for point should check here 
            if (Canvas.GetTop(this.BallItem) < 0 || Canvas.GetTop(this.BallItem) > windowHeight)
            {
                xDirection = -xDirection;
            }

            if (Canvas.GetLeft(this.BallItem) < 0 || Canvas.GetLeft(this.BallItem) > windowWidth)
            {
                if (!isOnePlayerMode){

                    if (Canvas.GetLeft(this.BallItem) > windowWidth)
                    {
                        playerOneTextBox.Text = (Int32.Parse(playerOneTextBox.Text) + 1).ToString();
                    }
                    else
                    {
                        playerTwoTextBox.Text = (Int32.Parse(playerTwoTextBox.Text) + 1).ToString();
                    }
                }
                //Console.WriteLine($"P1: {playerOne.Score}, P2: {playerTwo.Score}");
                yDirection = -yDirection;
            }

            Canvas.SetTop(BallItem, Canvas.GetTop(BallItem) + xDirection * speed);
            Canvas.SetLeft(BallItem, Canvas.GetLeft(BallItem) + yDirection * speed);
        }

        private void CollisionCheck()
        {
            CollidePlayer(playerOne);
            if (!isOnePlayerMode) CollidePlayer(playerTwo);

        }

        private void CollidePlayer(Paddle player)
        {
            // This glorious shit really checks if the ball hit a paddle
            if (Canvas.GetTop(player.Rectangle) < Canvas.GetTop(BallItem) 
                && Canvas.GetTop(player.Rectangle) + player.Rectangle.Height > Canvas.GetTop(BallItem)
                && (int) Canvas.GetLeft(player.Rectangle) == (int) Canvas.GetLeft(BallItem))
            {
                // Change the direction of the ball
                yDirection = -yDirection;
                // according to the player movement
                xDirection = player.Direction;
                if (isOnePlayerMode) playerOneTextBox.Text = (Int32.Parse(playerOneTextBox.Text) + 1).ToString();
            }
        }
    }
}