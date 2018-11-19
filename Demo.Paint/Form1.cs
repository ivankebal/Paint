using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.Paint
{
    public partial class Form1 : Form
    {
        private float[] _sin = new float[360];
        private float[] _cos = new float[360];

        public Form1()
        {
            for(int i=0; i<360; ++i)
            {
                _sin[i] = (float) Math.Sin(i * Math.PI / 360.0);
                _cos[i] = (float) Math.Cos(i * Math.PI / 360.0);
            }

            InitializeComponent();            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {           
            Graphics gr = e.Graphics;

            Point center = new Point(ClientSize.Width / 2, ClientSize.Height / 2);
            int ArrowLength = (ClientSize.Width > ClientSize.Height ?
                ClientSize.Height / 2 : ClientSize.Width / 2) - 10;

            int angle = DateTime.Now.Second * 6;
            gr.DrawLine(Pens.Red,
                center,
                new PointF {
                    X=center.X + ArrowLength * _cos[angle % 360],
                    Y = center.Y + ArrowLength * _sin[angle % 360],
                });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
