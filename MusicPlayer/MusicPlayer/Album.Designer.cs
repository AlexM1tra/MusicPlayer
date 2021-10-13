namespace MusicPlayer
{
    partial class Album
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.albumArt = new System.Windows.Forms.PictureBox();
            this.albumTitle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.albumArt)).BeginInit();
            this.SuspendLayout();
            // 
            // albumArt
            // 
            this.albumArt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.albumArt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.albumArt.Location = new System.Drawing.Point(5, 5);
            this.albumArt.Name = "albumArt";
            this.albumArt.Size = new System.Drawing.Size(140, 141);
            this.albumArt.TabIndex = 0;
            this.albumArt.TabStop = false;
            // 
            // albumTitle
            // 
            this.albumTitle.BackColor = System.Drawing.Color.White;
            this.albumTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.albumTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.albumTitle.Enabled = false;
            this.albumTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.albumTitle.Location = new System.Drawing.Point(5, 146);
            this.albumTitle.Name = "albumTitle";
            this.albumTitle.ReadOnly = true;
            this.albumTitle.Size = new System.Drawing.Size(140, 19);
            this.albumTitle.TabIndex = 1;
            this.albumTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Album
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.albumArt);
            this.Controls.Add(this.albumTitle);
            this.Name = "Album";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(150, 170);
            ((System.ComponentModel.ISupportInitialize)(this.albumArt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox albumArt;
        private System.Windows.Forms.TextBox albumTitle;
    }
}
