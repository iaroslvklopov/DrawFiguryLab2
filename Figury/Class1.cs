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
        public string name;
        public static PictureBox pictureBox;
        abstract public void Draw();
        /// <summary>
        /// Метод перемещения фигуры
        /// </summary>
        /// <param name="x">Смещение по координате x</param>
        /// <param name="y">Смещение по координате y</param>
        abstract public void MoveTo(int x, int y);
        /// <summary>
        /// Метод удаления фигуры
        /// </summary>
        /// <param name="figure">Удаляемая фигура</param>
        /// <param name="flag">Если флаг = 1, то удаление, если = 0, то перемещение</param>
        public void DeleteF(Figure figure, bool flag = true)
        {
            if (flag == true)
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figures.Remove(figure);
                this.Clear();
                Init.pictureBox.Image = Init.bitmap;
                foreach (Figure f in ShapeContainer.figures)
                {
                    f.Draw();
                }
            }
            else
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figures.Remove(figure);
                this.Clear();
                pictureBox.Image = Init.bitmap;
                foreach (Figure f in ShapeContainer.figures)
                {
                    f.Draw();
                }
                ShapeContainer.figures.Add(figure);
            }
        }
        public void Clear()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
        }
    }
}
