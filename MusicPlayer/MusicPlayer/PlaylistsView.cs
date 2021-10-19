using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace MusicPlayer
{
    public partial class PlaylistsView : UserControl
    {
        private Dictionary<string, List<string>> playlists;
        private const string NO_PLAYLISTS_MESSAGE = "No playlists to show!";
        public PlaylistsView()
        {
            InitializeComponent();
            this.playlists = readPlaylists();
            if (playlists == null)
            {
                playlists = new Dictionary<string, List<string>>();
                listboxPlaylists.Items.Add(NO_PLAYLISTS_MESSAGE);
                listboxPlaylists.Enabled = false;
                buttonPlay.Enabled = false;
                buttonShuffle.Enabled = false;
                buttonAdd.Enabled = false;
            } else
            {
                listboxPlaylists.Items.AddRange(playlists.Keys.ToArray());
                listboxPlaylists.SelectedIndex = 0;
            }
        }

        public void setPlayCallback(Action<List<string>, bool> callback)
        {
            buttonPlay.Click += new EventHandler((sender, e) => callback(this.playlists[listboxPlaylists.SelectedItem.ToString()], false));
            buttonShuffle.Click += new EventHandler((sender, e) => callback(this.playlists[listboxPlaylists.SelectedItem.ToString()], true));
            playQueue1.setPlayCallback(callback);
        }

        public void savePlaylists()
        {
            File.WriteAllText(@"playlists.json", JsonConvert.SerializeObject(this.playlists));
        }

        private Dictionary<string, List<string>> readPlaylists()
        {
            if (!File.Exists("playlists.json"))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(@"playlists.json"));
        }

        private void listboxPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxPlaylistName.Text = listboxPlaylists.SelectedItem.ToString();
            playQueue1.setSongs(this.playlists[listboxPlaylists.SelectedItem.ToString()]);
        }

        private void buttonNewPlaylist_Click(object sender, EventArgs e)
        {
            string playlistName = Input.Show("Please enter a name for the new playlist:");
            while (listboxPlaylists.Items.Contains(playlistName) || playlistName == "")
            {
                playlistName = Input.Show("Playlist already exists. Please try again:");
            }
            if (!listboxPlaylists.Enabled)
            {
                listboxPlaylists.Items.Clear();
            }
            this.playlists[playlistName] = new List<string>();
            listboxPlaylists.Items.Add(playlistName);
            listboxPlaylists.SelectedIndex = listboxPlaylists.Items.Count - 1;
            listboxPlaylists.Enabled = true;
            buttonPlay.Enabled = true;
            buttonShuffle.Enabled = true;
            buttonAdd.Enabled = true;
            textBoxPlaylistName.Text = playlistName;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> songs = MusicLibrary.Get().getAllSongs().Select((s) => MusicLibrary.onlyAlpha(s)).ToList();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(songs.ToArray());
            string newSong = Input.ShowWithAutoComplete("Search for a song to add:", collection);
            if (!songs.Contains(newSong))
            {
                MessageBox.Show("Could not find the requested song");
            } else if (this.playlists[listboxPlaylists.SelectedItem.ToString()].Contains(newSong))
            {
                MessageBox.Show("Playlist already contains that song");
            } else
            { 
                this.playlists[listboxPlaylists.SelectedItem.ToString()].Add(newSong);
                playQueue1.refreshList();
            }
        }
    }
}
