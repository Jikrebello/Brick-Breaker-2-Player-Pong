using System.Windows.Forms;

namespace Brick_Breaker_2
{
    public static class Globals
    {
        static readonly string path = Application.StartupPath;

        public static string Player1Paddle = path + @"\Player1Paddle.png";
        public static string Player2Paddle = path + @"\Player2Paddle.png";
        public static string CPUPaddle = path + @"\CPUPaddle.png";

        public static string Ball = path + @"\Ball.png";

        public static string WeakenedBlock = path + @"\BrickFinalHit.png";
        public static string StrongBlock = path + @"\BrickNoHit.png";
        public static string InvincibleBlock = path + @"\UnbreakableBrick.png";
    }
}
