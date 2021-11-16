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
        private Pen darkPen;
        private Pen lightPen;
        private Rectangle progressRect;
        private RoundButton playPauseButton;
        private Image currentBackground;
        private List<string> playQueue = new List<string>();
        private int playQueuePointer = -1;
        private bool shouldPlayOnNextTick = false;
        private bool playPauseIsLight = false;
        private bool nextButtonIsLight = false;
        private bool previousButtonIsLight = false;
        private bool songInfoIsLight = false;
        private bool libraryButtonIsLight = false;
        private Point lastMousePosition = new Point();
        private int timeIdle = 0;

        /*
         * Initialisation Methods.
         */
        public Form1()
        {
            InitializeComponent();
            panelControls.Paint += new PaintEventHandler(this.panelControls_Paint);
            panelControls.MouseDown += new MouseEventHandler(PanelControlsMouseDown);
            mediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
            playlistsView1.setPlayCallback(playPlaylist);
            this.FormClosing += new FormClosingEventHandler((sender, e) => playlistsView1.savePlaylists());

            MusicLibrary.readLibrary(LIBRARY_PATH);
            Point center = new Point(panelControls.Width / 2, panelControls.Height / 2);
            int radius = Math.Min(panelControls.Width, panelControls.Height) * 4 / 14;
            Rectangle innerRect = new Rectangle(center.X - radius + 12, center.Y - radius + 12, (2*radius) - 24, (2*radius) - 24);

            // Initialise a round Play/Pause button
            this.playPauseButton = new RoundButton();
            playPauseButton.BackColor = Color.Transparent;
            playPauseButton.BackgroundImage = Properties.Resources.play_icon;
            playPauseButton.BackgroundImageLayout = ImageLayout.Zoom;
            playPauseButton.Tag = "Play"; // Set to play so that when clicked, we know to play and not pause.
            playPauseButton.Size = new Size(innerRect.Width - 4, innerRect.Height - 4);
            playPauseButton.Location = new Point(innerRect.X + 2, innerRect.Y + 2);
            playPauseButton.Click += new EventHandler(this.playPauseButton_Click);
            panelControls.Controls.Add(playPauseButton);

            buttonNext.Height = this.playPauseButton.Height / 2;
            buttonNext.Width = buttonNext.Height;
            buttonNext.Top = this.playPauseButton.Top + buttonNext.Height / 2;
            buttonNext.Left = (int)(panelControls.Width * 0.75);

            buttonPrevious.Height = this.playPauseButton.Height / 2;
            buttonPrevious.Width = buttonNext.Height;
            buttonPrevious.Top = this.playPauseButton.Top + buttonNext.Height / 2;
            buttonPrevious.Left = panelControls.Width / 4 - buttonPrevious.Width;

            labelSongName.Top = center.Y + radius + 20;
            labelArtistAlbum.Top = labelSongName.Top + labelSongName.Height + 10;

            initialiseLibrary();
            listBoxMediaType.SelectedIndex = 1; // Select Albums.
            panelIdle.Left = 0;
            panelIdle.Top = 0;
            panelIdle.Width = this.Width;
            panelIdle.Height = this.Height;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void initialiseLibrary()
        {
            List<Album> albums = MusicLibrary.Get().getAlbums();
            panelLibraryAlbums.Controls.Clear();
            foreach (Album album in albums)
            {
                album.setClickHandler(Album_Click);
                panelLibraryAlbums.Controls.Add(album);
            }
            listBoxSongs.DoubleClick += new EventHandler(
                                                (sender, e) => playSong(MusicLibrary.Get().getSongList()[listBoxSongs.SelectedIndex]));
            listBoxSongs.ContextMenuStrip = contextMenuSongs;
            List<string> songs = MusicLibrary.Get().getAllSongs();
            listBoxSongs.Items.AddRange(songs.ToArray());
            listBoxSongs.Font = new Font("Microsoft Sans Serif", 10);
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(songs.Select((s) => MusicLibrary.onlyAlpha(s)).ToArray());
            textBoxSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxSearch.AutoCompleteCustomSource = autoComplete;
            textBoxSearch.KeyDown += new KeyEventHandler(OnSearchKeyDown);
        }

        /* 
         * Drawing related methods (excluding event listeners).
         */

        private void drawBackground()
        {
            this.g.Clear(panelControls.BackColor);
            if (this.currentBackground == null)
            {
                panelControls.BackgroundImageLayout = ImageLayout.Zoom;
                panelControls.BackgroundImage = Properties.Resources.music_note_icon;
            }
            else
            {
                panelControls.BackgroundImageLayout = ImageLayout.Center;
                panelControls.BackgroundImage = this.currentBackground;
                panelControls.Refresh();
            }
        }

        private void recalculateColors()
        {
            if (this.currentBackground == null)
            {
                this.playPauseIsLight = false;
                this.nextButtonIsLight = false;
                this.previousButtonIsLight = false;
                this.songInfoIsLight = false;
                this.libraryButtonIsLight = false;
                this.playPauseButton.BackgroundImage = this.playPauseButton.Tag.ToString() == "Play" 
                                                                ? Properties.Resources.play_icon 
                                                                : Properties.Resources.pause_icon;
                buttonNext.BackgroundImage = Properties.Resources.next_track_icon_black;
                buttonPrevious.BackgroundImage = Properties.Resources.previous_track_icon_black;
                labelSongName.ForeColor = Color.Black;
                labelArtistAlbum.ForeColor = Color.Black;
                buttonLibrary.BackgroundImage = Properties.Resources.library_icon;
                return;
            }
            int middleLine = this.currentBackground.Height / 2;
            this.playPauseIsLight = 
                ImageProcessor.shouldUseWhite(new Bitmap(this.currentBackground), 
                                                new Rectangle(
                                                    new Point(this.playPauseButton.Left, middleLine - this.playPauseButton.Height / 2), 
                                                    this.playPauseButton.Size));
            if (this.playPauseButton.Tag.ToString() == "Play")
            {
                this.playPauseButton.BackgroundImage = playPauseIsLight 
                                                            ? Properties.Resources.play_icon_light 
                                                            : Properties.Resources.play_icon;
            }
            else
            {
                this.playPauseButton.BackgroundImage = playPauseIsLight 
                                                            ? Properties.Resources.pause_icon_light 
                                                            : Properties.Resources.pause_icon;
            }
            this.nextButtonIsLight = 
                ImageProcessor.shouldUseWhite(
                                new Bitmap(this.currentBackground), 
                                new Rectangle(new Point(buttonNext.Left, middleLine - buttonNext.Height / 2), buttonNext.Size));
            buttonNext.BackgroundImage = nextButtonIsLight 
                                            ? Properties.Resources.next_track_icon_white 
                                            : Properties.Resources.next_track_icon_black;

            this.previousButtonIsLight = 
                ImageProcessor.shouldUseWhite(
                                new Bitmap(this.currentBackground), 
                                new Rectangle(
                                    new Point(buttonPrevious.Left, middleLine - buttonPrevious.Height / 2), 
                                                buttonPrevious.Size));
            buttonPrevious.BackgroundImage = previousButtonIsLight 
                                                ? Properties.Resources.previous_track_icon_white 
                                                : Properties.Resources.previous_track_icon_black;

            this.songInfoIsLight = 
                ImageProcessor.shouldUseWhite(
                                new Bitmap(this.currentBackground), 
                                new Rectangle(
                                    new Point(Math.Min(labelSongName.Left, labelArtistAlbum.Left), middleLine + panelControls.Height * 4 / 14), 
                                    new Size(Math.Max(labelSongName.Width, labelArtistAlbum.Width), labelSongName.Height + labelArtistAlbum.Height + 10)));
            labelSongName.ForeColor = this.songInfoIsLight ? Color.White : Color.Black;
            labelArtistAlbum.ForeColor = this.songInfoIsLight ? Color.White : Color.Black;

            Color libraryButtonBackground = new Bitmap(this.currentBackground).GetPixel(panelControls.Width - buttonLibrary.Width, 10);
            this.libraryButtonIsLight = 
                (libraryButtonBackground.R * 0.299 + libraryButtonBackground.G * 0.587 + libraryButtonBackground.B * 0.114) <= 186;
            buttonLibrary.BackgroundImage = this.libraryButtonIsLight 
                                                ? Properties.Resources.library_icon_light 
                                                : Properties.Resources.library_icon;
        }

        /*
         * Other methods.
         */ 

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
                AlbumInfo albumInfo = new AlbumInfo(album.Title(), 
                                                    album.Artist(), 
                                                    MusicLibrary.Get().getSongs(
                                                            album.Artist(), 
                                                            album.Title()), 
                                                    playSoloSong, 
                                                    playAlbum, 
                                                    album.AlbumArtwork());
                albumInfo.Dock = DockStyle.Fill;
                albumInfo.setContextMenuStrip(contextMenuAlbumInfo);
                listBoxMediaType.Visible = false;
                panelLibraryRightMenu.Controls.Add(albumInfo);
            }
        }

        private void shufflePlayQueue()
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

        /*
         * Music Controls.
         */

        private void playSoloSong(string filepath)
        {
            playQueue.Clear();
            playSong(filepath);
        }

        private void playSong(string filepath)
        {
            if (playQueue.Count == 0)
            {
                playQueue.Add(filepath);
                playQueuePointer = 0;
            }
            mediaPlayer.URL = filepath;
            var tfile = TagLib.File.Create(filepath);
            List<bool> backgroundHash = new List<bool>();
            if (this.currentBackground != null)
            {
                backgroundHash = ImageProcessor.HashImage(new Bitmap(this.currentBackground));
            }
            this.currentBackground = null;
            foreach (TagLib.IPicture img in tfile.Tag.Pictures)
            {
                if (img != null)
                {
                    currentBackground = 
                        ImageProcessor.CropCenteredImage(panelControls, 
                                            ImageProcessor.ResizeImage(
                                                            Image.FromStream(
                                                                    new MemoryStream((byte[])(img.Data.Data))), 
                                                                                    panelControls.Width));
                }
            }
            List<bool> newBackgroundHash = this.currentBackground == null 
                                                ? new List<bool>() 
                                                : ImageProcessor.HashImage(new Bitmap(this.currentBackground));
            if (backgroundHash.Count == newBackgroundHash.Count)
            {
                for (int i = 0; i < backgroundHash.Count; i++)
                {
                    if (backgroundHash[i] != newBackgroundHash[i])
                    {
                        recalculateColors();
                        break;
                    }
                }
            } else
            {
                recalculateColors();
            }
            drawBackground();
            labelSongName.Text = MusicLibrary.withoutPathOrExtension(filepath);
            labelArtistAlbum.Text = MusicLibrary.artistFromPath(filepath) + " - " + MusicLibrary.albumFromPath(filepath);
            labelSongName.Left = (panelControls.Width - labelSongName.Width) / 2;
            labelArtistAlbum.Left = (panelControls.Width - labelArtistAlbum.Width) / 2;
            labelSongName.Visible = true;
            labelArtistAlbum.Visible = true;

            panelLibrary.Visible = false;
            panelControls.Visible = true;
            mediaPlayer.Ctlcontrols.play();
        }

        private void playAlbum(string artistalbum, bool shouldShuffle)
        {
            this.playQueue = new List<string>(
                                MusicLibrary.Get().getSongs(
                                    artistalbum.Split('\\')[0], artistalbum.Split('\\')[1]));
            this.playQueuePointer = 0;
            if (shouldShuffle)
            {
                shufflePlayQueue();
            }
            playSong(playQueue[playQueuePointer]);
        }

        private void playPlaylist(List<string> songs, bool shouldShuffle)
        {
            if (songs.Count == 0)
            {
                return;
            }
            List<string> allSongs = MusicLibrary.Get().getAllSongs();
            List<string> fullSongs = new List<string>();
            foreach (string song in songs)
            {
                for (int i = 0; i < allSongs.Count; i++)
                {
                    if (MusicLibrary.onlyAlpha(allSongs[i]) == song)
                    {
                        fullSongs.Add(MusicLibrary.Get().getSongList()[i]);
                        break;
                    }
                }
            }
            this.playQueue = fullSongs;
            this.playQueuePointer = 0;
            if (shouldShuffle)
            {
                shufflePlayQueue();
            }
            playSong(playQueue[playQueuePointer]);
        }

        private void playNextSong()
        {
            if (playQueuePointer < playQueue.Count() - 1)
            {
                playQueuePointer++;
                playSong(playQueue[playQueuePointer]);
            }
        }

        private void playPreviousSong()
        {
            if (mediaPlayer.Ctlcontrols.currentPosition > 3)
            {
                playSong(playQueue[playQueuePointer]);
                return;
            }
            if (playQueuePointer > 0)
            {
                playQueuePointer--;
                playSong(playQueue[playQueuePointer]);
            }
        }

        private void OnPlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 2) // Paused.
            {
                playPauseButton.BackgroundImage = this.playPauseIsLight 
                                                    ? Properties.Resources.play_icon_light 
                                                    : Properties.Resources.play_icon;
                playPauseButton.Tag = "Play";
            }
            else if (e.newState == 3) // Playing.
            {
                playPauseButton.BackgroundImage = this.playPauseIsLight 
                                                    ? Properties.Resources.pause_icon_light 
                                                    : Properties.Resources.pause_icon;
                playPauseButton.Tag = "Pause";
            }
            else if (e.newState == 8 && playQueue.Count > 0) // 8 = Media Ended
            {
                playPauseButton.BackgroundImage = this.playPauseIsLight 
                                                    ? Properties.Resources.play_icon_light 
                                                    : Properties.Resources.play_icon;
                playPauseButton.Tag = "Play";
                drawBackground();
                playNextSong();
            }
            else if (e.newState == 10)
            {
                this.shouldPlayOnNextTick = true;
            }
        }

        /*
         * Event Listeners.
         */

        private void panelControls_Paint(object sender, PaintEventArgs e)
        {
            this.g = panelControls.CreateGraphics();
            this.g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.GammaCorrected;
            this.lightPen = new Pen(Color.FromArgb(24, Color.WhiteSmoke), 40);
            this.darkPen = new Pen(Color.FromArgb(24, Color.DarkGray), 40);
            Point center = new Point(panelControls.Width / 2, panelControls.Height / 2);
            int radius = Math.Min(panelControls.Width, panelControls.Height) * 4 / 14;
            int diameter = 2 * radius;
            this.progressRect = new Rectangle(center.X - radius, center.Y - radius, diameter, diameter);
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
                float angle = 
                    (float)(360 * mediaPlayer.Ctlcontrols.currentPosition / mediaPlayer.Ctlcontrols.currentItem.duration);
                if (!float.IsNaN(angle))
                {
                    this.g.DrawArc(this.playPauseIsLight ? this.lightPen : this.darkPen, this.progressRect, -90, angle);
                }
            }
            if (MousePosition == lastMousePosition)
            {
                timeIdle += 1;
                if (timeIdle > 300)
                {
                    panelIdle.Visible = true;
                }
            }
            else
            {
                timeIdle = 0;
                lastMousePosition = MousePosition;
                panelIdle.Visible = false;
            }
        }

        private void PanelControlsMouseDown(object sender, MouseEventArgs e)
        {
            Point center = new Point(panelControls.Width / 2, panelControls.Height / 2);
            int radius = Math.Min(panelControls.Width, panelControls.Height) * 4 / 14;
            Rectangle innerRect = 
                new Rectangle(center.X - radius + 12, center.Y - radius + 12, (2 * radius) - 24, (2 * radius) - 24);
            double xSquaredPlusYSquared = (e.X - center.X) * (e.X - center.X) + (e.Y - center.Y) * (e.Y - center.Y);
            if (xSquaredPlusYSquared < ((radius + 20) * (radius + 20)))
            {
                Vector newVector = new Vector(e.X - center.X, e.Y - center.Y);
                mediaPlayer.Ctlcontrols.currentPosition = 
                    newVector.calculateAngleFromNormal() / 360 * mediaPlayer.Ctlcontrols.currentItem.duration;
                drawBackground();
            }
        }

        private void OnSearchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearch_Click(sender, e);
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
            drawBackground();
            panelLibrary.Visible = false;
            panelControls.Visible = true;
        }

        private void listBoxMediaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMediaType.SelectedIndex == 0)
            {
                listBoxSongs.Visible = false;
                panelLibraryAlbums.Visible = false;
                playlistsView1.Visible = true;
            } else if (listBoxMediaType.SelectedIndex == 1)
            {
                listBoxSongs.Visible = false;
                playlistsView1.Visible = false;
                panelLibraryAlbums.Visible = true;
            } else if (listBoxMediaType.SelectedIndex == 2)
            {
                panelLibraryAlbums.Visible = false;
                playlistsView1.Visible = false;
                listBoxSongs.Visible = true;
            } else if (listBoxMediaType.SelectedIndex == 3)
            {
                panelLibraryAlbums.Visible = false;
                playlistsView1.Visible = false;
                listBoxSongs.Visible = false;
            }
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            playNextSong();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            playPreviousSong();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            List<string> songs = MusicLibrary.Get().getAllSongs();
            for (int i = 0; i < songs.Count; i++)
            {
                if (MusicLibrary.onlyAlpha(songs[i]) == textBoxSearch.Text)
                {
                    playSong(MusicLibrary.Get().getSongList()[i]);
                    return;
                }
            }
            MessageBox.Show("Requested song could not be found. Please check the name of the song.");
        }

        // Add to Queue clicked on songs page
        private void addToPlayQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.playQueue.Add(MusicLibrary.Get().getSongList()[listBoxSongs.SelectedIndex]);
        }

        // Add to Queue clicked on Album Info page
        private void addToPlayQueueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string songName = "";
            foreach (Control c in panelLibraryRightMenu.Controls)
            {
                if (c is AlbumInfo)
                {
                    AlbumInfo albumInfo = (AlbumInfo)c;
                    songName = albumInfo.getSelectedSong();
                    break;
                }
            }
            this.playQueue.Add(songName);
        }

        private void contextMenuSongs_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listBoxSongs.SelectedIndex == -1)
            {
                e.Cancel = true;
            }
        }

        private void contextMenuAlbumInfo_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (Control c in panelLibraryRightMenu.Controls)
            {
                if (c is AlbumInfo)
                {
                    AlbumInfo albumInfo = (AlbumInfo)c;
                    if (albumInfo.getSelectedSong() == null)
                    {
                        e.Cancel = true;
                    }
                    break;
                }
            }
        }
    }
}
