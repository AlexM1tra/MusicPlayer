using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class Album : UserControl
    {
        private string title;
        public string  Title() { return this.title; }

        private string artist;
        public string Artist() { return this.artist; }

        public Image AlbumArtwork() { return albumArt.BackgroundImage; }

        public Album(Image albumArtwork, string title, string artist)
        {
            InitializeComponent();
            albumArt.BackgroundImage = albumArtwork;
            albumTitle.Text = title;
            this.title = title;
            this.artist = artist;
            albumArt.Click += new EventHandler((object sender, EventArgs e) => this.OnClick(e));
            albumTitle.Click += new EventHandler((object sender, EventArgs e) => this.OnClick(e));
        }

        public void setClickHandler(Action<Album> handler)
        {
            this.Click += new EventHandler((object sender, EventArgs e) => handler(this));
        }
    }
}
