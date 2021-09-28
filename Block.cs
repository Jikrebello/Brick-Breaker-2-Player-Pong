using System.Collections.Generic;
using System.Drawing;

namespace Brick_Breaker_2
{
    class Block
    {

        // --- Properties ---
        //public Rectangle Body { get { return body; } }
        public BlockCondition BlockCondition { get { return blockCondition; } }

        // --- Public Fields ---
        public Rectangle Body;
        public int HitsLeft;


        // --- Private Fields ---
        readonly Rectangle area;
        readonly BlockCondition blockCondition;
        readonly bool isInvincible;
        Image blockImage;

        // --- Constructor ---
        public Block(Rectangle _area, List<Image> _blockImages, int _blockCondition)
        {
            area = _area;

            if (_blockCondition == 0)         // Weakened Block
            {
                blockImage = _blockImages[0];
                blockCondition = BlockCondition.Weakened;
                isInvincible = false;
                HitsLeft = 1;
            }
            else if (_blockCondition == 1)      // Strong Block
            {
                blockImage = _blockImages[1];
                blockCondition = BlockCondition.Strong;
                isInvincible = false;
                HitsLeft = 2;
            }
            else if (_blockCondition == 2)  // Invincible Block
            {
                blockImage = _blockImages[2];
                blockCondition = BlockCondition.Invincible;
                isInvincible = true;
                HitsLeft = -1;
            }

            Body.Width = 50;
            Body.Height = 17;
        }

        // --- Methods ---
        /// <summary>
        /// Creates the block off screen for later positioning.
        /// </summary>
        public void MoveBlock()
        {
            Body.X = -250;
            Body.Y = -250;
        }


        public void ChangeImage()
        {
            if (HitsLeft == 1)
            {
                blockImage = Image.FromFile(Globals.WeakenedBlock);
            }
        }

        /// <summary>
        /// Draws the image associated with the player onto the form.
        /// </summary>
        /// <param name="_gfx">The graphics object passed that will draw the image.</param>
        public void Draw(Graphics _gfx)
        {
            _gfx.DrawImage(blockImage, new Rectangle(Body.Location, Body.Size));

        }
    }
}
