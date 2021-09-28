using System.Collections.Generic;
using System.Drawing;

namespace Brick_Breaker_2
{
    class Player
    {
        /* Player needs to be placed on either the top or bottom of the form and in the middle on the X axis.
         * Player can only move horizontally (-X or X) according to its SPEED.
         * The players Width and Height will match the dimensions of the image it is attached to, this will be used to determine boundaries for collisions and the boundaries of the form.
         * The player will have a set amount of lives, and when a life is depleted the player will move back to its start position.*/

        // --- Properties ---
        public Rectangle Body { get { return body; } }
        public int Lives { get; private set; }

        // --- Public Fields ---
        public bool Left;
        public bool Right;
        public int Score;

        // --- Private Fields ---
        const int WIDTH_OFFSET = 40;
        const int HEIGHT_OFFSET = 10;
        const int MAX_LIVES = 3;
        const int SPEED = 5;
        readonly TeamType playerTeam;
        readonly Image playerImage;
        readonly Rectangle area;
        Rectangle body;


        // --- Constructor ---
        /// <summary>
        /// Holds all the information about the Player. 
        /// </summary>
        /// <param name="_area_size">The play space that the player will move in.</param>
        /// <param name="_playerImage">The image that will represent the player.</param>
        /// <param name="_player_team">The kind of player. Player 1 starts at the bottom of the screen, whereas Player 2 and the CPU will be at the top of the screen.</param>
        public Player(Rectangle _area_size, TeamType _player_team, List<Image> _player_images)
        {
            area = _area_size;

            playerTeam = _player_team;

            if (playerTeam == TeamType.Player_1)
                playerImage = _player_images[0]; // player 1 image @ index 0;
            else if (playerTeam == TeamType.Player_2)
                playerImage = _player_images[1]; // player 2 image @ index 1;
            else if (playerTeam == TeamType.CPU)
                playerImage = _player_images[2]; // CPU image @ index 2;

            body.Width = 60;
            body.Height = 20;

            ResetPosition();

            Left = false;
            Right = false;

            Lives = MAX_LIVES;
        }

        // --- Methods ---
        /// <summary>
        /// Moves the player back to their starting positions depending on their PlayerType.
        /// </summary>
        public void ResetPosition()
        {
            if (playerTeam == TeamType.Player_1)
            {
                body.X = area.Width / 2 - body.Width + WIDTH_OFFSET;    // Centres on the X axis.
                body.Y = area.Height - (body.Height + HEIGHT_OFFSET);   // Player_1 goes at the bottom.
            }
            else
            {
                body.X = area.Width / 2 - body.Width + WIDTH_OFFSET; // Centres on the X axis.
                body.Y = area.Y + ((body.Height) - HEIGHT_OFFSET - 5);     // Player_2 and CPU go at the top.
            }
        }

        /// <summary>
        /// Translates the player on the X axis either left or right.
        /// </summary>
        public void UpdatePosition()
        {
            MoveLeft();
            MoveRight();
        }

        /// <summary>
        /// Translates the player on the X axis towards the left.
        /// </summary>
        void MoveLeft()
        {
            if (Left)
            {
                if (body.X <= area.X)   // Reached the left hand side boundary.
                    body.X = area.X;    // Keep it on the boundary and no further.
                else
                    body.X -= SPEED;    // Do the translation left (-).
            }
        }

        /// <summary>
        /// Translates the player on the X axis towards the right.
        /// </summary>
        void MoveRight()
        {
            if (Right)
            {
                if (body.X >= area.Width - body.Width)  // Reached the right hand side boundary.
                    body.X = area.Width - body.Width;   // Keep it on the boundary and no further.
                else
                    body.X += SPEED;                    // Do the translation left (-).
            }
        }


        /// <summary>
        /// Increases the score when the player uses their ball to break blocks or get past the other player.
        /// </summary>
        public void IncreaseScore()
        {
            Score++;
        }

        /// <summary>
        /// Decreases the amount of lives the player has and resets the position when either an enemy ball gets past or their own ball gets past.
        /// </summary>
        public void DecreaseLives() // make it a list of balls in the engine
        {
            Lives--;
        }

        /// <summary>
        /// Draws the image associated with the player onto the form.
        /// </summary>
        /// <param name="_gfx">The graphics object passed that will draw the image.</param>
        public void Draw(Graphics _gfx)
        {
            _gfx.DrawImage(playerImage, new Rectangle(body.Location, body.Size));
        }

    }
}
