using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Figury
{
    static public class Init
    {
        public static Bitmap bitmap;
        public static PictureBox pictureBox;
        public static Pen pen;
    }
    abstract public class Figure
    {
        public int x;
        public int y;
        public int w;
        public int h;
        abstract public void Draw();
        abstract public void MoveTo(int x, int y);
    }
}
