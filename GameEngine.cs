using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Brick_Breaker_2
{
    class GameEngine
    {
        /* has a defined play area based off the forms rectangle
         * has boarders that the player and ball are contained with in
         * has the player
         * has the blocks
         * keeps track of the score
         */

        // --- Properties ---
        public bool GameOver { get; private set; }

        // --- Public Fields ---
        public Player Player_1;
        public Player Player_2;
        //public Player CPU;
        public Ball Top_Side_Ball;
        public Ball Bottom_Side_Ball;
        public List<Block> BlockList = new List<Block>();

        // --- Private Fields ---
        // Getting the dimensions of the play area.
        Rectangle area;

        // Loading in all the paddle/ player images.
        readonly Image player1Image = Image.FromFile(Globals.Player1Paddle);
        readonly Image player2Image = Image.FromFile(Globals.Player2Paddle);
        readonly Image CPUImage = Image.FromFile(Globals.CPUPaddle);
        readonly List<Image> paddleImages = new List<Image>();

        // Loading in all the ball images.
        readonly Image normalBall = Image.FromFile(Globals.Ball);

        // Loading in all the block images.
        readonly Image WeakendBlock = Image.FromFile(Globals.WeakenedBlock);
        readonly Image StrongBlock = Image.FromFile(Globals.StrongBlock);
        readonly Image InvincibleBlock = Image.FromFile(Globals.InvincibleBlock);
        readonly List<Image> blockImages = new List<Image>();

        // Make a list for all the balls
        List<Ball> balls = new List<Ball>();
        public Rectangle blockArea;
        int numberOfBlocks = 32;
        Collisions collisions;

        public GameEngine(Rectangle _area_size)
        {
            area = _area_size;

            // Load in Images.
            paddleImages.Add(player1Image);     //[0]
            paddleImages.Add(player2Image);     //[1]
            paddleImages.Add(CPUImage);         //[2]

            blockImages.Add(WeakendBlock);      //[0]
            blockImages.Add(StrongBlock);       //[1]
            blockImages.Add(InvincibleBlock);   //[2]
        }

        public void StartGame()
        {
            // Create players.
            Player_1 = new Player(area, TeamType.Player_1, paddleImages);
            Player_2 = new Player(area, TeamType.Player_2, paddleImages);
            //CPU = new Player(area, TeamType.CPU, paddleImages);

            // Create balls.
            Top_Side_Ball = new Ball(area, BallSide.Topside, normalBall);
            Bottom_Side_Ball = new Ball(area, BallSide.BottomSide, normalBall);
            balls.Add(Top_Side_Ball);
            balls.Add(Bottom_Side_Ball);

            blockArea = new Rectangle(area.X, (area.Height / 5) * 2, area.Width, area.Height / 4);


            GenerateBlocks(numberOfBlocks);
            PositionBlocks();

            collisions = new Collisions(Player_1, Player_2, balls, BlockList, area);
        }

        public void UpdateGame()
        {
            if (GameOver == false)
            {
                UpdateMovement();

                collisions.CheckCollisions();
                //CheckGameOver();
                //CheckAllBlocksDestroyed();
            }
        }


        /// <summary>
        /// Handles the movement for the Players and Balls.
        /// </summary>
        void UpdateMovement()
        {
            // --- Player 1 ---
            Player_1.UpdatePosition();

            // --- Player 2 ---
            Player_2.UpdatePosition();

            // --- CPU ---
            //CPU.UpdatePosition();


            // --- Balls ---
            foreach (Ball ball in balls)
                ball.Move();
        }


        /// <summary>
        /// Create the Blocks and set them up.
        /// </summary>
        void GenerateBlocks(int _numBlocks)
        {
            for (int i = 0; i < _numBlocks; i++)
            {
                Block block = new Block(blockArea, blockImages, 1);
                BlockList.Add(block);
            }

        }

        void PositionBlocks()
        {
            int xCoord = blockArea.X;
            int yCoord = blockArea.Y;

            foreach (Block block in BlockList)
            {
                block.Body.X = xCoord;
                block.Body.Y = yCoord;

                if (blockArea.Width - xCoord < block.Body.Width + 70)
                {
                    xCoord = blockArea.X;
                    yCoord = yCoord + block.Body.Height + 10;

                }
                else
                {
                    xCoord += block.Body.Width + 10;
                }

            }
        }

        /// <summary>
        /// Once either players Lives count reaches 0, the game will end.
        /// </summary>
        void CheckGameOver()
        {

        }

        void CheckAllBlocksDestroyed()
        {

        }

        public void UpdateKey(KeyEventArgs _e, bool _isPressed)
        {
            // --- Handle Player_1's Movement ---
            if (_e.KeyCode == Keys.D)
                Player_1.Right = _isPressed;
            else if (_e.KeyCode == Keys.A)
                Player_1.Left = _isPressed;


            // ---Handle Player_2's Movement ---
            if (_e.KeyCode == Keys.Left)
                Player_2.Left = _isPressed;
            else if (_e.KeyCode == Keys.Right)
                Player_2.Right = _isPressed;
        }
    }

}
