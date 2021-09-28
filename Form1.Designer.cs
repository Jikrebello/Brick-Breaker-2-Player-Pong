
namespace Brick_Breaker_2
{
    partial class FrmBrickBreaker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblPlayer1Lives = new System.Windows.Forms.Label();
            this.LblPlayer2Lives = new System.Windows.Forms.Label();
            this.LblPlayer1Score = new System.Windows.Forms.Label();
            this.LblPlayer2Score = new System.Windows.Forms.Label();
            this.PnlDisplayArea = new Brick_Breaker_2.DoubleBufferedPanel();
            this.LblDebug = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblPlayer1Lives
            // 
            this.LblPlayer1Lives.AutoSize = true;
            this.LblPlayer1Lives.Location = new System.Drawing.Point(9, 68);
            this.LblPlayer1Lives.Name = "LblPlayer1Lives";
            this.LblPlayer1Lives.Size = new System.Drawing.Size(101, 17);
            this.LblPlayer1Lives.TabIndex = 2;
            this.LblPlayer1Lives.Text = "Player 1 Lives:";
            // 
            // LblPlayer2Lives
            // 
            this.LblPlayer2Lives.AutoSize = true;
            this.LblPlayer2Lives.Location = new System.Drawing.Point(9, 94);
            this.LblPlayer2Lives.Name = "LblPlayer2Lives";
            this.LblPlayer2Lives.Size = new System.Drawing.Size(101, 17);
            this.LblPlayer2Lives.TabIndex = 3;
            this.LblPlayer2Lives.Text = "Player 2 Lives:";
            // 
            // LblPlayer1Score
            // 
            this.LblPlayer1Score.AutoSize = true;
            this.LblPlayer1Score.Location = new System.Drawing.Point(9, 12);
            this.LblPlayer1Score.Name = "LblPlayer1Score";
            this.LblPlayer1Score.Size = new System.Drawing.Size(105, 17);
            this.LblPlayer1Score.TabIndex = 5;
            this.LblPlayer1Score.Text = "Player 1 Score:";
            // 
            // LblPlayer2Score
            // 
            this.LblPlayer2Score.AutoSize = true;
            this.LblPlayer2Score.Location = new System.Drawing.Point(9, 38);
            this.LblPlayer2Score.Name = "LblPlayer2Score";
            this.LblPlayer2Score.Size = new System.Drawing.Size(105, 17);
            this.LblPlayer2Score.TabIndex = 6;
            this.LblPlayer2Score.Text = "Player 2 Score:";
            // 
            // PnlDisplayArea
            // 
            this.PnlDisplayArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlDisplayArea.Location = new System.Drawing.Point(12, 123);
            this.PnlDisplayArea.Name = "PnlDisplayArea";
            this.PnlDisplayArea.Size = new System.Drawing.Size(955, 600);
            this.PnlDisplayArea.TabIndex = 4;
            this.PnlDisplayArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlDisplayArea_Paint);
            // 
            // LblDebug
            // 
            this.LblDebug.AutoSize = true;
            this.LblDebug.Location = new System.Drawing.Point(507, 12);
            this.LblDebug.Name = "LblDebug";
            this.LblDebug.Size = new System.Drawing.Size(0, 17);
            this.LblDebug.TabIndex = 7;
            // 
            // FrmBrickBreaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(982, 733);
            this.Controls.Add(this.LblDebug);
            this.Controls.Add(this.LblPlayer2Score);
            this.Controls.Add(this.LblPlayer1Score);
            this.Controls.Add(this.PnlDisplayArea);
            this.Controls.Add(this.LblPlayer2Lives);
            this.Controls.Add(this.LblPlayer1Lives);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBrickBreaker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brick Breaker";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBrickBreaker_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmBrickBreaker_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblPlayer1Lives;
        private System.Windows.Forms.Label LblPlayer2Lives;
        private DoubleBufferedPanel PnlDisplayArea;
        private System.Windows.Forms.Label LblPlayer1Score;
        private System.Windows.Forms.Label LblPlayer2Score;
        private System.Windows.Forms.Label LblDebug;
    }
}

