using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFigury
{
    public class Operator : OperatorMethod
    {
        public char symbolOperator;
        public EmptyOperatorMethod operatorMethod = null;
        public BinaryOperatorMethod binaryOperator = null;
        public BinaryOperatorMethod1 binaryOperator1 = null;
        public TrinaryOperatorMethod trinaryOperator = null;
        public Operator(EmptyOperatorMethod operatorMethod, char symbolOperator)
        {
            this.operatorMethod = operatorMethod;
            this.symbolOperator = symbolOperator;
        }
        public Operator(BinaryOperatorMethod binaryOperator, char symbolOperator)
        {
            this.binaryOperator = binaryOperator;
            this.symbolOperator = symbolOperator;
        }
        public Operator(BinaryOperatorMethod1 binaryOperator1, char symbolOperator)
        {
            this.binaryOperator1 = binaryOperator1;
            this.symbolOperator = symbolOperator;
        }
        public Operator(TrinaryOperatorMethod trinaryOperator, char symbolOperator)
        {
            this.trinaryOperator = trinaryOperator;
            this.symbolOperator = symbolOperator;
        }
        public Operator(char symbolOperator)
        {
            this.symbolOperator = symbolOperator;
        }
    }
}
