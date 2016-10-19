namespace WindowsFormsApplication1
{
    partial class LoginBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.backgroundCover = new System.Windows.Forms.Panel();
            this.accountTextBox = new wmgCMS.WaterMarkTextBox();
            this.passwordTextBox = new wmgCMS.WaterMarkTextBox();
            this.leaveButton = new System.Windows.Forms.Button();
            this.backgroundCover.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TitleLabel.Location = new System.Drawing.Point(190, 81);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(119, 33);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "歡迎使用";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.Transparent;
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loginButton.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.loginButton.Location = new System.Drawing.Point(49, 382);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(150, 30);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "登入";
            this.loginButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // backgroundCover
            // 
            this.backgroundCover.BackColor = System.Drawing.Color.Transparent;
            this.backgroundCover.Controls.Add(this.leaveButton);
            this.backgroundCover.Controls.Add(this.TitleLabel);
            this.backgroundCover.Controls.Add(this.accountTextBox);
            this.backgroundCover.Controls.Add(this.loginButton);
            this.backgroundCover.Controls.Add(this.passwordTextBox);
            this.backgroundCover.Location = new System.Drawing.Point(-16, 0);
            this.backgroundCover.Name = "backgroundCover";
            this.backgroundCover.Size = new System.Drawing.Size(504, 468);
            this.backgroundCover.TabIndex = 6;
            // 
            // accountTextBox
            // 
            this.accountTextBox.BackColor = System.Drawing.Color.White;
            this.accountTextBox.Location = new System.Drawing.Point(158, 153);
            this.accountTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.accountTextBox.Name = "accountTextBox";
            this.accountTextBox.Size = new System.Drawing.Size(197, 29);
            this.accountTextBox.TabIndex = 3;
            this.accountTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.accountTextBox.WaterMarkText = "請輸入帳號";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.White;
            this.passwordTextBox.Location = new System.Drawing.Point(157, 207);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(197, 29);
            this.passwordTextBox.TabIndex = 4;
            this.passwordTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.passwordTextBox.WaterMarkText = "請輸入密碼";
            // 
            // leaveButton
            // 
            this.leaveButton.Location = new System.Drawing.Point(303, 382);
            this.leaveButton.Name = "leaveButton";
            this.leaveButton.Size = new System.Drawing.Size(150, 30);
            this.leaveButton.TabIndex = 6;
            this.leaveButton.Text = "離開";
            this.leaveButton.UseVisualStyleBackColor = true;
            this.leaveButton.Click += new System.EventHandler(this.leaveButton_Click);
            // 
            // LoginBase
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.i3949422718;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.backgroundCover);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "LoginBase";
            this.Text = "歡迎使用撞球館";
            this.Load += new System.EventHandler(this.LoginBase_Load);
            this.backgroundCover.ResumeLayout(false);
            this.backgroundCover.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private wmgCMS.WaterMarkTextBox accountTextBox;
        private wmgCMS.WaterMarkTextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Panel backgroundCover;
        private System.Windows.Forms.Button leaveButton;
    }
}

