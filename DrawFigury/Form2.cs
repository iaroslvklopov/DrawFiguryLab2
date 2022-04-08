using Figury;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFigury
{
    public partial class Form2 : Form
    {
        private Figure figure;
        private Bitmap bitmap;
        private Pen pen;
        private Ellipse ellipse;
        private Stack<Operator> operators = new Stack<Operator>();
        private Stack<Operand> operands = new Stack<Operand>();
        public string outputString = "";
        public Form2()
        {
            InitializeComponent();
            this.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            this.pen = new Pen(Color.Black, 5);
            Init.pen = this.pen;
            Init.bitmap = this.bitmap;
            Init.pictureBox = this.pictureBox1;
            textBoxInputString.Text = "E(x;20;30;30;40)";
            Ellipse.pictureBox = this.pictureBox1;
        }
        private bool IsNotOperation(char item)
        {
            if (!(item == 'M' || item == 'E' || item == 'D' || item == ';' || item == '(' || item == ')'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int ConvertCharToInt(object item)
        {
            return Convert.ToInt32(Convert.ToString(item));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Hide();
            form.Show();
        }
        private void SelectingPerformingOperation(Operator op)
        {
            if (op.symbolOperator == 'E')
            {
                this.figure = new Ellipse(Convert.ToInt32(Convert.ToString(operands.Pop().value)), Convert.ToInt32(Convert.ToString(operands.Pop().value)), Convert.ToInt32(Convert.ToString(operands.Pop().value)), Convert.ToInt32(Convert.ToString(operands.Pop().value)), Convert.ToString(operands.Pop().value));
                op = new Operator(this.figure.Draw, 'E');
                ShapeContainer.AddFigure(figure);
                comboBox1.Items.Add(figure.name);
                op.operatorMethod();
            }
            else if (op.symbolOperator == 'M')
            {
                int[] offset = new int[2] 
                { 
                    Convert.ToInt32(Convert.ToString(operands.Pop().value)), 
                    Convert.ToInt32(Convert.ToString(operands.Pop().value)) 
                };
                this.figure = ShapeContainer.FindFigure(Convert.ToString(operands.Pop().value));
                op = new Operator(this.figure.MoveTo, 'M');
                op.binaryOperator(offset[0], offset[1]);
            }
            else if (op.symbolOperator == 'D')
            {
                this.figure = ShapeContainer.FindFigure(Convert.ToString(operands.Pop().value));
                op = new Operator(this.figure.DeleteF, 'D');
                op.binaryOperator1(this.figure, true);
            }
        }
        private void textBoxInputString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool flag = true;
                for (int i = 0; i < textBoxInputString.Text.Length; i++)
                {
                    if (IsNotOperation(textBoxInputString.Text[i]))
                    {
                        if (!(Char.IsDigit(textBoxInputString.Text[i])))
                        {
                            this.operands.Push(new Operand(textBoxInputString.Text[i]));
                            continue;
                        }
                        else if (Char.IsDigit(textBoxInputString.Text[i]))
                        {
                            if (Char.IsDigit(textBoxInputString.Text[i + 1]))
                            {
                                if (flag)
                                {
                                    this.operands.Push(new Operand(textBoxInputString.Text[i]));
                                }
                                this.operands.Push(new Operand(ConvertCharToInt(this.operands.Pop().value) * 10 + ConvertCharToInt(textBoxInputString.Text[i + 1])));
                                flag = false;
                                continue;
                            }
                            else if ((textBoxInputString.Text[i + 1] == ';' || textBoxInputString.Text[i + 1] == ')') && !(Char.IsDigit(textBoxInputString.Text[i - 1])))
                            {
                                this.operands.Push(new Operand(ConvertCharToInt(textBoxInputString.Text[i])));
                                continue;
                            }
                        }
                    }
                    else if (textBoxInputString.Text[i] == 'E' || textBoxInputString.Text[i] == 'D' || textBoxInputString.Text[i] == 'M')
                    {
                        if (this.operators.Count == 0)
                        {
                            this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                        }
                    }
                    else if (textBoxInputString.Text[i] == ';')
                    {
                        flag = true;
                        continue;
                        //не добавляем в стек операторов
                    }
                    else if (textBoxInputString.Text[i] == '(')
                    {
                        this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                    }
                    else if (textBoxInputString.Text[i] == ')')
                    {
                        do
                        {
                            if (operators.Peek().symbolOperator == '(')
                            {
                                operators.Pop();
                                break;
                            }
                            else
                            {
                                outputString += operators.Peek().symbolOperator;
                            }
                            if (operators.Count == 0)
                            {
                                break;
                            }
                        }
                        while (operators.Peek().symbolOperator != '(');
                    }
                }

                if (operators.Peek() != null)
                {
                    this.SelectingPerformingOperation(operators.Peek());
                }
                else
                {
                    MessageBox.Show("Введенной операции не существует");
                }
                this.operands.Clear();
                this.operators.Clear();
            }
        }
    }
}
