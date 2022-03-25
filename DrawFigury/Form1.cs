using Figury;

namespace DrawFigury
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            this.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            this.pen = new Pen(Color.Black, 1);
            Init.bitmap = this.bitmap;
            Init.pictureBox = pictureBox1;
            Init.pen = this.pen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
            Init.pictureBox.Image = Init.bitmap;
            ShapeContainer.figures.Clear();
            comboBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointF[] tochkalar = new PointF[3];
            tochkalar[0].X = 390; tochkalar[0].Y = 10;
            tochkalar[1].X = 340; tochkalar[1].Y = 80;
            tochkalar[2].X = 440; tochkalar[2].Y = 80;
            Triugla Pika = new Triugla(tochkalar);
            Pika.Draw();
            ShapeContainer.AddFigure(Pika);
            Rectagnle Body = new Rectagnle(340, 80, 100, 300);
            Body.Draw();
            ShapeContainer.AddFigure(Body);
            Rectagnle Leftegg = new Rectagnle(240, 280, 100, 100);
            Leftegg.Draw();
            ShapeContainer.AddFigure(Leftegg);
            Rectagnle Rightegg = new Rectagnle(440, 280, 100, 100);
            Rightegg.Draw();
            ShapeContainer.AddFigure(Rightegg);
            Ellipse verhniyEllips = new Ellipse(365, 100, 50, 50);
            verhniyEllips.Draw();
            ShapeContainer.AddFigure(verhniyEllips);
            Ellipse nizhniyEllips = new Ellipse(365, 200, 50, 50);
            nizhniyEllips.Draw();
            ShapeContainer.AddFigure(nizhniyEllips);
            Ellipse leftEllipse = new Ellipse(340, 380, 33, 120);
            leftEllipse.Draw();
            ShapeContainer.AddFigure(leftEllipse);
            Ellipse sredniyEllipse = new Ellipse(373, 380, 33, 120);
            sredniyEllipse.Draw();
            ShapeContainer.AddFigure(sredniyEllipse);
            Ellipse rightEllipse = new Ellipse(406, 380, 33, 120);
            rightEllipse.Draw();
            ShapeContainer.AddFigure(rightEllipse);
            foreach (var figura in ShapeContainer.figures)
            {
                comboBox1.Items.Add(figura);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}