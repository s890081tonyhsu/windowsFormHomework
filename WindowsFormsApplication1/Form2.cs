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
        public static double power = 600;
        public static double fr = 0.4;
        public double d_pow_min = 0;
        public bool poolAnimation;
        public bool wantToDraw;
        public bool collideFlag;
        public int timerTickVal = 0;
        public int poolClearVal = 0;
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
            public bool display;
            Pen pe;
            public Ball(int x_i, int y_i, int r_i, Color color_i)
            {
                x = x_i;
                y = y_i;
                r = r_i;
                angle = 0;
                speed = 0;
                triFunc = new double[2] { 0, 0 };
                color = color_i;
                br = new SolidBrush(color);
                pe = new Pen(br, 3);
                display = true;
            }
            public void setPos(double x_n, double y_n)
            {
                x = x_n;
                y = y_n;
            }
            public void setAngleSpeed(double angle_n, double speed_n)
            {
                angle = angle_n;
                speed = speed_n;
                triFunc[0] = Math.Cos(angle);
                triFunc[1] = Math.Sin(angle);
            }
            public void draw()
            {
                if(!display) return;
                g.FillEllipse(br, (Int32)(x - r), (Int32)(y - r), (Int32)(r * 2), (Int32)(r * 2));
            }
            public void draw_line()
            {
                g.DrawEllipse(pe, (Int32)(x - r), (Int32)(y - r), (Int32)(r * 2), (Int32)(r * 2));
            }
            public void draw_collide_line(bool wantToDraw)
            {
                if (!wantToDraw) return;
                Pen pe = new Pen(Color.Orange, 1);
                Point start = new Point((Int32)(x), (Int32)(y));
                Point end = new Point((Int32)(x + r * Math.Cos(angle) - 10 * r * Math.Cos(angle)), (Int32)(y - 10 * r * Math.Sin(angle)));
                g.DrawLine(pe, start, end);
            }
            public void draw_bary_line(Ball another, bool wantToDraw)
            {
                if (!wantToDraw) return;
                Pen pe = new Pen(Color.Yellow, 1);
                Point start = new Point((Int32)(x), (Int32)(y));
                Point end = new Point((Int32)(x + 10 * (another.x - x)), (Int32)(y + 10 * (another.y - y)));
                g.DrawLine(pe, start, end);
            }
            public void collideInterrupt(CuePole hitter, double spdHit) // cue to ball
            {
                angle = hitter.angle;
                triFunc[0] = Math.Cos(angle);
                triFunc[1] = Math.Sin(angle);
                speed = spdHit / 40;
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
            public bool collideDetect(Ball another, double d_pow_min)
            {
                double d_pow = pow2(x - another.x) + pow2(y - another.y);
                if (d_pow < d_pow_min)
                {
                    // Console.WriteLine("Ball Collide Detected!!");
                    return true;
                }
                return false;
            }
            public void collideInterrupt(Ball another, bool collideFlag) // ball to ball
            {
                if (!collideFlag) return;
                double centroid_angle = Math.Atan2(another.y - y, another.x - x);
                double[] parallel_speed = new double[] { another.speed * Math.Cos(another.angle - centroid_angle), speed * Math.Cos(angle - centroid_angle) };
                double[] vertical_speed = new double[] { speed * Math.Sin(angle - centroid_angle), another.speed * Math.Sin(another.angle - centroid_angle) };
                // Console.WriteLine("Ball Collide Event!!");
                setAngleSpeed(centroid_angle + Math.Atan2(vertical_speed[0], parallel_speed[0]), Math.Sqrt(pow2(parallel_speed[0]) + pow2(vertical_speed[0])));
                another.setAngleSpeed((speed <= 0) ? centroid_angle : (centroid_angle + Math.Atan2(vertical_speed[1], parallel_speed[1])), Math.Sqrt(Math.Pow(parallel_speed[1], 2) + Math.Pow(vertical_speed[1], 2)));
                another.setPos(x + Math.Cos(centroid_angle) * 20, y + Math.Sin(centroid_angle) * 20);// hard fix for some ball sticks
            }
            public void animation(Rectangle poolPanelRec, string name)
            {
                if (speed >= 1)
                {
                    x = x - speed * triFunc[0];
                    y = y - speed * triFunc[1];
                    speed -= fr;
                    if (speed < 1) speed = 0; // stop the ball
                }
                else speed = 0; // stop the ball
                collideInterrupt(poolPanelRec);
                // Console.WriteLine("{0}=> x: {1}, y: {2}, angle: {3}, speed: {4}", name, x.ToString("f4"), y.ToString("f4"), angle.ToString("f4"), speed.ToString("f4"));
            }
            private double pow2(double d)
            {
                return d * d;
            }
        }
        class CollidePair // define a class for list, which can be a queue for ball collide
        {
            public Ball srcBall;
            public Ball tarBall;
            public CollidePair(Ball ball1, Ball ball2)
            {
                srcBall = ball1;
                tarBall = ball2;
            }
            public void draw_line(bool wantToDraw)
            {
                srcBall.draw_collide_line(wantToDraw);
                srcBall.draw_bary_line(tarBall, wantToDraw);
            }
            public void run_Interrupt(bool collideFlag)
            {
                srcBall.collideInterrupt(tarBall, collideFlag);
            }
        }
        class CuePole // define a cue with a Length, angle, but the start point is chosen by the ball or user point
        {
            public double angle;
            public double Length;
            public Color color;
            Pen pen;
            public CuePole(double angle_i, int Length_i, Color color_i)
            {
                angle = angle_i;
                Length = Length_i;
                color = color_i;
                pen = new Pen(color, 3);
            }
            public void draw(Ball ball)
            {
                Point start = new Point((Int32)(ball.x + ball.r * Math.Cos(angle)), (Int32)(ball.y + ball.r * Math.Sin(angle)));
                Point end = new Point((Int32)(ball.x + ball.r * Math.Cos(angle) + Length * Math.Cos(angle)), (Int32)(ball.y + +ball.r * Math.Sin(angle) + Length * Math.Sin(angle)));
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
                g.DrawRectangle(pe, (Int32)(x - 2), (Int32)(y - 2), 5, 5);
            }
            public double angleFromBall(Ball ball)
            {
                double delta_x = ball.x - x;
                double delta_y = ball.y - y;
                return Math.Atan2(delta_y, delta_x);
            }
        }
        private Ball[]              balls = new Ball[11];
        private List<CollidePair>   collideList = new List<CollidePair>();
        private CuePole             playerCue = null;
        private MousePoint          myMouse = null;
        private Rectangle           poolPanelRec = new Rectangle();
        public PoolBase()
        {
            InitializeComponent();
            currentContext = BufferedGraphicsManager.Current;
            gBuffer = currentContext.Allocate(this.poolPanel.CreateGraphics(), new Rectangle(0, 0, this.poolPanel.Width, this.poolPanel.Height));
            g = gBuffer.Graphics;
            poolAnimation = false;
            wantToDraw = false;
            collideFlag = false;
            d_pow_min = (double)(4 * 10 * 10);
            for(int i = 0; i < balls.Length; i++)
                balls[i] = new Ball(200+30*i, 200, 10, Color.FromArgb(255, (i * 100)%256, (i * 50)%256, (i * 25)%256));
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
            // AllocConsole();
        }

        // [DllImport("kernel32.dll", SetLastError = true)]
        // [return: MarshalAs(UnmanagedType.Bool)]
        // static extern bool AllocConsole();

        private void poolBackButton_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Close();
        }

        private void poolPanel_Paint(object sender, PaintEventArgs e)
        {
            poolClearVal += 1;
            g.Clear(poolPanel.BackColor);
            for(int i = 0; i < balls.Length; i++)
                balls[i].draw();
            if (collideFlag)
            {
                collideList.ForEach(delegate(CollidePair pair)
                {
                    pair.draw_line(wantToDraw);
                });
            }
            if (!poolAnimation) playerCue.draw(balls[10]);
            myMouse.draw_line();
            gBuffer.Render(e.Graphics);
        }

        private void mouse_click(object sender, MouseEventArgs e)
        {
            myMouse.setPos(e.X, e.Y);
            playerCue.mouseClick_Angle(myMouse.angleFromBall(balls[10]));
            poolPanel.Refresh();
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            poolBackPanel.Width = ClientRectangle.Width + 10;
            poolBackPanel.Height = ClientRectangle.Height + 10;
        }

        private void cueFire_button_Click(object sender, EventArgs e)
        {
            playerCue.mouseClick_Angle(myMouse.angleFromBall(balls[10]));
            balls[10].collideInterrupt(playerCue, power);
            poolAnimation = true;
            poolTimer.Enabled = true;
        }

        private void poolTimer_tick(object sender, EventArgs e)
        {
            timerTickVal += 1;
            double totalSpd = 0;
            // Console.Clear();
            for(int i = 0; i < balls.Length; i++)
            {
                balls[i].animation(poolPanelRec, String.Format("  {0}th", i));
                totalSpd += balls[i].speed;
            }
            for(int i = 0; i < balls.Length - 1; i++)
                for(int j = i+1; j < balls.Length; j++)
                    if (balls[i].collideDetect(balls[j], d_pow_min)) collideList.Add(new CollidePair(balls[i], balls[j]));
            collideFlag = collideList.Count != 0;
            poolPanel.Refresh();
            collideList.ForEach(delegate(CollidePair pair)
            {
                pair.run_Interrupt(collideFlag);
            });
            if (collideFlag & wantToDraw)
            {
                poolTimer.Enabled = false;
            }
            if (totalSpd <= 0)
            {
                poolTimer.Enabled = false;
                poolAnimation = false;
            }
            // cueFire_button.Visible = !poolAnimation;
            // timePause_button.Visible = poolAnimation;
            // timerTickLabel.Text = timerTickVal.ToString();
            // poolClearLabel.Text = poolClearVal.ToString();
            collideList.Clear();
        }

        private void poolPause_Click(object sender, EventArgs e)
        {
            poolTimer.Enabled = (!poolTimer.Enabled & poolAnimation);
            timePause_button.Text = poolTimer.Enabled ? "ポーズ" : "続けます";
        }

        private void powerScroll_Scroll(object sender, ScrollEventArgs e)
        {
            power = e.NewValue * 12;
            powerLabel.Text = "施力：\n" + power;
        }

        private void frictionScroll_Scroll(object sender, ScrollEventArgs e)
        {
            fr = e.NewValue / 100.0;
            frictionLabel.Text = "摩擦力：" + fr;
        }

        private void ballCollideStop_CheckedChanged(object sender, EventArgs e)
        {
            wantToDraw = ballCollideStop.Checked;
        }
    }
}
