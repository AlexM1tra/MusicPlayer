using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WMPLib;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        private readonly string LIBRARY_PATH = "Library\\";
        private Graphics g;
        private Pen pen;
        private Rectangle progressRect;
        private RoundButton playPauseButton;
        private Image currentBackground;
        private List<string> playQueue = new List<string>();
        private bool shouldPlayOnNextTick = false;

        public Form1()
        {
            InitializeComponent();
            panelControls.Paint += new PaintEventHandler(this.panelControls_Paint);
            mediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
            MusicLibrary.readLibrary(LIBRARY_PATH);
            Point center = new Point(panelControls.Width / 2, panelControls.Height / 2);
            int radius = Math.Min(panelControls.Width, panelControls.Height) * 4 / 14;
            Rectangle innerRect = new Rectangle(center.X - radius + 12, center.Y - radius + 12, (2*radius) - 24, (2*radius) - 24);

            // Initialise a round Play/Pause button
            this.playPauseButton = new RoundButton();
            playPauseButton.BackColor = Color.Transparent;
            playPauseButton.BackgroundImage = MusicPlayer.Properties.Resources.play_icon;
            playPauseButton.BackgroundImageLayout = ImageLayout.Zoom;
            playPauseButton.Tag = "Play"; // Set to play so that when clicked, we know to play and not pause.
            playPauseButton.Size = new Size(innerRect.Width - 4, innerRect.Height - 4);
            playPauseButton.Location = new Point(innerRect.X + 2, innerRect.Y + 2);
            playPauseButton.Click += new EventHandler(this.playPauseButton_Click);
            panelControls.Controls.Add(playPauseButton);

            populateLibrary();
            listBoxMediaType.SelectedIndex = 1; // Select Albums.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private string onlyAlpha(string text)
        {
            string output = "";
            foreach (char c in text)
            {
                if (!"0123456789".Contains(c.ToString()))
                {
                    output += c;
                }
            }
            return output.TrimStart();
        }

        private void populateLibrary()
        {
            List<Album> albums = MusicLibrary.Get().getAlbums();
            panelLibraryAlbums.Controls.Clear();
            foreach (Album album in albums)
            {
                album.setClickHandler(Album_Click);
                panelLibraryAlbums.Controls.Add(album);
            }
            List<string> songs = MusicLibrary.Get().getAllSongs();
            listBoxSongs.Items.AddRange(songs.ToArray());
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(songs.Select((s) => onlyAlpha(s)).ToArray());
            textBoxSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxSearch.AutoCompleteCustomSource = autoComplete;
        }

        public void Album_Click(Album album)
        {
            listBoxMediaType.Visible = true;
            string oldArtistAndAlbum = "";
            foreach (Control c in panelLibraryRightMenu.Controls)
            {
                if (c is AlbumInfo)
                {
                    oldArtistAndAlbum = ((AlbumInfo)c).AlbumId();
                    panelLibraryRightMenu.Controls.Remove(c);
                    break;
                }
            }
            if (oldArtistAndAlbum != album.Artist() + "\\" + album.Title())
            {
                AlbumInfo albumInfo = new AlbumInfo(album.Title(), album.Artist(), MusicLibrary.Get().getSongs(album.Artist(), album.Title()), playSong, playAlbum, album.AlbumArtwork());
                albumInfo.Dock = DockStyle.Fill;
                listBoxMediaType.Visible = false;
                panelLibraryRightMenu.Controls.Add(albumInfo);
            }
        }

        private void panelControls_Paint(object sender, PaintEventArgs e)
        {
            this.g = panelControls.CreateGraphics();
            this.g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.GammaCorrected;
            this.pen = new Pen(Color.FromArgb(24, Color.SlateGray), 20);
            Point center = new Point(panelControls.Width / 2, panelControls.Height / 2);
            int radius = Math.Min(panelControls.Width, panelControls.Height) * 4 / 14;
            int diameter = 2 * radius;
            this.progressRect = new Rectangle(center.X - radius, center.Y - radius, diameter, diameter);
        }

        private void drawBackground()
        {
            this.g.Clear(panelControls.BackColor);
            if (this.currentBackground != null)
            {
                Point backgroundPoint = new Point((panelControls.Width - this.currentBackground.Width) / 2, (panelControls.Height - this.currentBackground.Height) / 2);
                this.g.DrawImage(this.currentBackground, backgroundPoint);
                playPauseButton.Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.shouldPlayOnNextTick)
            {
                this.shouldPlayOnNextTick = false;
                mediaPlayer.Ctlcontrols.play();
            }
            if (mediaPlayer.Ctlcontrols.currentItem != null)
            {
                float angle = (float) (360 * mediaPlayer.Ctlcontrols.currentPosition / mediaPlayer.Ctlcontrols.currentItem.duration);
                if (!float.IsNaN(angle))
                {
                    this.g.DrawArc(this.pen, this.progressRect, -90, angle);
                }
            }
        }

        private void playSong(string filepath)
        {
            mediaPlayer.URL = filepath;
            Image albumArt = MusicPlayer.Properties.Resources.album_icon;
            var tfile = TagLib.File.Create(filepath);
            this.currentBackground = null;
            foreach (TagLib.IPicture img in tfile.Tag.Pictures)
            {
                if (img != null)
                {
                    currentBackground = ImageResizer.ResizeImage(Image.FromStream(new MemoryStream((byte[])(img.Data.Data))), panelControls.Width);
                }
            }
            panelLibrary.Visible = false;
            panelControls.Visible = true;
            drawBackground();
            mediaPlayer.Ctlcontrols.play();
        }

        private void playAlbum(string artistalbum, bool shouldShuffle)
        {
            this.playQueue = MusicLibrary.Get().getSongs(artistalbum.Split('\\')[0], artistalbum.Split('\\')[1]);
            this.playQueue.Reverse();
            if (shouldShuffle)
            {
                Random random = new Random();
                for (int i = this.playQueue.Count - 1; i > 0; i--)
                {
                    int swapIndex = random.Next(i + 1);
                    string temp = this.playQueue[i];
                    this.playQueue[i] = this.playQueue[swapIndex];
                    this.playQueue[swapIndex] = temp;
                }
            }
            string firstSong = playQueue[playQueue.Count - 1];
            playQueue.RemoveAt(playQueue.Count - 1);
            playSong(firstSong);
        }

        private void OnPlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 2) // Paused.
            {
                playPauseButton.BackgroundImage = MusicPlayer.Properties.Resources.play_icon;
                playPauseButton.Tag = "Play";
            }
            else if (e.newState == 3) // Playing.
            {
                playPauseButton.BackgroundImage = MusicPlayer.Properties.Resources.pause_icon;
                playPauseButton.Tag = "Pause";
            }
            else if (e.newState == 8 && playQueue.Count > 0) // 8 = Media Ended
            {
                string nextSong = playQueue[playQueue.Count - 1];
                playQueue.RemoveAt(playQueue.Count - 1);
                playSong(nextSong);
            }
            else if (e.newState == 10)
            {
                this.shouldPlayOnNextTick = true;
            }
        }

        private void playPauseButton_Click(object sender, EventArgs e)
        {
            if (playPauseButton.Tag.ToString() == "Play")
            {
                mediaPlayer.Ctlcontrols.play();
            } else
            {
                mediaPlayer.Ctlcontrols.pause();
            }
        }

        private void buttonLibrary_Click(object sender, EventArgs e)
        {
            panelControls.Visible = false;
            panelLibrary.Visible = true;
        }

        private void buttonControls_Click(object sender, EventArgs e)
        {
            panelLibrary.Visible = false;
            panelControls.Visible = true;
            drawBackground();
        }

        private void listBoxMediaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMediaType.SelectedIndex == 1)
            {
                listBoxSongs.Visible = false;
                panelLibraryAlbums.Visible = true;
            } else if (listBoxMediaType.SelectedIndex == 2)
            {
                panelLibraryAlbums.Visible = false;
                listBoxSongs.Visible = true;
            }
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            playSong(MusicLibrary.Get().getSongList()[listBoxSongs.SelectedIndex]);
        }
    }
}


/*
 * TODO:
 * Forward and Back buttons
 * Song Info
 * Remove Artist view
 * Set up playlists
 * Finish search
 * Idle mode
 * Fix white circle
 * /