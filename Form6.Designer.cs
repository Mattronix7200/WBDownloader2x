using CustomControls.RJControls;
using System.Windows.Forms;

namespace WBDownloader2
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            rjButton1 = new RJButton();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
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
            rjButton1.Location = new Point(404, 322);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(126, 27);
            rjButton1.TabIndex = 10;
            rjButton1.Text = "Zamknij okno";
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // label2
            // 
            label2.Location = new Point(91, 45);
            label2.Name = "label2";
            label2.Size = new Size(439, 267);
            label2.TabIndex = 9;
            label2.Text = resources.GetString("label2.Text");
            // 
            // label1
            // 
            label1.BackColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(542, 32);
            label1.TabIndex = 7;
            label1.Text = "   Informacje o programie";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.wbd_favicon;
            pictureBox1.Location = new Point(12, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(59, 75, 89);
            ClientSize = new Size(542, 360);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(rjButton1);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.Gainsboro;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(542, 360);
            MinimumSize = new Size(542, 360);
            Name = "Form6";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Informacje o programie";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RJButton rjButton1;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
    }
}