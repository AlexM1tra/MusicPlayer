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
    public partial class PlayQueue : UserControl
    {
        private List<string> songs;

        public PlayQueue()
        {
            InitializeComponent();
            this.songs = new List<string>();
        }

        public PlayQueue(List<string> songs)
        {
            InitializeComponent();
            this.songs = songs;
            listboxQueue.Items.AddRange(songs.ToArray());
        }

        public List<string> getSongs()
        {
            return this.songs;
        }

        public void setSongs(List<string> songs)
        {
            this.songs = songs;
            listboxQueue.Items.Clear();
            listboxQueue.Items.AddRange(songs.ToArray());
        }

        public void addSong(string song)
        {
            this.songs.Add(song);
            listboxQueue.Items.Add(song);
        }

        public void refreshList()
        {
            listboxQueue.Items.Clear();
            listboxQueue.Items.AddRange(songs.ToArray());
        }

        public void setPlayCallback(Action<List<string>, bool> callback)
        {
            contextMenuPlay.Click += new EventHandler(
                                            (sender, e) => callback(new List<string>() { this.songs[listboxQueue.SelectedIndex] }, false));
        }

        public void setSelectedIndex(int index)
        {
            if (index > 0 && index < listboxQueue.Items.Count)
            {
                listboxQueue.SelectedIndex = index;
            }
        }

        private void contextMenuPlay_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuRemove_Click(object sender, EventArgs e)
        {
            int index = listboxQueue.SelectedIndex;
            this.songs.RemoveAt(index);
            listboxQueue.Items.RemoveAt(index);
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (listboxQueue.SelectedIndex == -1)
            {
                e.Cancel = true;
            }
        }

        private void listboxQueue_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
