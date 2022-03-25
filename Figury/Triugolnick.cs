using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figury
{
    public class Triugla : Figure
    {
        public PointF[] points;
        public Triugla(PointF[] points)
        {
            this.points = points;
        }
        public Triugla()
        {
            this.points = new PointF[3];
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, points);
            Init.pictureBox.Image = Init.bitmap;
        }
        public override void MoveTo(int x, int y)
        {

        }
    }
}

