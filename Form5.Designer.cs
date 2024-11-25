using CustomControls.RJControls;
using System.Windows.Forms;

namespace WBDownloader2
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            rjButton1 = new RJButton();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
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
            rjButton1.Location = new Point(108, 203);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(126, 27);
            rjButton1.TabIndex = 10;
            rjButton1.Text = "OK";
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // label2
            // 
            label2.Location = new Point(108, 62);
            label2.Name = "label2";
            label2.Size = new Size(422, 130);
            label2.TabIndex = 9;
            label2.Text = resources.GetString("label2.Text");
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.minus;
            pictureBox1.Location = new Point(23, 62);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(542, 32);
            label1.TabIndex = 7;
            label1.Text = "   Nie znaleziono wskazanego folderu...";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(59, 75, 89);
            ClientSize = new Size(542, 250);
            ControlBox = false;
            Controls.Add(rjButton1);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            ForeColor = Color.Gainsboro;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(542, 250);
            MinimumSize = new Size(542, 250);
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Błąd";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RJButton rjButton1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
    }
}