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
            this.poolPanel = new System.Windows.Forms.Panel();
            this.poolBaseTitle = new System.Windows.Forms.Label();
            this.poolBackButton = new System.Windows.Forms.Button();
            this.poolBackPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            // 
            // poolBaseTitle
            // 
            this.poolBaseTitle.AutoSize = true;
            this.poolBaseTitle.BackColor = System.Drawing.Color.Transparent;
            this.poolBaseTitle.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.poolBaseTitle.Location = new System.Drawing.Point(64, 24);
            this.poolBaseTitle.Name = "poolBaseTitle";
            this.poolBaseTitle.Size = new System.Drawing.Size(0, 31);
            this.poolBaseTitle.TabIndex = 1;
            // 
            // poolBackButton
            // 
            this.poolBackButton.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
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
            this.poolBackPanel.Controls.Add(this.pictureBox1);
            this.poolBackPanel.Controls.Add(this.poolPanel);
            this.poolBackPanel.Controls.Add(this.poolBaseTitle);
            this.poolBackPanel.Controls.Add(this.poolBackButton);
            this.poolBackPanel.Location = new System.Drawing.Point(0, 0);
            this.poolBackPanel.Name = "poolBackPanel";
            this.poolBackPanel.Size = new System.Drawing.Size(920, 512);
            this.poolBackPanel.TabIndex = 0;
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
            // PoolBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources._35239_hyperdimension_neptunia;
            this.ClientSize = new System.Drawing.Size(916, 504);
            this.Controls.Add(this.poolBackPanel);
            this.Name = "PoolBase";
            this.Text = "撞球館";
            this.Load += new System.EventHandler(this.PoolBase_Load);
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
    }
}