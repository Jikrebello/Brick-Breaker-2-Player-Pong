using System;
using System.Drawing;

namespace Brick_Breaker_2
{
    class Ball
    {
        // --- Properties ---
        public Rectangle Body { get { return body; } }
        public BallSide BallSide { get { return ballSide; } }

        // --- Public Fields ---
        public int DirectionX;
        public int DirectionY;
        public TeamType LastPlayerHit;

        // -- Private Fields ---
        const int HEIGHT_OFFSET = 100;
        readonly Image ballImage;
        readonly Rectangle area;
        readonly BallSide ballSide;
        readonly Random rand = new Random();
        Rectangle body;

        // --- Constructor ---
        /// <summary>
        /// Holds all the information about the Ball. 
        /// </summary>
        /// <param name="_area_size">The play space that the Ball will move in.</param>
        /// <param name="_ball_side">Which side the ball will start on.</param>
        /// <param name="_ball_image">The image that will represent the ball</param>
        public Ball(Rectangle _area_size, BallSide _ball_side, Image _ball_image)
        {
            area = _area_size;
            ballImage = _ball_image;
            ballSide = _ball_side;

            if (ballSide == BallSide.BottomSide) // Just sets the LastPlayerHit to a value corresponding to which side of the area it started on.
                LastPlayerHit = TeamType.Player_1;
            else
                LastPlayerHit = TeamType.Player_2;

            body.Width = 25;
            body.Height = 25;

            ResetPosition();
        }

        // --- Methods ---
        /// <summary>
        /// Resets the balls' position to its starting position based off its Ballside Type.
        /// </summary>
        public void ResetPosition()
        {
            if (ballSide == BallSide.BottomSide)
            {
                body.X = area.Width / 2 - body.Width;                   // Centres on the X axis.
                body.Y = area.Height / 2 - body.Height + HEIGHT_OFFSET; // Positioned towards to the bottom.
                DirectionX = rand.Next(-2, 3);                          // Allows it to move either left or right in (+) X or (-) X.
                if (DirectionX == 0)
                    DirectionX = 1;                                     // Ensures we don't have a 0 value on the X axis.
                DirectionY = rand.Next(1, 4);                           // Points the ball down in only (+)Y/ downwards.
            }
            else
            {
                body.X = area.Width / 2 - body.Width;                   // Centres on the X axis.
                body.Y = area.Height / 2 - body.Height - HEIGHT_OFFSET; // Positioned towards the top.
                DirectionX = rand.Next(-2, 3);                          // Allows it to move either left or right in (+) X or (-) X.
                if (DirectionX == 0)
                    DirectionX = 1;                                     // Ensures we don't have a 0 value on the X axis.
                DirectionY = rand.Next(-3, 0);                          // Points the ball down in only (-)Y/ upwards.
            }
        }

        /// <summary>
        /// Moves the ball according to the DirectionX and DirectionY values set at start.
        /// </summary>
        public void Move()
        {
            body.X += DirectionX;
            body.Y += DirectionY;
        }

        /// <summary>
        /// Draws the image associated with the player onto the form.
        /// </summary>
        /// <param name="_gfx">The graphics object passed that will draw the image.</param>
        public void Draw(Graphics _gfx)
        {
            _gfx.DrawImage(ballImage, new Rectangle(body.Location, body.Size));
        }

    }
}
