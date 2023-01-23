using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad_2
{
    public partial class Form1 : Form
    {

        Bitmap bmp;
        Graphics g;
        SolidBrush brush = new SolidBrush(Color.Blue);

        PointF a, b, c, d;

        PointF[] square = new PointF[4];
        PointF[] rotSquare = new PointF[4];
        float hHeight, hWidth;
       

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g = Graphics.FromImage(bmp);
            PCT_CANVAS.Image = bmp;

            hWidth = PCT_CANVAS.Width / 2f;
            hHeight = PCT_CANVAS.Height / 2f;

            a = new PointF(hWidth - hWidth, hHeight);
            b = new PointF(hWidth + hWidth, hHeight);
            c = new PointF(hWidth, hHeight - hHeight);
            d = new PointF(hWidth, hHeight + hHeight);

            g.DrawLine(Pens.Gray, a, b);
            g.DrawLine(Pens.Gray, c, d);

            PCT_CANVAS.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            DefaultSquare();
        }

        private void ResetBTN_Click(object sender, EventArgs e)
        {
            ResetBTN.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            hWidth = PCT_CANVAS.Width / 2f;
            hHeight = PCT_CANVAS.Height / 2f;

            clear();
            DefaultSquare();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                textBox1.Enabled = false;
                textBox3.Enabled = false;
                clear();

                Double angle = (double.Parse(textBox2.Text) * Math.PI) / 180;

                square[0] = new PointF(hWidth - 25, hHeight + 25);
                square[1] = new PointF(hWidth + 25, hHeight + 25);
                square[2] = new PointF(hWidth + 25, hHeight - 25);
                square[3] = new PointF(hWidth - 25, hHeight - 25);

                Rotate(angle);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                clear();

                hWidth = (PCT_CANVAS.Width / 2f) + 25;
                hHeight = (PCT_CANVAS.Height / 2f) - 25;

                Double angle = (double.Parse(textBox3.Text) * Math.PI) / 180;

                Rotate(angle);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                textBox3.Enabled = false;
                textBox2.Enabled = false;
                clear();

                Double angle = (double.Parse(textBox1.Text)* Math.PI)/180;
                Rotate(angle);
            }
        }

        private void clear()
        {
            g.Clear(Color.Transparent);
            g.DrawLine(Pens.Gray, a, b);
            g.DrawLine(Pens.Gray, c, d);

            PCT_CANVAS.Refresh();
        }

        private void Rotate(Double angle)
        {
            ResetBTN.Enabled = true;

            rotSquare[0].X = hWidth + (float)(((square[0].X - hWidth) * Math.Cos(angle)) + (square[0].Y - hHeight) * Math.Sin(angle));
            rotSquare[0].Y = hHeight + (float)((-(square[0].X - hWidth) * Math.Sin(angle)) + (square[0].Y - hHeight) * Math.Cos(angle));
            rotSquare[1].X = hWidth + (float)(((square[1].X - hWidth) * Math.Cos(angle)) + (square[1].Y - hHeight) * Math.Sin(angle));
            rotSquare[1].Y = hHeight + (float)((-(square[1].X - hWidth) * Math.Sin(angle)) + (square[1].Y - hHeight) * Math.Cos(angle));
            rotSquare[2].X = hWidth + (float)(((square[2].X - hWidth) * Math.Cos(angle)) + (square[2].Y - hHeight) * Math.Sin(angle));
            rotSquare[2].Y = hHeight + (float)((-(square[2].X - hWidth) * Math.Sin(angle)) + (square[2].Y - hHeight) * Math.Cos(angle));
            rotSquare[3].X = hWidth + (float)(((square[3].X - hWidth) * Math.Cos(angle)) + (square[3].Y - hHeight) * Math.Sin(angle));
            rotSquare[3].Y = hHeight + (float)((-(square[3].X - hWidth) * Math.Sin(angle)) + (square[3].Y - hHeight) * Math.Cos(angle));

            g.DrawPolygon(Pens.Red, rotSquare);
            g.FillPolygon(brush, rotSquare);

            PCT_CANVAS.Refresh();
        }

        private void DefaultSquare()
        {
            square[0] = new PointF(hWidth, hHeight);
            square[1] = new PointF(hWidth + 50, hHeight);
            square[2] = new PointF(hWidth + 50, hHeight - 50);
            square[3] = new PointF(hWidth, hHeight - 50);

            g.DrawPolygon(Pens.Red, square);
            g.FillPolygon(brush, square);

            PCT_CANVAS.Refresh();
        }


    }
}
