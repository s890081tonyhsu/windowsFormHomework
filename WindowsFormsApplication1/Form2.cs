using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class PoolBase : Form
    {
        public LoginBase login = null;
        public static Graphics g;
        class ball
        {
            public double x;
            public double y;
            public double r;
            public Color color;
            SolidBrush br;
            Pen pe;
            public ball(int x_i, int y_i, int r_i, Color color_i)
            {
                x = x_i;
                y = y_i;
                r = r_i;
                color = color_i;
                br = new SolidBrush(color);
                pe = new Pen(br, 3);
            }
            public void setPos(double x_n, double y_n)
            {
                x = x_n;
                y = y_n;
            }
            public void draw()
            {
                g.FillEllipse(br, (Int32)(x - r), (Int32)(y - r), (Int32)(r * 2), (Int32)(r * 2));
            }
            public void draw_line()
            {

                g.DrawEllipse(pe, (Int32)(x - r), (Int32)(y - r), (Int32)(r * 2), (Int32)(r * 2));
            }
        }
        class cue_pole
        {
            public double angle;
            public double length;
            public Color color;
            Pen pen;
            public cue_pole(double angle_i, int length_i, Color color_i)
            {
                angle = angle_i;
                length = length_i;
                color = color_i;
                pen = new Pen(color, 3);
            }
            public void draw(Int32 x, Int32 y, Int32 r)
            {
                Point start = new Point((Int32)(x + r * Math.Cos(angle)), (Int32)(y + r * Math.Sin(angle)));
                Point end = new Point((Int32)(x + r * Math.Cos(angle) + length * Math.Cos(angle)), (Int32)(y + +r * Math.Sin(angle) + length * Math.Sin(angle)));
                g.DrawLine(pen, start, end);
            }
        }
        private ball redBall = null;
        private ball redBall_noBrush = null;
        private ball whiteBall = null;
        private cue_pole playerCue = null;

        public PoolBase()
        {
            InitializeComponent();
            redBall = new ball(30, 30, 10, Color.FromArgb(255, 255, 0, 0));
            redBall_noBrush = new ball(100, 100, 10, Color.FromArgb(255, 255, 0, 0));
            whiteBall = new ball(100, 100, 10, Color.FromArgb(255, 255, 255, 255));
            playerCue = new cue_pole(2, 100, Color.FromArgb(255, 0, 0, 0));
            this.DoubleBuffered = true;
            this.AllowTransparency = true;
            Color bgCover = Color.FromArgb(150, 255, 255, 255);
            
            this.poolBackPanel.BackColor = bgCover;
        }

        private void PoolBase_Load(object sender, EventArgs e)
        {
            string account = login.accountName;
            poolBaseTitle.Text = "你好阿，旅行者" + account;
            g = poolPanel.CreateGraphics();
        }

        private void poolBackButton_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Close();
        }

        private void poolPanel_Paint(object sender, PaintEventArgs e)
        {
            redBall_noBrush.setPos(poolPanel.Width / 2, poolPanel.Height / 2);
            redBall.draw();
            redBall_noBrush.draw_line();
            whiteBall.draw();
            playerCue.draw((Int32)whiteBall.x, (Int32)whiteBall.y, (Int32)whiteBall.r);

        }
    }
}
