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
        class Ball // define a ball with a position, color and have painter self to draw
        {
            public double x;
            public double y;
            public double r;
            public Color color;
            SolidBrush br;
            Pen pe;
            public Ball(int x_i, int y_i, int r_i, Color color_i)
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
        class CuePole // define a cue with a length, angle, but the start point is chosen by the ball or user point
        {
            public double angle;
            public double length;
            public Color color;
            Pen pen;
            public CuePole(double angle_i, int length_i, Color color_i)
            {
                angle = angle_i;
                length = length_i;
                color = color_i;
                pen = new Pen(color, 3);
            }
            public void draw(Ball ball)
            {
                Point start = new Point((Int32)(ball.x + ball.r * Math.Cos(angle)), (Int32)(ball.y + ball.r * Math.Sin(angle)));
                Point end = new Point((Int32)(ball.x + ball.r * Math.Cos(angle) + length * Math.Cos(angle)), (Int32)(ball.y + +ball.r * Math.Sin(angle) + length * Math.Sin(angle)));
                g.DrawLine(pen, start, end);
            }
            public void mouseClick_Angle(double ang)
            {
                angle = ang;
            }
        }
        class MousePoint
        {
            public double x;
            public double y;
            public Color color;
            SolidBrush br;
            Pen pe;
            public MousePoint(Int32 x_i, Int32 y_i)
            {
                x = x_i;
                y = y_i;
                color = Color.FromArgb(255, 242, 36, 36);
                br = new SolidBrush(color);
                pe = new Pen(br, 1);
            }
            public void setPos(double x_n, double y_n)
            {
                x = x_n;
                y = y_n;
            }
            public void draw_line()
            {
                g.DrawRectangle(pe, (Int32)(x-2), (Int32)(y-2), 5, 5);
            }
            public double angleFromBall(Ball ball)
            {
                double delta_x = x - ball.x;
                double delta_y = y - ball.y;
                return Math.Atan2(delta_y, delta_x);
            }
        }
        private Ball redBall = null;
        private Ball redBall_noBrush = null;
        private Ball whiteBall = null;
        private CuePole playerCue = null;
        private MousePoint myMouse = null;

        public PoolBase()
        {
            InitializeComponent();
            redBall = new Ball(30, 30, 10, Color.FromArgb(255, 255, 0, 0));
            redBall_noBrush = new Ball(100, 100, 10, Color.FromArgb(255, 255, 0, 0));
            whiteBall = new Ball(100, 100, 10, Color.FromArgb(255, 255, 255, 255));
            playerCue = new CuePole(1.5, 100, Color.FromArgb(255, 0, 0, 0));
            myMouse = new MousePoint(-1, -1);
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
            playerCue.draw(whiteBall);
            myMouse.draw_line();
        }

        private void mouse_click(object sender, MouseEventArgs e)
        {
            myMouse.setPos(e.X, e.Y);
            playerCue.mouseClick_Angle(myMouse.angleFromBall(whiteBall));
            angleValue.Text = myMouse.angleFromBall(whiteBall).ToString();
            poolPanel.Refresh();
        }
    }
}
