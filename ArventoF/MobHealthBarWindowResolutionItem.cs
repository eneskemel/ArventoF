using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _134KO
{
    public class MobHealthBarWindowResolutionItem
    {
        int width;
        int mobHealthBarStartX;
        int mobHealthBarEndX;

        public int MobHealthBarEndX
        {
            get { return mobHealthBarEndX; }
            set { mobHealthBarEndX = value; }
        }

        public int MobHealthBarStartX
        {
            get { return mobHealthBarStartX; }
            set { mobHealthBarStartX = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

    }
}
