using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public List<brd> points = new List<brd>();
        

        public int x = 0, y = 0;
        public int step = 0;
        public int step1 = 0;
        public bool move = false;



        public class brd
        {
            public int step = 0;
            public int step1 = 0;
            public int r = 0;
            public int g = 0;
            public int b = 0;
            public int width = 0;
            public int x = 0;
            public int y = 0;
            public brd(int X, int Y)
            {
                Random rad = new Random();
                step = rad.Next(-10, 10);
                step1 = rad.Next(-10, 10);
                r = rad.Next() % 255;
                g = rad.Next() % 255;
                b = rad.Next() % 255;
                width = rad.Next(5, 15);
                x = X;
                y = Y;
            }

        }
        public static int k = 0;



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (move)
            {

                Graphics graph = e.Graphics;



                for (int i = 0; i < points.Count; i++)
                {
                    brd point = points.ElementAt(i);

                    Pen pen = new Pen(Color.FromArgb(point.r, point.g, point.b), point.width);

                    if ((i == points.Count - 1) && k == 0)
                        graph.DrawEllipse(pen, point.x, point.y, point.width, point.width);
                    else
                    {
                        if ((point.x + point.step) > pictureBox1.Width)
                        {

                            point.x = 0;

                        }
                        if ((point.y + point.step1) > pictureBox1.Height)
                        {
                            point.y = 0;

                        }
                        if ((point.x + point.step) < 0)
                        {
                            point.x = pictureBox1.Width;

                        }
                        if ((point.y + point.step1) < 0)
                        {
                            point.y = pictureBox1.Height;

                        }
                        point.x += point.step;
                        point.y += point.step1;

                        graph.DrawEllipse(pen, point.x, point.y, point.width, point.width);
                    }


                }

            }

        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            move = true;
            x = e.X;
            y = e.Y;
            brd el = new brd(x, y);
            points.Add(el);

            for (k = 0; k < 50; k++)
            {
                pictureBox1.Refresh();
                System.Threading.Thread.Sleep(65);
                Application.DoEvents();
            }

        }

    
    public Form1()
        {
            move = false;
            InitializeComponent();
        }
    }
}
