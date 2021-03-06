namespace MusicPlayer
{
    partial class AlbumInfo
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelAlbumPlayControls = new System.Windows.Forms.Panel();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.albumCover = new System.Windows.Forms.PictureBox();
            this.listBoxSongs = new System.Windows.Forms.ListBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.panelHeader.SuspendLayout();
            this.panelAlbumPlayControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumCover)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.textBoxTitle);
            this.panelHeader.Controls.Add(this.panelAlbumPlayControls);
            this.panelHeader.Controls.Add(this.albumCover);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(202, 65);
            this.panelHeader.TabIndex = 1;
            // 
            // panelAlbumPlayControls
            // 
            this.panelAlbumPlayControls.Controls.Add(this.buttonShuffle);
            this.panelAlbumPlayControls.Controls.Add(this.buttonPlay);
            this.panelAlbumPlayControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAlbumPlayControls.Location = new System.Drawing.Point(166, 0);
            this.panelAlbumPlayControls.Name = "panelAlbumPlayControls";
            this.panelAlbumPlayControls.Size = new System.Drawing.Size(36, 65);
            this.panelAlbumPlayControls.TabIndex = 1;
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.BackgroundImage = global::MusicPlayer.Properties.Resources.shuffle_icon;
            this.buttonShuffle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonShuffle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonShuffle.FlatAppearance.BorderSize = 0;
            this.buttonShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShuffle.Location = new System.Drawing.Point(0, 33);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(36, 32);
            this.buttonShuffle.TabIndex = 1;
            this.buttonShuffle.UseVisualStyleBackColor = true;
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackgroundImage = global::MusicPlayer.Properties.Resources.play_icon;
            this.buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPlay.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPlay.FlatAppearance.BorderSize = 0;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Location = new System.Drawing.Point(0, 0);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(36, 32);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // albumCover
            // 
            this.albumCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.albumCover.Dock = System.Windows.Forms.DockStyle.Left;
            this.albumCover.Location = new System.Drawing.Point(0, 0);
            this.albumCover.Name = "albumCover";
            this.albumCover.Size = new System.Drawing.Size(60, 65);
            this.albumCover.TabIndex = 0;
            this.albumCover.TabStop = false;
            // 
            // listBoxSongs
            // 
            this.listBoxSongs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxSongs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSongs.FormattingEnabled = true;
            this.listBoxSongs.ItemHeight = 16;
            this.listBoxSongs.Location = new System.Drawing.Point(0, 65);
            this.listBoxSongs.Name = "listBoxSongs";
            this.listBoxSongs.Size = new System.Drawing.Size(202, 174);
            this.listBoxSongs.TabIndex = 2;
            this.listBoxSongs.SelectedIndexChanged += new System.EventHandler(this.listBoxSongs_SelectedIndexChanged);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(60, 0);
            this.textBoxTitle.Multiline = true;
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(106, 65);
            this.textBoxTitle.TabIndex = 2;
            // 
            // AlbumInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.listBoxSongs);
            this.Controls.Add(this.panelHeader);
            this.Name = "AlbumInfo";
            this.Size = new System.Drawing.Size(202, 239);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelAlbumPlayControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.albumCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox albumCover;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelAlbumPlayControls;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.ListBox listBoxSongs;
        private System.Windows.Forms.TextBox textBoxTitle;
    }
}
