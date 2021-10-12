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
            this.panelControls = new System.Windows.Forms.Panel();
            this.panelControlsBottomBar = new System.Windows.Forms.Panel();
            this.panelControlsTopBar = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonLibrary = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelLibraryTopBar = new System.Windows.Forms.Panel();
            this.panelLibraryRightMenu = new System.Windows.Forms.Panel();
            this.panelLibraryAlbums = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.panelLibrary.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.panelControlsTopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(727, 411);
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
            this.panelLibrary.Location = new System.Drawing.Point(12, 59);
            this.panelLibrary.Name = "panelLibrary";
            this.panelLibrary.Size = new System.Drawing.Size(432, 253);
            this.panelLibrary.TabIndex = 1;
            // 
            // panelControls
            // 
            this.panelControls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControls.Controls.Add(this.panelControlsBottomBar);
            this.panelControls.Controls.Add(this.panelControlsTopBar);
            this.panelControls.Location = new System.Drawing.Point(480, 59);
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
            this.panelControlsTopBar.Size = new System.Drawing.Size(416, 35);
            this.panelControlsTopBar.TabIndex = 0;
            // 
            // buttonLibrary
            // 
            this.buttonLibrary.Location = new System.Drawing.Point(380, 3);
            this.buttonLibrary.Name = "buttonLibrary";
            this.buttonLibrary.Size = new System.Drawing.Size(33, 30);
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
            // panelLibraryTopBar
            // 
            this.panelLibraryTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLibraryTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelLibraryTopBar.Name = "panelLibraryTopBar";
            this.panelLibraryTopBar.Size = new System.Drawing.Size(432, 36);
            this.panelLibraryTopBar.TabIndex = 0;
            // 
            // panelLibraryRightMenu
            // 
            this.panelLibraryRightMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelLibraryRightMenu.Location = new System.Drawing.Point(317, 36);
            this.panelLibraryRightMenu.Name = "panelLibraryRightMenu";
            this.panelLibraryRightMenu.Size = new System.Drawing.Size(115, 217);
            this.panelLibraryRightMenu.TabIndex = 1;
            // 
            // panelLibraryAlbums
            // 
            this.panelLibraryAlbums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLibraryAlbums.Location = new System.Drawing.Point(0, 36);
            this.panelLibraryAlbums.Name = "panelLibraryAlbums";
            this.panelLibraryAlbums.Size = new System.Drawing.Size(317, 217);
            this.panelLibraryAlbums.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1030, 501);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelLibrary);
            this.Controls.Add(this.mediaPlayer);
            this.Name = "Form1";
            this.Text = "Music Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.panelLibrary.ResumeLayout(false);
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
    }
}

