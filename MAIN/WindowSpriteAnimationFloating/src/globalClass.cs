using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowSpriteAnimationFloating.src
{
    class globalClass
    {
        // Image File Local Path
        public static string ImagePath = "";
        // Sprite Image Total Count
        public static int SpriteCount = 0;
        // Sprite Image Row Count
        public static int SpriteRowCount = 0;
        // Time Of Sprite Image Change Next Frame
        public static double SpriteNextTime = 0.0;
        // Manual Sprite Size Change
        public static bool ManualSizeChange;
        // Manual Sprite Size X, Y Point
        public static int ManualWidth = 0;
        public static int ManualHeight = 0;
        public static int ManualStartRowPoint = 0;
    }
}
