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
        private Stack<Operator> operators = new Stack<Operator>();
        private Stack<Operand> operands = new Stack<Operand>();
        public Form2()
        {
            InitializeComponent();
            for (int i = 0; i < textBoxInputString.Text.Length;i++)
            {
                if (IsNotOperation(textBoxInputString.Text[i]))
                {
                    private bool IsNotOperation(char item)
                    {
                        if (!(item == 'R' || item == 'M' || item == 'E' || item == 'C' || item == 'S' || item == ',' || item == '(' || item == ')'))
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }


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
    }
}
