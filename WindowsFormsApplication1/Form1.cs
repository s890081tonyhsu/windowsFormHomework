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
    public partial class LoginBase : Form
    {
        public LoginBase()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.AllowTransparency = true;
            Color bgCover = Color.FromArgb(150, 255, 255, 255);
            this.backgroundCover.BackColor = bgCover;

        }
        public string accountName = "";

        private void loginButton_Click(object sender, EventArgs e)
        {
            string testAcc = "test", testPass = "test";
            try
            {
                if (!accountTextBox.Text.Equals(testAcc) || !passwordTextBox.Text.Equals(testPass)) MessageBox.Show("登入失敗");
                else
                {
                    PoolBase pool = new PoolBase();
                    this.accountName = accountTextBox.Text;
                    pool.login = this;
                    this.Hide();        /* 或 this.close(); */
                    pool.Show();
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void LoginBase_Load(object sender, EventArgs e)
        {
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
