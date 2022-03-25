using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figury
{
    public class ShapeContainer
    {
        public static List<Figure> figures;
        static ShapeContainer()
        {
            figures = new List<Figure>();
        }
        public static void AddFigure(Figure figure)
        {
            figures.Add(figure);
        }
    }
}
