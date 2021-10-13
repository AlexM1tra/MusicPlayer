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
            this.panelLibraryAlbums = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLibraryRightMenu = new System.Windows.Forms.Panel();
            this.panelLibraryTopBar = new System.Windows.Forms.Panel();
            this.buttonControls = new System.Windows.Forms.Button();
            this.panelControls = new System.Windows.Forms.Panel();
            this.panelControlsBottomBar = new System.Windows.Forms.Panel();
            this.panelControlsTopBar = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonLibrary = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listBoxMediaType = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.panelLibrary.SuspendLayout();
            this.panelLibraryRightMenu.SuspendLayout();
            this.panelLibraryTopBar.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.panelControlsTopBar.SuspendLayout();
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
            this.panelLibrary.Controls.Add(this.panelLibraryAlbums);
            this.panelLibrary.Controls.Add(this.panelLibraryRightMenu);
            this.panelLibrary.Controls.Add(this.panelLibraryTopBar);
            this.panelLibrary.Location = new System.Drawing.Point(12, 12);
            this.panelLibrary.Name = "panelLibrary";
            this.panelLibrary.Size = new System.Drawing.Size(432, 253);
            this.panelLibrary.TabIndex = 1;
            // 
            // panelLibraryAlbums
            // 
            this.panelLibraryAlbums.AutoScroll = true;
            this.panelLibraryAlbums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLibraryAlbums.Location = new System.Drawing.Point(0, 36);
            this.panelLibraryAlbums.Name = "panelLibraryAlbums";
            this.panelLibraryAlbums.Size = new System.Drawing.Size(317, 217);
            this.panelLibraryAlbums.TabIndex = 2;
            // 
            // panelLibraryRightMenu
            // 
            this.panelLibraryRightMenu.Controls.Add(this.listBoxMediaType);
            this.panelLibraryRightMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelLibraryRightMenu.Location = new System.Drawing.Point(317, 36);
            this.panelLibraryRightMenu.Name = "panelLibraryRightMenu";
            this.panelLibraryRightMenu.Size = new System.Drawing.Size(115, 217);
            this.panelLibraryRightMenu.TabIndex = 1;
            // 
            // panelLibraryTopBar
            // 
            this.panelLibraryTopBar.Controls.Add(this.buttonControls);
            this.panelLibraryTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLibraryTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelLibraryTopBar.Name = "panelLibraryTopBar";
            this.panelLibraryTopBar.Size = new System.Drawing.Size(432, 36);
            this.panelLibraryTopBar.TabIndex = 0;
            // 
            // buttonControls
            // 
            this.buttonControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonControls.Location = new System.Drawing.Point(396, 0);
            this.buttonControls.Name = "buttonControls";
            this.buttonControls.Size = new System.Drawing.Size(36, 36);
            this.buttonControls.TabIndex = 0;
            this.buttonControls.Text = "O";
            this.buttonControls.UseVisualStyleBackColor = true;
            this.buttonControls.Click += new System.EventHandler(this.buttonControls_Click);
            // 
            // panelControls
            // 
            this.panelControls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControls.Controls.Add(this.panelControlsBottomBar);
            this.panelControls.Controls.Add(this.panelControlsTopBar);
            this.panelControls.Location = new System.Drawing.Point(374, 274);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(418, 253);
            this.panelControls.TabIndex = 2;
            // 
            // panelControlsBottomBar
            // 
            this.panelControlsBottomBar.BackColor = System.Drawing.Color.Transparent;
            this.panelControlsBottomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControlsBottomBar.Location = new System.Drawing.Point(0, 216);
            this.panelControlsBottomBar.Name = "panelControlsBottomBar";
            this.panelControlsBottomBar.Size = new System.Drawing.Size(416, 35);
            this.panelControlsBottomBar.TabIndex = 1;
            // 
            // panelControlsTopBar
            // 
            this.panelControlsTopBar.BackColor = System.Drawing.Color.Transparent;
            this.panelControlsTopBar.Controls.Add(this.buttonLibrary);
            this.panelControlsTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlsTopBar.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelControlsTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelControlsTopBar.Name = "panelControlsTopBar";
            this.panelControlsTopBar.Size = new System.Drawing.Size(416, 38);
            this.panelControlsTopBar.TabIndex = 0;
            // 
            // buttonLibrary
            // 
            this.buttonLibrary.Location = new System.Drawing.Point(377, 3);
            this.buttonLibrary.Name = "buttonLibrary";
            this.buttonLibrary.Size = new System.Drawing.Size(36, 35);
            this.buttonLibrary.TabIndex = 0;
            this.buttonLibrary.Text = "+";
            this.buttonLibrary.UseVisualStyleBackColor = true;
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
            // listBoxMediaType
            // 
            this.listBoxMediaType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxMediaType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMediaType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMediaType.FormattingEnabled = true;
            this.listBoxMediaType.ItemHeight = 20;
            this.listBoxMediaType.Items.AddRange(new object[] {
            "Artists",
            "Albums",
            "Songs",
            "Playlists"});
            this.listBoxMediaType.Location = new System.Drawing.Point(0, 0);
            this.listBoxMediaType.Name = "listBoxMediaType";
            this.listBoxMediaType.Size = new System.Drawing.Size(115, 217);
            this.listBoxMediaType.TabIndex = 3;
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
            this.Name = "Form1";
            this.Text = "Music Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.panelLibrary.ResumeLayout(false);
            this.panelLibraryRightMenu.ResumeLayout(false);
            this.panelLibraryTopBar.ResumeLayout(false);
            this.panelControls.ResumeLayout(false);
            this.panelControlsTopBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.Panel panelLibrary;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelControlsBottomBar;
        private System.Windows.Forms.FlowLayoutPanel panelControlsTopBar;
        private System.Windows.Forms.Button buttonLibrary;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel panelLibraryAlbums;
        private System.Windows.Forms.Panel panelLibraryRightMenu;
        private System.Windows.Forms.Panel panelLibraryTopBar;
        private System.Windows.Forms.Button buttonControls;
        private System.Windows.Forms.ListBox listBoxMediaType;
    }
}

