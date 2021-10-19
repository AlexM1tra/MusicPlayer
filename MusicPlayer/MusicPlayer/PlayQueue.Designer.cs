namespace MusicPlayer
{
    partial class PlayQueue
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
            this.components = new System.ComponentModel.Container();
            this.listboxQueue = new System.Windows.Forms.ListBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listboxQueue
            // 
            this.listboxQueue.ContextMenuStrip = this.contextMenu;
            this.listboxQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listboxQueue.FormattingEnabled = true;
            this.listboxQueue.ItemHeight = 18;
            this.listboxQueue.Location = new System.Drawing.Point(0, 0);
            this.listboxQueue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listboxQueue.Name = "listboxQueue";
            this.listboxQueue.Size = new System.Drawing.Size(332, 341);
            this.listboxQueue.TabIndex = 0;
            this.listboxQueue.SelectedIndexChanged += new System.EventHandler(this.listboxQueue_SelectedIndexChanged);
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuPlay,
            this.contextMenuRemove});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(124, 48);
            this.contextMenu.Text = "Remove";
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // contextMenuPlay
            // 
            this.contextMenuPlay.Name = "contextMenuPlay";
            this.contextMenuPlay.Size = new System.Drawing.Size(117, 22);
            this.contextMenuPlay.Text = "Play";
            this.contextMenuPlay.Click += new System.EventHandler(this.contextMenuPlay_Click);
            // 
            // contextMenuRemove
            // 
            this.contextMenuRemove.Name = "contextMenuRemove";
            this.contextMenuRemove.Size = new System.Drawing.Size(117, 22);
            this.contextMenuRemove.Text = "Remove";
            this.contextMenuRemove.Click += new System.EventHandler(this.contextMenuRemove_Click);
            // 
            // PlayQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listboxQueue);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PlayQueue";
            this.Size = new System.Drawing.Size(332, 341);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listboxQueue;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuPlay;
        private System.Windows.Forms.ToolStripMenuItem contextMenuRemove;
    }
}
