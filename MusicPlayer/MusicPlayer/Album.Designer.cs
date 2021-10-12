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
            this.albumPicture = new System.Windows.Forms.PictureBox();
            this.albumName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.albumPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // albumPicture
            // 
            this.albumPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.albumPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.albumPicture.Location = new System.Drawing.Point(0, 0);
            this.albumPicture.Name = "albumPicture";
            this.albumPicture.Size = new System.Drawing.Size(150, 150);
            this.albumPicture.TabIndex = 0;
            this.albumPicture.TabStop = false;
            // 
            // albumName
            // 
            this.albumName.AutoSize = true;
            this.albumName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.albumName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.albumName.Location = new System.Drawing.Point(0, 150);
            this.albumName.Name = "albumName";
            this.albumName.Size = new System.Drawing.Size(100, 20);
            this.albumName.TabIndex = 1;
            this.albumName.Text = "Album Name";
            // 
            // Album
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.albumPicture);
            this.Controls.Add(this.albumName);
            this.Name = "Album";
            this.Size = new System.Drawing.Size(150, 170);
            ((System.ComponentModel.ISupportInitialize)(this.albumPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox albumPicture;
        private System.Windows.Forms.Label albumName;
    }
}
