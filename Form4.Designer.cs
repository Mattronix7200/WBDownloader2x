using CustomControls.RJControls;

namespace WBDownloader2
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            rjButton1 = new RJButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Location = new Point(108, 62);
            label2.Name = "label2";
            label2.Size = new Size(422, 152);
            label2.TabIndex = 5;
            label2.Text = resources.GetString("label2.Text");
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.close;
            pictureBox1.Location = new Point(23, 62);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(542, 32);
            label1.TabIndex = 3;
            label1.Text = "   Błąd podczas uruchamiania modułu lub aplikacji";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.CornflowerBlue;
            rjButton1.BackgroundColor = Color.CornflowerBlue;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 0;
            rjButton1.BorderSize = 0;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.ForeColor = Color.White;
            rjButton1.Location = new Point(108, 220);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(126, 27);
            rjButton1.TabIndex = 6;
            rjButton1.Text = "OK";
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(59, 75, 89);
            ClientSize = new Size(542, 280);
            ControlBox = false;
            Controls.Add(rjButton1);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            ForeColor = Color.Gainsboro;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(542, 280);
            MinimumSize = new Size(542, 280);
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Błąd";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private RJButton rjButton1;
    }
}