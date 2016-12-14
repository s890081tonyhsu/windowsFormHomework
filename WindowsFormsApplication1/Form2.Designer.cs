namespace WindowsFormsApplication1
{
    partial class PoolBase
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
            this.components = new System.ComponentModel.Container();
            this.poolPanel = new System.Windows.Forms.Panel();
            this.poolBaseTitle = new System.Windows.Forms.Label();
            this.poolBackButton = new System.Windows.Forms.Button();
            this.poolBackPanel = new System.Windows.Forms.Panel();
            this.poolClearLabel = new System.Windows.Forms.Label();
            this.ballCollideStop = new System.Windows.Forms.CheckBox();
            this.powerLabel = new System.Windows.Forms.Label();
            this.frictionLabel = new System.Windows.Forms.Label();
            this.frictionScroll = new System.Windows.Forms.HScrollBar();
            this.powerScroll = new System.Windows.Forms.VScrollBar();
            this.timePause_button = new System.Windows.Forms.Button();
            this.cueFire_button = new System.Windows.Forms.Button();
            this.timerTickLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.poolTimer = new System.Windows.Forms.Timer(this.components);
            this.poolBackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // poolPanel
            // 
            this.poolPanel.BackColor = System.Drawing.Color.Green;
            this.poolPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.poolPanel.Location = new System.Drawing.Point(16, 72);
            this.poolPanel.Name = "poolPanel";
            this.poolPanel.Size = new System.Drawing.Size(783, 384);
            this.poolPanel.TabIndex = 0;
            this.poolPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.poolPanel_Paint);
            this.poolPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouse_click);
            // 
            // poolBaseTitle
            // 
            this.poolBaseTitle.AutoSize = true;
            this.poolBaseTitle.BackColor = System.Drawing.Color.Transparent;
            this.poolBaseTitle.Font = new System.Drawing.Font("Microsoft JhengHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.poolBaseTitle.Location = new System.Drawing.Point(64, 24);
            this.poolBaseTitle.Name = "poolBaseTitle";
            this.poolBaseTitle.Size = new System.Drawing.Size(0, 31);
            this.poolBaseTitle.TabIndex = 1;
            // 
            // poolBackButton
            // 
            this.poolBackButton.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.poolBackButton.Location = new System.Drawing.Point(808, 16);
            this.poolBackButton.Name = "poolBackButton";
            this.poolBackButton.Size = new System.Drawing.Size(81, 34);
            this.poolBackButton.TabIndex = 2;
            this.poolBackButton.Text = "回首頁";
            this.poolBackButton.UseVisualStyleBackColor = true;
            this.poolBackButton.Click += new System.EventHandler(this.poolBackButton_Click);
            // 
            // poolBackPanel
            // 
            this.poolBackPanel.BackColor = System.Drawing.Color.Transparent;
            this.poolBackPanel.Controls.Add(this.poolClearLabel);
            this.poolBackPanel.Controls.Add(this.ballCollideStop);
            this.poolBackPanel.Controls.Add(this.powerLabel);
            this.poolBackPanel.Controls.Add(this.frictionLabel);
            this.poolBackPanel.Controls.Add(this.frictionScroll);
            this.poolBackPanel.Controls.Add(this.powerScroll);
            this.poolBackPanel.Controls.Add(this.timePause_button);
            this.poolBackPanel.Controls.Add(this.cueFire_button);
            this.poolBackPanel.Controls.Add(this.timerTickLabel);
            this.poolBackPanel.Controls.Add(this.pictureBox1);
            this.poolBackPanel.Controls.Add(this.poolPanel);
            this.poolBackPanel.Controls.Add(this.poolBaseTitle);
            this.poolBackPanel.Controls.Add(this.poolBackButton);
            this.poolBackPanel.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.poolBackPanel.Location = new System.Drawing.Point(0, 0);
            this.poolBackPanel.Name = "poolBackPanel";
            this.poolBackPanel.Size = new System.Drawing.Size(932, 539);
            this.poolBackPanel.TabIndex = 0;
            // 
            // poolClearLabel
            // 
            this.poolClearLabel.AutoSize = true;
            this.poolClearLabel.Location = new System.Drawing.Point(617, 31);
            this.poolClearLabel.Name = "poolClearLabel";
            this.poolClearLabel.Size = new System.Drawing.Size(51, 19);
            this.poolClearLabel.TabIndex = 12;
            this.poolClearLabel.Text = "label1";
            // 
            // ballCollideStop
            // 
            this.ballCollideStop.AutoSize = true;
            this.ballCollideStop.Location = new System.Drawing.Point(485, 475);
            this.ballCollideStop.Name = "ballCollideStop";
            this.ballCollideStop.Size = new System.Drawing.Size(103, 23);
            this.ballCollideStop.TabIndex = 11;
            this.ballCollideStop.Text = "撞球時停止";
            this.ballCollideStop.UseVisualStyleBackColor = true;
            this.ballCollideStop.CheckedChanged += new System.EventHandler(this.ballCollideStop_CheckedChanged);
            // 
            // powerLabel
            // 
            this.powerLabel.AutoSize = true;
            this.powerLabel.Location = new System.Drawing.Point(808, 72);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(54, 19);
            this.powerLabel.TabIndex = 10;
            this.powerLabel.Text = "施力：";
            // 
            // frictionLabel
            // 
            this.frictionLabel.AutoSize = true;
            this.frictionLabel.Location = new System.Drawing.Point(27, 505);
            this.frictionLabel.Name = "frictionLabel";
            this.frictionLabel.Size = new System.Drawing.Size(69, 19);
            this.frictionLabel.TabIndex = 9;
            this.frictionLabel.Text = "摩擦力：";
            // 
            // frictionScroll
            // 
            this.frictionScroll.Location = new System.Drawing.Point(16, 475);
            this.frictionScroll.Maximum = 159;
            this.frictionScroll.Minimum = 1;
            this.frictionScroll.Name = "frictionScroll";
            this.frictionScroll.Size = new System.Drawing.Size(459, 17);
            this.frictionScroll.TabIndex = 8;
            this.frictionScroll.Value = 40;
            this.frictionScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.frictionScroll_Scroll);
            // 
            // powerScroll
            // 
            this.powerScroll.Location = new System.Drawing.Point(869, 62);
            this.powerScroll.Maximum = 159;
            this.powerScroll.Minimum = 1;
            this.powerScroll.Name = "powerScroll";
            this.powerScroll.Size = new System.Drawing.Size(17, 459);
            this.powerScroll.TabIndex = 7;
            this.powerScroll.Value = 50;
            this.powerScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.powerScroll_Scroll);
            // 
            // timePause_button
            // 
            this.timePause_button.Location = new System.Drawing.Point(703, 470);
            this.timePause_button.Name = "timePause_button";
            this.timePause_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timePause_button.Size = new System.Drawing.Size(96, 31);
            this.timePause_button.TabIndex = 6;
            this.timePause_button.Text = "ポーズ";
            this.timePause_button.UseVisualStyleBackColor = true;
            this.timePause_button.Click += new System.EventHandler(this.poolPause_Click);
            // 
            // cueFire_button
            // 
            this.cueFire_button.Location = new System.Drawing.Point(596, 470);
            this.cueFire_button.Name = "cueFire_button";
            this.cueFire_button.Size = new System.Drawing.Size(96, 31);
            this.cueFire_button.TabIndex = 5;
            this.cueFire_button.Text = "はっしゃ";
            this.cueFire_button.UseVisualStyleBackColor = true;
            this.cueFire_button.Click += new System.EventHandler(this.cueFire_button_Click);
            // 
            // timerTickLabel
            // 
            this.timerTickLabel.AutoSize = true;
            this.timerTickLabel.Location = new System.Drawing.Point(481, 31);
            this.timerTickLabel.Name = "timerTickLabel";
            this.timerTickLabel.Size = new System.Drawing.Size(51, 19);
            this.timerTickLabel.TabIndex = 4;
            this.timerTickLabel.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources._1f600;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(31, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 26);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // poolTimer
            // 
            this.poolTimer.Interval = 8;
            this.poolTimer.Tick += new System.EventHandler(this.poolTimer_tick);
            // 
            // PoolBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources._35239_hyperdimension_neptunia;
            this.ClientSize = new System.Drawing.Size(927, 533);
            this.Controls.Add(this.poolBackPanel);
            this.Name = "PoolBase";
            this.Text = "撞球館";
            this.Load += new System.EventHandler(this.PoolBase_Load);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.poolBackPanel.ResumeLayout(false);
            this.poolBackPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel poolPanel;
        private System.Windows.Forms.Label poolBaseTitle;
        private System.Windows.Forms.Button poolBackButton;
        private System.Windows.Forms.Panel poolBackPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label timerTickLabel;
        private System.Windows.Forms.Button cueFire_button;
        private System.Windows.Forms.Timer poolTimer;
        private System.Windows.Forms.Button timePause_button;
        private System.Windows.Forms.HScrollBar frictionScroll;
        private System.Windows.Forms.VScrollBar powerScroll;
        private System.Windows.Forms.Label frictionLabel;
        private System.Windows.Forms.Label powerLabel;
        private System.Windows.Forms.CheckBox ballCollideStop;
        private System.Windows.Forms.Label poolClearLabel;
    }
}