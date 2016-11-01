using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class PoolBase : Form
    {
        public LoginBase login = null;
        BufferedGraphicsContext currentContext;
        BufferedGraphics gBuffer;
        public static Graphics g;
        public static double power = 500;
        public static double fr = 0.8;
        public bool poolAnimation;
        class Ball // define a ball with a position, color and have painter self to draw
        {
            public double x;
            public double y;
            public double r;
            public double angle;
            public double[] triFunc;
            public double speed;
            public Color color;
            SolidBrush br;
            Pen pe;
            public Ball(int x_i, int y_i, int r_i, Color color_i)
            {
                x = x_i;
                y = y_i;
                r = r_i;
                angle = 0;
                triFunc = new double[2] { 0, 0};
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
            public void collideInterrupt(CuePole hitter, double spdHit) // cue to ball
            {
                angle = hitter.angle;
                triFunc[0] = Math.Cos(angle);
                triFunc[1] = Math.Sin(angle);
                speed = spdHit/40;
            }
            public void collideInterrupt(Rectangle poolPanelRec) // wall to ball
            {
                if (x < r || x > poolPanelRec.Width - r)
                {
                    angle = Math.PI - angle;
                    x = (x < r) ? (-x + 2 * r) : (-x + 2 * (poolPanelRec.Width - r));
                    triFunc[0] = Math.Cos(angle);
                    triFunc[1] = Math.Sin(angle);
                }
                if (y < r || y > poolPanelRec.Height - r)
                {
                    angle = -angle;
                    y = (y < r) ? (-y + 2 * r) : (-y + 2 * (poolPanelRec.Height - r));
                    triFunc[0] = Math.Cos(angle);
                    triFunc[1] = Math.Sin(angle);
                }
            }
            public void collideInterrupt(Ball another) // ball to ball
            {

            }
            public void animation(Rectangle poolPanelRec)
            {
                x = x - speed * triFunc[0];
                y = y - speed * triFunc[1];
                speed -= fr;
                collideInterrupt(poolPanelRec);
                Console.WriteLine("x: " + x + ", y: " + y + ", angle: " + angle);
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
                double delta_x = ball.x - x;
                double delta_y = ball.y - y;
                return Math.Atan2(delta_y, delta_x);
            }
        }
        private Ball redBall = null;
        private Ball redBall_noBrush = null;
        private Ball whiteBall = null;
        private CuePole playerCue = null;
        private MousePoint myMouse = null;
        private Rectangle poolPanelRec = new Rectangle();
        public PoolBase()
        {
            InitializeComponent();
            currentContext = BufferedGraphicsManager.Current;
            gBuffer = currentContext.Allocate(this.poolPanel.CreateGraphics(), new Rectangle(0, 0, this.poolPanel.Width, this.poolPanel.Height));
            g = gBuffer.Graphics;
            poolAnimation = false;
            redBall = new Ball(30, 30, 10, Color.FromArgb(255, 255, 0, 0));
            redBall_noBrush = new Ball(100, 100, 10, Color.FromArgb(255, 255, 0, 0));
            whiteBall = new Ball(100, 100, 10, Color.FromArgb(255, 255, 255, 255));
            playerCue = new CuePole(1.5, 100, Color.FromArgb(255, 0, 0, 0));
            myMouse = new MousePoint(-1, -1);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            AllowTransparency = true;
            poolPanelRec = new Rectangle(0, 0, poolPanel.Width, poolPanel.Height);
            Color bgCover = Color.FromArgb(150, 255, 255, 255);
            this.poolBackPanel.BackColor = bgCover;
            powerLabel.Text = "施力：\n" + power;
            frictionLabel.Text = "摩擦力：" + fr;
        }

        private void PoolBase_Load(object sender, EventArgs e)
        {
            string account = login.accountName;
            poolBaseTitle.Text = "你好阿，旅行者" + account;
            AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void poolBackButton_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Close();
        }

        private void poolPanel_Paint(object sender, PaintEventArgs e)
        {
            g.Clear(poolPanel.BackColor);
            redBall_noBrush.setPos(poolPanel.Width / 2, poolPanel.Height / 2);
            redBall.draw();
            redBall_noBrush.draw_line();
            whiteBall.draw();
            if(!poolAnimation) playerCue.draw(whiteBall);
            myMouse.draw_line();
            gBuffer.Render(e.Graphics);
        }

        private void mouse_click(object sender, MouseEventArgs e)
        {
            myMouse.setPos(e.X, e.Y);
            playerCue.mouseClick_Angle(myMouse.angleFromBall(whiteBall));
            poolPanel.Refresh();
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            poolBackPanel.Width = ClientRectangle.Width + 10;
            poolBackPanel.Height = ClientRectangle.Height + 10;
        }

        private void cueFire_button_Click(object sender, EventArgs e)
        {
            playerCue.mouseClick_Angle(myMouse.angleFromBall(whiteBall));
            whiteBall.collideInterrupt(playerCue, power);
            poolAnimation = true;
            poolTimer.Enabled = true;
        }

        private void poolTimer_tick(object sender, EventArgs e)
        {
            whiteBall.animation(poolPanelRec);
            poolPanel.Refresh();
            if (whiteBall.speed <= 0)
            {
                poolTimer.Enabled = false;
                poolAnimation = false;
            }
            cueFire_button.Visible = !poolAnimation;
            timePause_button.Visible = poolAnimation;
            whiteBallValue.Text = "Spd: " + whiteBall.speed;
        }

        private void poolPause_Click(object sender, EventArgs e)
        {
            poolTimer.Enabled = (!poolTimer.Enabled & poolAnimation);
            timePause_button.Text = poolTimer.Enabled? "ポーズ" : "続けます";
        }

        private void powerScroll_Scroll(object sender, ScrollEventArgs e)
        {
            power = e.NewValue * 5;
            powerLabel.Text = "施力：\n" + power;
        }

        private void frictionScroll_Scroll(object sender, ScrollEventArgs e)
        {
            fr = e.NewValue / 50.0;
            frictionLabel.Text = "摩擦力：" + fr;
        }
    }
}
