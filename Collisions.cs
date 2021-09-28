using System.Collections.Generic;
using System.Drawing;

namespace Brick_Breaker_2
{
    class Collisions
    {
        readonly Player Player_1;
        readonly Player Player_2;

        readonly List<Ball> balls;
        readonly List<Block> blocks;
        readonly Rectangle area;

        public Collisions(Player _player_1, Player _player_2, List<Ball> _balls, List<Block> _blocks, Rectangle _area)
        {
            Player_1 = _player_1;
            Player_2 = _player_2;
            balls = _balls;
            blocks = _blocks;
            area = _area;
        }

        /// Handles all Collision checks between players, balls, blocks and boundaries.
        public void CheckCollisions()
        {
            // --- Ball on Ball--
            if (balls[0].Body.IntersectsWith(balls[1].Body))
            {
                balls[0].DirectionX *= -1;
                balls[0].DirectionY *= -1;
                balls[1].DirectionX *= -1;
                balls[1].DirectionY *= -1;
            }

            // --- Ball and Player Collisions ---
            BallAndPlayerCollisions();

            // --- Ball and Block Collisions ---
            BallAndBlockCollisions();

            // --- Top Ball Collisions---
            TopBallCollisionBackplateBoundaries();
            TopBallCollisionLeftAndRightBoundaries();

            // --- Bottom Ball Collisions ---
            BottomBallCollisionBackplateBoundaries();
            BottomBallCollisionLeftAndRightBoundaries();

        }

        void TopBallCollisionBackplateBoundaries()
        {
            if (balls[0].Body.Bottom > area.Bottom)
            {
                Player_1.DecreaseLives();
                balls[0].ResetPosition();
            }

            if (balls[0].Body.Top < area.Top)
            {
                Player_2.DecreaseLives();
                balls[0].ResetPosition();
            }
        }

        void TopBallCollisionLeftAndRightBoundaries()
        {
            if (balls[0].Body.Left < area.Left)
                balls[0].DirectionX *= -1;

            if (balls[0].Body.Right > area.Right)
                balls[0].DirectionX *= -1;
        }

        void BottomBallCollisionBackplateBoundaries()
        {
            if (balls[1].Body.Bottom > area.Bottom)
            {
                Player_1.DecreaseLives();
                balls[1].ResetPosition();
            }

            if (balls[1].Body.Top < area.Top)
            {
                Player_2.DecreaseLives();
                balls[1].ResetPosition();
            }
        }

        void BottomBallCollisionLeftAndRightBoundaries()
        {
            if (balls[1].Body.Left < area.Left)
                balls[1].DirectionX *= -1;

            if (balls[1].Body.Right > area.Right)
                balls[1].DirectionX *= -1;
        }


        void BallAndPlayerCollisions()
        {
            foreach (Ball ball in balls)
            {
                // --- Player 1 ---
                if (Player_1.Body.IntersectsWith(ball.Body))
                {
                    if (Player_1.Right && ball.DirectionX > 0 || Player_1.Left && ball.DirectionX < 0 || !Player_1.Right && ball.DirectionX > 0 || !Player_1.Left && ball.DirectionX < 0)
                    {
                        ball.DirectionY *= -1;
                    }
                    else if (Player_1.Right && ball.DirectionX < 0 || Player_1.Left && ball.DirectionX > 0)
                    {
                        ball.DirectionY *= -1;
                        ball.DirectionX *= -1;
                    }
                }

                // --- Player 2 ---
                if (Player_2.Body.IntersectsWith(ball.Body))
                {

                    if (Player_2.Right && ball.DirectionX > 0 || Player_2.Left && ball.DirectionX < 0 || !Player_2.Right && ball.DirectionX > 0 || !Player_2.Left && ball.DirectionX < 0)
                    {
                        ball.DirectionY *= -1;
                    }
                    else if (Player_2.Right && ball.DirectionX < 0 || Player_2.Left && ball.DirectionX > 0)
                    {
                        ball.DirectionY *= -1;
                        ball.DirectionX *= -1;
                    }
                }

            }
        }

        void BallAndBlockCollisions()
        {
            foreach (Ball ball in balls)
            {
                foreach (Block block in blocks)
                {
                    if (ball.Body.IntersectsWith(block.Body))
                    {
                        block.HitsLeft--;

                        if (block.HitsLeft <= 0)
                        {
                            block.MoveBlock(); // move block out of the way.
                            if (ball.LastPlayerHit == TeamType.Player_1)
                                Player_1.Score += 100; // add score to the relevant player
                            else if (ball.LastPlayerHit == TeamType.Player_2)
                                Player_2.Score += 100;
                            ball.DirectionX *= -1;
                            ball.DirectionY *= -1;
                        }
                        else if (block.HitsLeft == 1)
                        {
                            block.ChangeImage();
                            if (ball.LastPlayerHit == TeamType.Player_1)
                                Player_1.Score += 25;
                            else if (ball.LastPlayerHit == TeamType.Player_2)
                                Player_2.Score += 25;
                            ball.DirectionX *= -1;
                            ball.DirectionY *= -1;
                        }
                        else
                        {
                            ball.DirectionX *= -1;
                            ball.DirectionY *= -1;
                        }

                    }
                }
            }
        }

    }
}
