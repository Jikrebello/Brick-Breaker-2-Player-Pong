using System.Drawing;
using System.Windows.Forms;

namespace Brick_Breaker_2
{
    public partial class FrmBrickBreaker : Form
    {
        GameEngine pongGame;


        public FrmBrickBreaker()
        {
            InitializeComponent();
            pongGame = new GameEngine(PnlDisplayArea.DisplayRectangle);
            pongGame.StartGame();
        }

        internal void Loop()
        {
            pongGame.UpdateGame();

            // ---DEBUG---
            //LblPlayer1Lives.Text = "Player 1 Lives: " + pongGame.Player_1.Lives;
            //LblPlayer2Lives.Text = "Player 2 Lives: " + pongGame.Player_2.Lives;
            //LblPlayer1Score.Text = "Player 1 Score: " + pongGame.Player_1.Score;
            //LblPlayer2Score.Text = "Player 2 Score: " + pongGame.Player_2.Score;
            //LblDebug.Text = "Top: " + pongGame.Player_1.Body.Top.ToString() + Environment.NewLine +
            //                "Bottom: " + pongGame.Player_1.Body.Bottom.ToString() + Environment.NewLine +
            //                "Left: " + pongGame.Player_1.Body.Left.ToString() + Environment.NewLine +
            //                "Right: " + pongGame.Player_1.Body.Right.ToString() + Environment.NewLine +
            //                "Height: " + pongGame.Player_1.Body.Height.ToString() + Environment.NewLine +
            //                "Width: " + pongGame.Player_1.Body.Width.ToString();
        }

        private void FrmBrickBreaker_KeyDown(object sender, KeyEventArgs e)
        {
            pongGame.UpdateKey(e, true);
        }

        private void FrmBrickBreaker_KeyUp(object sender, KeyEventArgs e)
        {
            pongGame.UpdateKey(e, false);
        }


        private void PnlDisplayArea_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;


            gfx.PageUnit = GraphicsUnit.Pixel;

            if (pongGame.GameOver == false)
            {
                pongGame.Top_Side_Ball.Draw(gfx);
                pongGame.Bottom_Side_Ball.Draw(gfx);
                pongGame.Player_1.Draw(gfx);
                pongGame.Player_2.Draw(gfx);

                Pen p = new Pen(Color.Red);

                // ---DEBUG---
                //gfx.DrawRectangle(p, pongGame.blockArea);

                for (int i = 0; i < pongGame.BlockList.Count; i++)
                    pongGame.BlockList[i].Draw(gfx);
            }

        }
    }
}
