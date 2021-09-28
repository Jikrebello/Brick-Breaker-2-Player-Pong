using System;
using System.Windows.Forms;

namespace Brick_Breaker_2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DateTime currentTime;
            DateTime pastTime;
            TimeSpan deltaTime;
            _ = DateTime.Now;
            pastTime = DateTime.Now;

            FrmBrickBreaker form = new FrmBrickBreaker();
            form.Show();

            while (form.Created == true)
            {
                currentTime = DateTime.Now;
                deltaTime = currentTime - pastTime;
                if (deltaTime.TotalMilliseconds > 10)
                {
                    Application.DoEvents();
                    form.Loop();
                    form.Refresh();
                    pastTime = DateTime.Now;
                }
            }
        }
    }
}
