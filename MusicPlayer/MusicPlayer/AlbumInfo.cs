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
    public partial class AlbumInfo : UserControl
    {
        private List<string> songs;
        private Action<string> songCallback;
        private string albumId;
        /**
         * albumName: Name of the Album.
         * artistName: Name of the Artist.
         * songs: A list of song file paths.
         * songCallback: A callback which takes a filepath as a string parameter and runs when a single song is selected.
         * albumCallback: A callback which takes an album path as a string and a boolean denoting whether shuffle is enabled.
         * artwork: An Image for the album artwork.
         */
        public AlbumInfo(string albumName, 
            string artistName, 
            List<string> songs, 
            Action<string> songCallback, 
            Action<string, bool> albumCallback,
            Image artwork)
        {
            InitializeComponent();
            textBoxTitle.Text = albumName + Environment.NewLine + artistName;
            this.albumId = artistName + "\\" + albumName;
            this.songs = songs;
            foreach (string song in songs)
            {
                listBoxSongs.Items.Add(MusicLibrary.withoutPathOrExtension(song));
            }
            this.songCallback = songCallback;
            buttonPlay.Click += new EventHandler((object sender, EventArgs e) => albumCallback(albumId, false));
            buttonShuffle.Click += new EventHandler((object sender, EventArgs e) => albumCallback(albumId, true));
            listBoxSongs.DoubleClick += new EventHandler((sender, e) => songCallback(songs[listBoxSongs.SelectedIndex]));
            albumCover.BackgroundImage = artwork;
            setColours(new Bitmap(artwork).GetPixel(10, 10));
        }

        public string AlbumId() => albumId;

        public void setContextMenuStrip(ContextMenuStrip contextMenu)
        {
            listBoxSongs.ContextMenuStrip = contextMenu;
        }

        public string getSelectedSong()
        {
            if (listBoxSongs.SelectedIndex == -1)
            {
                return null;
            }
            return songs[listBoxSongs.SelectedIndex];
        }

        private void setColours(Color backColor)
        {
            if (backColor.A < 255)
            {
                this.ForeColor = Color.Black;
                listBoxSongs.ForeColor = Color.Black;
                textBoxTitle.ForeColor = Color.Black;
                buttonPlay.BackgroundImage = Properties.Resources.play_icon;
                buttonShuffle.BackgroundImage = Properties.Resources.shuffle_icon;
                return;
            }

            this.BackColor = backColor;
            listBoxSongs.BackColor = backColor;
            textBoxTitle.BackColor = backColor;
            if ((backColor.R * 0.299 + backColor.G * 0.587 + backColor.B * 0.114) > 186) {
                this.ForeColor = Color.Black;
                listBoxSongs.ForeColor = Color.Black;
                textBoxTitle.ForeColor = Color.Black;
                buttonPlay.BackgroundImage = Properties.Resources.play_icon;
                buttonShuffle.BackgroundImage = Properties.Resources.shuffle_icon;
            }
            else
            {
                this.ForeColor = Color.White;
                listBoxSongs.ForeColor = Color.White;
                textBoxTitle.ForeColor = Color.White;
                buttonPlay.BackgroundImage = Properties.Resources.play_icon_light;
                buttonShuffle.BackgroundImage = Properties.Resources.shuffle_icon_light;
            }
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
