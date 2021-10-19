namespace MusicPlayer
{
    partial class PlaylistsView
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
            this.listboxPlaylists = new System.Windows.Forms.ListBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.textBoxPlaylistName = new System.Windows.Forms.TextBox();
            this.panelPlaylistControls = new System.Windows.Forms.Panel();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.panelPlaylistContent = new System.Windows.Forms.Panel();
            this.buttonNewPlaylist = new System.Windows.Forms.Button();
            this.panelLeftBar = new System.Windows.Forms.Panel();
            this.playQueue1 = new MusicPlayer.PlayQueue();
            this.panelHeader.SuspendLayout();
            this.panelPlaylistControls.SuspendLayout();
            this.panelPlaylistContent.SuspendLayout();
            this.panelLeftBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // listboxPlaylists
            // 
            this.listboxPlaylists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listboxPlaylists.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxPlaylists.FormattingEnabled = true;
            this.listboxPlaylists.ItemHeight = 20;
            this.listboxPlaylists.Location = new System.Drawing.Point(0, 0);
            this.listboxPlaylists.Name = "listboxPlaylists";
            this.listboxPlaylists.Size = new System.Drawing.Size(155, 264);
            this.listboxPlaylists.TabIndex = 0;
            this.listboxPlaylists.SelectedIndexChanged += new System.EventHandler(this.listboxPlaylists_SelectedIndexChanged);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.textBoxPlaylistName);
            this.panelHeader.Controls.Add(this.panelPlaylistControls);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(463, 51);
            this.panelHeader.TabIndex = 2;
            // 
            // textBoxPlaylistName
            // 
            this.textBoxPlaylistName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPlaylistName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPlaylistName.Enabled = false;
            this.textBoxPlaylistName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlaylistName.Location = new System.Drawing.Point(0, 0);
            this.textBoxPlaylistName.Name = "textBoxPlaylistName";
            this.textBoxPlaylistName.Size = new System.Drawing.Size(328, 28);
            this.textBoxPlaylistName.TabIndex = 0;
            this.textBoxPlaylistName.Text = "Select a Playlist";
            // 
            // panelPlaylistControls
            // 
            this.panelPlaylistControls.Controls.Add(this.buttonPlay);
            this.panelPlaylistControls.Controls.Add(this.buttonAdd);
            this.panelPlaylistControls.Controls.Add(this.buttonShuffle);
            this.panelPlaylistControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelPlaylistControls.Location = new System.Drawing.Point(328, 0);
            this.panelPlaylistControls.Name = "panelPlaylistControls";
            this.panelPlaylistControls.Size = new System.Drawing.Size(135, 51);
            this.panelPlaylistControls.TabIndex = 1;
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackgroundImage = global::MusicPlayer.Properties.Resources.play_icon;
            this.buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlay.FlatAppearance.BorderSize = 0;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Location = new System.Drawing.Point(40, 0);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(5);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(55, 51);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackgroundImage = global::MusicPlayer.Properties.Resources.plus_icon;
            this.buttonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Location = new System.Drawing.Point(0, 0);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(5);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(40, 51);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.BackgroundImage = global::MusicPlayer.Properties.Resources.shuffle_icon;
            this.buttonShuffle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonShuffle.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonShuffle.FlatAppearance.BorderSize = 0;
            this.buttonShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShuffle.Location = new System.Drawing.Point(95, 0);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(40, 51);
            this.buttonShuffle.TabIndex = 2;
            this.buttonShuffle.UseVisualStyleBackColor = true;
            // 
            // panelPlaylistContent
            // 
            this.panelPlaylistContent.Controls.Add(this.playQueue1);
            this.panelPlaylistContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlaylistContent.Location = new System.Drawing.Point(155, 51);
            this.panelPlaylistContent.Name = "panelPlaylistContent";
            this.panelPlaylistContent.Size = new System.Drawing.Size(308, 264);
            this.panelPlaylistContent.TabIndex = 3;
            // 
            // buttonNewPlaylist
            // 
            this.buttonNewPlaylist.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonNewPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewPlaylist.Location = new System.Drawing.Point(0, 235);
            this.buttonNewPlaylist.Name = "buttonNewPlaylist";
            this.buttonNewPlaylist.Size = new System.Drawing.Size(155, 29);
            this.buttonNewPlaylist.TabIndex = 4;
            this.buttonNewPlaylist.Text = "New Playlist";
            this.buttonNewPlaylist.UseVisualStyleBackColor = true;
            this.buttonNewPlaylist.Click += new System.EventHandler(this.buttonNewPlaylist_Click);
            // 
            // panelLeftBar
            // 
            this.panelLeftBar.Controls.Add(this.buttonNewPlaylist);
            this.panelLeftBar.Controls.Add(this.listboxPlaylists);
            this.panelLeftBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftBar.Location = new System.Drawing.Point(0, 51);
            this.panelLeftBar.Name = "panelLeftBar";
            this.panelLeftBar.Size = new System.Drawing.Size(155, 264);
            this.panelLeftBar.TabIndex = 5;
            // 
            // playQueue1
            // 
            this.playQueue1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playQueue1.Location = new System.Drawing.Point(0, 0);
            this.playQueue1.Name = "playQueue1";
            this.playQueue1.Size = new System.Drawing.Size(308, 264);
            this.playQueue1.TabIndex = 0;
            // 
            // PlaylistsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelPlaylistContent);
            this.Controls.Add(this.panelLeftBar);
            this.Controls.Add(this.panelHeader);
            this.Name = "PlaylistsView";
            this.Size = new System.Drawing.Size(463, 315);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelPlaylistControls.ResumeLayout(false);
            this.panelPlaylistContent.ResumeLayout(false);
            this.panelLeftBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listboxPlaylists;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelPlaylistControls;
        private System.Windows.Forms.TextBox textBoxPlaylistName;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Panel panelPlaylistContent;
        private System.Windows.Forms.Button buttonNewPlaylist;
        private System.Windows.Forms.Panel panelLeftBar;
        private PlayQueue playQueue1;
    }
}
