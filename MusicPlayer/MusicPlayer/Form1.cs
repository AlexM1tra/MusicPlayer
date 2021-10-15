using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WMPLib;

/*
 * TODO:
 * ---------------------- Forward and Back buttons
 * ---------------------- Song Info
 * ---------------------- Remove Artist view
 * ---------------------- Auto light/dark
 * Set up playlists
 * Play queue (change listbox logic)
 * ---------------------- Finish search
 * Idle mode
 * ---------------------- Song scrubbing
 * ---------------------- Fix white circle
 * ---------------------- Library Caching
 */
namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        private const double PI = 3.141592653589793238462643383279502884197169399375105820974944592307816406286;
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

        public Form1()
        {
            InitializeComponent();
            panelControls.Paint += new PaintEventHandler(this.panelControls_Paint);
            panelControls.MouseDown += new MouseEventHandler(PanelControlsMouseDown);
            mediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(OnPlayStateChange);
            textBoxSearch.KeyDown += new KeyEventHandler(OnSearchKeyDown);
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

            populateLibrary();
            listBoxMediaType.SelectedIndex = 1; // Select Albums.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        } 

        private double calculateAngleOfVector(Point vector)
        {
            if (vector.X == 0 && vector.Y == 0)
            {
                return 0;
            }
            else if (vector.Y == 0)
            {
                return vector.X > 0 ? 90 : 270;
            } else if (vector.X == 0)
            {
                return vector.Y >= 0 ? 0 : 180;
            }
            double angle = Math.Atan2(Math.Abs(vector.X), Math.Abs(vector.Y)) * 180;
            angle = angle / PI;
            angle = angle < 0 ? angle + 180 : angle;
            if (vector.X > 0 && vector.Y < 0)
            {
                return angle;
            } else if (vector.X > 0 && vector.Y > 0)
            {
                return 180 - angle;
            } else if (vector.X < 0 && vector.Y < 0)
            {
                return 360 - angle; 
            } else if (vector.X < 0 && vector.Y > 0)
            {
                return 180 + angle;
            }
            return 0;
        }

        private void PanelControlsMouseDown(object sender, MouseEventArgs e)
        {
            Point center = new Point(panelControls.Width / 2, panelControls.Height / 2);
            int radius = Math.Min(panelControls.Width, panelControls.Height) * 4 / 14;
            Rectangle innerRect = new Rectangle(center.X - radius + 12, center.Y - radius + 12, (2 * radius) - 24, (2 * radius) - 24);
            double xSquaredPlusYSquared = (e.X - center.X) * (e.X - center.X) + (e.Y - center.Y) * (e.Y - center.Y);
            if (xSquaredPlusYSquared < ((radius + 20) * (radius + 20)))
            {
                Point newVector = new Point(e.X - center.X, e.Y - center.Y);
                mediaPlayer.Ctlcontrols.currentPosition = calculateAngleOfVector(newVector) / 360 * mediaPlayer.Ctlcontrols.currentItem.duration;
                drawBackground();
            }
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
                AlbumInfo albumInfo = new AlbumInfo(album.Title(), album.Artist(), MusicLibrary.Get().getSongs(album.Artist(), album.Title()), playSoloSong, playAlbum, album.AlbumArtwork());
                albumInfo.Dock = DockStyle.Fill;
                listBoxMediaType.Visible = false;
                panelLibraryRightMenu.Controls.Add(albumInfo);
            }
        }

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
                panelControls.BackgroundImage = this.currentBackground;//ImageResizer.CropCenteredImage(panelControls, this.currentBackground);
                panelControls.Refresh();
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
                    this.g.DrawArc(this.playPauseIsLight ? this.lightPen : this.darkPen, this.progressRect, -90, angle);
                }
            }
        }

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
                backgroundHash = ImageResizer.HashImage(new Bitmap(this.currentBackground));
            }
            this.currentBackground = null;
            foreach (TagLib.IPicture img in tfile.Tag.Pictures)
            {
                if (img != null)
                {
                    currentBackground = ImageResizer.CropCenteredImage(panelControls, ImageResizer.ResizeImage(Image.FromStream(new MemoryStream((byte[])(img.Data.Data))), panelControls.Width));
                }
            }
            List<bool> newBackgroundHash = this.currentBackground == null ? new List<bool>() : ImageResizer.HashImage(new Bitmap(this.currentBackground));
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
            this.playQueue = MusicLibrary.Get().getSongs(artistalbum.Split('\\')[0], artistalbum.Split('\\')[1]);
            this.playQueuePointer = 0;
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
                playPauseButton.BackgroundImage = this.playPauseIsLight ? Properties.Resources.play_icon_light : Properties.Resources.play_icon;
                playPauseButton.Tag = "Play";
            }
            else if (e.newState == 3) // Playing.
            {
                playPauseButton.BackgroundImage = this.playPauseIsLight ? Properties.Resources.pause_icon_light : Properties.Resources.pause_icon;
                playPauseButton.Tag = "Pause";
            }
            else if (e.newState == 8 && playQueue.Count > 0) // 8 = Media Ended
            {
                labelSongName.Visible = false;
                labelArtistAlbum.Visible = false;
                playPauseButton.BackgroundImage = this.playPauseIsLight ? Properties.Resources.play_icon_light : Properties.Resources.play_icon;
                playPauseButton.Tag = "Play";
                playNextSong();
            }
            else if (e.newState == 10)
            {
                this.shouldPlayOnNextTick = true;
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
                this.playPauseButton.BackgroundImage = this.playPauseButton.Tag.ToString() == "Play" ? Properties.Resources.play_icon : Properties.Resources.pause_icon;
                buttonNext.BackgroundImage = Properties.Resources.next_track_icon_black;
                buttonPrevious.BackgroundImage = Properties.Resources.previous_track_icon_black;
                labelSongName.ForeColor = Color.Black;
                labelArtistAlbum.ForeColor = Color.Black;
                buttonLibrary.BackgroundImage = Properties.Resources.library_icon;
                return;
            }
            int middleLine = this.currentBackground.Height / 2;
            this.playPauseIsLight = shouldUseWhite(new Bitmap(this.currentBackground), new Rectangle(new Point(this.playPauseButton.Left, middleLine - this.playPauseButton.Height / 2), this.playPauseButton.Size));
            if (this.playPauseButton.Tag.ToString() == "Play")
            {
                this.playPauseButton.BackgroundImage = playPauseIsLight ? Properties.Resources.play_icon_light : Properties.Resources.play_icon;
            } else
            {
                this.playPauseButton.BackgroundImage = playPauseIsLight ? Properties.Resources.pause_icon_light : Properties.Resources.pause_icon;
            }
            this.nextButtonIsLight = shouldUseWhite(new Bitmap(this.currentBackground), new Rectangle(new Point(buttonNext.Left, middleLine - buttonNext.Height / 2), buttonNext.Size));
            buttonNext.BackgroundImage = nextButtonIsLight ? Properties.Resources.next_track_icon_white : Properties.Resources.next_track_icon_black;
            this.previousButtonIsLight = shouldUseWhite(new Bitmap(this.currentBackground), new Rectangle(new Point(buttonPrevious.Left, middleLine - buttonPrevious.Height / 2), buttonPrevious.Size));
            buttonPrevious.BackgroundImage = previousButtonIsLight ? Properties.Resources.previous_track_icon_white : Properties.Resources.previous_track_icon_black;
            this.songInfoIsLight = shouldUseWhite(new Bitmap(this.currentBackground), new Rectangle(new Point(Math.Min(labelSongName.Left, labelArtistAlbum.Left), middleLine + panelControls.Height * 4/14), new Size(Math.Max(labelSongName.Width, labelArtistAlbum.Width), labelSongName.Height + labelArtistAlbum.Height + 10)));
            labelSongName.ForeColor = this.songInfoIsLight ? Color.White : Color.Black;
            labelArtistAlbum.ForeColor = this.songInfoIsLight ? Color.White : Color.Black;
            Color libraryButtonBackground = new Bitmap(this.currentBackground).GetPixel(panelControls.Width - buttonLibrary.Width, 10);
            this.libraryButtonIsLight = (libraryButtonBackground.R * 0.299 + libraryButtonBackground.G * 0.587 + libraryButtonBackground.B * 0.114) <= 186;
            buttonLibrary.BackgroundImage = this.libraryButtonIsLight ? Properties.Resources.library_icon_light : Properties.Resources.library_icon;
        }

        private bool shouldUseWhite(Bitmap image, Rectangle rect)
        {
            if (rect.Width > image.Width || rect.Height > image.Height)
            {
                return false;
            }
            int redTotal = 0;
            int greenTotal = 0;
            int blueTotal = 0;
            int numberOfPoints = 0;
            Color currentColor;
            for (int x = rect.Left; x < rect.Left + rect.Width; x++)
            {
                for (int y = rect.Top; y < rect.Top + rect.Height; y++)
                {
                    currentColor = image.GetPixel(x, y);
                    redTotal += currentColor.R;
                    greenTotal += currentColor.G;
                    blueTotal += currentColor.B;
                    numberOfPoints++;
                }
            }
            Color averageColor = Color.FromArgb(redTotal / numberOfPoints, greenTotal / numberOfPoints, blueTotal / numberOfPoints);
            return (averageColor.R * 0.299 + averageColor.G * 0.587 + averageColor.B * 0.114) <= 186;
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
                if (onlyAlpha(songs[i]) == textBoxSearch.Text)
                {
                    playSong(MusicLibrary.Get().getSongList()[i]);
                    break;
                }
            }
        }
    }
}
