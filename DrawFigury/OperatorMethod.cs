using Figury;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFigury
{
    public class OperatorMethod
    {
        public delegate void EmptyOperatorMethod();
        public delegate void UnaryOperatorMethod(object operand);
        public delegate void BinaryOperatorMethod(int operand1, int operand2);
        public delegate void BinaryOperatorMethod1(Figure operand1, bool operand2);
        public delegate void TrinaryOperatorMethod(object operand1, object operand2, object operand3);
    }
}
