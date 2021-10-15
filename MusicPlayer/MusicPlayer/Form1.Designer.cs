namespace MusicPlayer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.panelLibrary = new System.Windows.Forms.Panel();
            this.listBoxSongs = new System.Windows.Forms.ListBox();
            this.panelLibraryAlbums = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLibraryRightMenu = new System.Windows.Forms.Panel();
            this.listBoxMediaType = new System.Windows.Forms.ListBox();
            this.panelLibraryTopBar = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonControls = new System.Windows.Forms.Button();
            this.panelControls = new System.Windows.Forms.Panel();
            this.labelArtistAlbum = new System.Windows.Forms.Label();
            this.labelSongName = new System.Windows.Forms.Label();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonLibrary = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.panelLibrary.SuspendLayout();
            this.panelLibraryRightMenu.SuspendLayout();
            this.panelLibraryTopBar.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(12, 274);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(75, 27);
            this.mediaPlayer.TabIndex = 0;
            this.mediaPlayer.TabStop = false;
            this.mediaPlayer.Visible = false;
            // 
            // panelLibrary
            // 
            this.panelLibrary.Controls.Add(this.listBoxSongs);
            this.panelLibrary.Controls.Add(this.panelLibraryAlbums);
            this.panelLibrary.Controls.Add(this.panelLibraryRightMenu);
            this.panelLibrary.Controls.Add(this.panelLibraryTopBar);
            this.panelLibrary.Location = new System.Drawing.Point(2, 0);
            this.panelLibrary.Name = "panelLibrary";
            this.panelLibrary.Size = new System.Drawing.Size(432, 253);
            this.panelLibrary.TabIndex = 1;
            // 
            // listBoxSongs
            // 
            this.listBoxSongs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSongs.FormattingEnabled = true;
            this.listBoxSongs.Location = new System.Drawing.Point(0, 36);
            this.listBoxSongs.Name = "listBoxSongs";
            this.listBoxSongs.Size = new System.Drawing.Size(259, 217);
            this.listBoxSongs.TabIndex = 3;
            this.listBoxSongs.Visible = false;
            this.listBoxSongs.SelectedIndexChanged += new System.EventHandler(this.listBoxSongs_SelectedIndexChanged);
            // 
            // panelLibraryAlbums
            // 
            this.panelLibraryAlbums.AutoScroll = true;
            this.panelLibraryAlbums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLibraryAlbums.Location = new System.Drawing.Point(0, 36);
            this.panelLibraryAlbums.Name = "panelLibraryAlbums";
            this.panelLibraryAlbums.Size = new System.Drawing.Size(259, 217);
            this.panelLibraryAlbums.TabIndex = 2;
            // 
            // panelLibraryRightMenu
            // 
            this.panelLibraryRightMenu.Controls.Add(this.listBoxMediaType);
            this.panelLibraryRightMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelLibraryRightMenu.Location = new System.Drawing.Point(259, 36);
            this.panelLibraryRightMenu.Name = "panelLibraryRightMenu";
            this.panelLibraryRightMenu.Size = new System.Drawing.Size(173, 217);
            this.panelLibraryRightMenu.TabIndex = 1;
            // 
            // listBoxMediaType
            // 
            this.listBoxMediaType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxMediaType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMediaType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMediaType.FormattingEnabled = true;
            this.listBoxMediaType.ItemHeight = 20;
            this.listBoxMediaType.Items.AddRange(new object[] {
            "Playlists",
            "Albums",
            "Songs"});
            this.listBoxMediaType.Location = new System.Drawing.Point(0, 0);
            this.listBoxMediaType.Name = "listBoxMediaType";
            this.listBoxMediaType.Size = new System.Drawing.Size(173, 217);
            this.listBoxMediaType.TabIndex = 3;
            this.listBoxMediaType.SelectedIndexChanged += new System.EventHandler(this.listBoxMediaType_SelectedIndexChanged);
            // 
            // panelLibraryTopBar
            // 
            this.panelLibraryTopBar.Controls.Add(this.buttonSearch);
            this.panelLibraryTopBar.Controls.Add(this.textBoxSearch);
            this.panelLibraryTopBar.Controls.Add(this.buttonControls);
            this.panelLibraryTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLibraryTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelLibraryTopBar.Name = "panelLibraryTopBar";
            this.panelLibraryTopBar.Size = new System.Drawing.Size(432, 36);
            this.panelLibraryTopBar.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackgroundImage = global::MusicPlayer.Properties.Resources.search_icon;
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Location = new System.Drawing.Point(346, 8);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(20, 20);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(179, 4);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(161, 26);
            this.textBoxSearch.TabIndex = 1;
            // 
            // buttonControls
            // 
            this.buttonControls.BackgroundImage = global::MusicPlayer.Properties.Resources.controls_icon;
            this.buttonControls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonControls.FlatAppearance.BorderSize = 0;
            this.buttonControls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonControls.Location = new System.Drawing.Point(396, 0);
            this.buttonControls.Name = "buttonControls";
            this.buttonControls.Size = new System.Drawing.Size(36, 36);
            this.buttonControls.TabIndex = 0;
            this.buttonControls.UseVisualStyleBackColor = true;
            this.buttonControls.Click += new System.EventHandler(this.buttonControls_Click);
            // 
            // panelControls
            // 
            this.panelControls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControls.Controls.Add(this.labelArtistAlbum);
            this.panelControls.Controls.Add(this.labelSongName);
            this.panelControls.Controls.Add(this.buttonPrevious);
            this.panelControls.Controls.Add(this.buttonNext);
            this.panelControls.Controls.Add(this.buttonLibrary);
            this.panelControls.Location = new System.Drawing.Point(374, 259);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(418, 253);
            this.panelControls.TabIndex = 2;
            // 
            // labelArtistAlbum
            // 
            this.labelArtistAlbum.AutoSize = true;
            this.labelArtistAlbum.BackColor = System.Drawing.Color.Transparent;
            this.labelArtistAlbum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArtistAlbum.ForeColor = System.Drawing.Color.White;
            this.labelArtistAlbum.Location = new System.Drawing.Point(165, 190);
            this.labelArtistAlbum.Name = "labelArtistAlbum";
            this.labelArtistAlbum.Size = new System.Drawing.Size(104, 20);
            this.labelArtistAlbum.TabIndex = 4;
            this.labelArtistAlbum.Text = "Artist - Album";
            this.labelArtistAlbum.Visible = false;
            // 
            // labelSongName
            // 
            this.labelSongName.AutoSize = true;
            this.labelSongName.BackColor = System.Drawing.Color.Transparent;
            this.labelSongName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSongName.ForeColor = System.Drawing.Color.White;
            this.labelSongName.Location = new System.Drawing.Point(154, 165);
            this.labelSongName.Name = "labelSongName";
            this.labelSongName.Size = new System.Drawing.Size(124, 25);
            this.labelSongName.TabIndex = 3;
            this.labelSongName.Text = "Song Name";
            this.labelSongName.Visible = false;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.BackColor = System.Drawing.Color.Transparent;
            this.buttonPrevious.BackgroundImage = global::MusicPlayer.Properties.Resources.previous_track_icon_black;
            this.buttonPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPrevious.FlatAppearance.BorderSize = 0;
            this.buttonPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrevious.ForeColor = System.Drawing.Color.White;
            this.buttonPrevious.Location = new System.Drawing.Point(48, 86);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(75, 79);
            this.buttonPrevious.TabIndex = 2;
            this.buttonPrevious.UseVisualStyleBackColor = false;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.Color.Transparent;
            this.buttonNext.BackgroundImage = global::MusicPlayer.Properties.Resources.next_track_icon_black;
            this.buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.ForeColor = System.Drawing.Color.White;
            this.buttonNext.Location = new System.Drawing.Point(307, 86);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 79);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonLibrary
            // 
            this.buttonLibrary.BackColor = System.Drawing.Color.Transparent;
            this.buttonLibrary.BackgroundImage = global::MusicPlayer.Properties.Resources.library_icon;
            this.buttonLibrary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLibrary.FlatAppearance.BorderSize = 0;
            this.buttonLibrary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonLibrary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLibrary.Location = new System.Drawing.Point(371, 3);
            this.buttonLibrary.Name = "buttonLibrary";
            this.buttonLibrary.Size = new System.Drawing.Size(36, 35);
            this.buttonLibrary.TabIndex = 0;
            this.buttonLibrary.UseVisualStyleBackColor = false;
            this.buttonLibrary.Click += new System.EventHandler(this.buttonLibrary_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 486);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelLibrary);
            this.Controls.Add(this.mediaPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Music Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.panelLibrary.ResumeLayout(false);
            this.panelLibraryRightMenu.ResumeLayout(false);
            this.panelLibraryTopBar.ResumeLayout(false);
            this.panelLibraryTopBar.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.Panel panelLibrary;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonLibrary;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel panelLibraryAlbums;
        private System.Windows.Forms.Panel panelLibraryRightMenu;
        private System.Windows.Forms.Panel panelLibraryTopBar;
        private System.Windows.Forms.Button buttonControls;
        private System.Windows.Forms.ListBox listBoxMediaType;
        private System.Windows.Forms.ListBox listBoxSongs;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Label labelArtistAlbum;
        private System.Windows.Forms.Label labelSongName;
    }
}

