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
            textBoxTitle.Text = albumName + "\n" + artistName;
            this.albumId = artistName + "\\" + albumName;
            this.songs = songs;
            foreach (string song in songs)
            {
                listBoxSongs.Items.Add(MusicLibrary.withoutPath(song));
            }
            this.songCallback = songCallback;
            buttonPlay.Click += new EventHandler((object sender, EventArgs e) => albumCallback(albumId, false));
            buttonShuffle.Click += new EventHandler((object sender, EventArgs e) => albumCallback(albumId, true));
            albumCover.BackgroundImage = artwork;
        }

        public string AlbumId() => albumId;

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.songCallback != null)
            {
                songCallback(songs[listBoxSongs.SelectedIndex]);
            }
        }
    }
}
