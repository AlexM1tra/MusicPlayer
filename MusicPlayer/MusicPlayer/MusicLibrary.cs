using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace MusicPlayer
{
    class MusicLibrary
    {
        private static MusicLibrary library;

        private Dictionary<string, Dictionary<string, List<string>>> data;
        private List<string> songs;

        public static MusicLibrary Get()
        {
            return library;
        }

        public static void readLibrary(string path)
        {
            var songList = new List<string>();
            var songData = new Dictionary<string, Dictionary<string, List<string>>>();
            if (Directory.Exists(path))
            {
                foreach (var artist in Directory.GetDirectories(path))
                {
                    if (Directory.Exists(artist))
                    {
                        string artistWithoutPath = withoutPath(artist);
                        songData[artistWithoutPath] = new Dictionary<string, List<string>>();
                        foreach (var album in Directory.GetDirectories(artist))
                        {
                            if (Directory.Exists(album))
                            {
                                IEnumerable<string> songs = Directory.GetFiles(album)
                                    .Where(file => file.ToLower().EndsWith(".mp3") 
                                                    || file.ToLower().EndsWith(".m4a") 
                                                    || file.ToLower().EndsWith(".wav"));
                                if (songs.Count() > 0)
                                {
                                    string albumWithoutPath = withoutPath(album);
                                    songData[artistWithoutPath][albumWithoutPath] = new List<string>();
                                    foreach (var song in songs)
                                    {
                                        songList.Add(song);
                                        songData[artistWithoutPath][albumWithoutPath].Add(song);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            MusicLibrary.library = new MusicLibrary(songData);
            MusicLibrary.library.songs = songList;
        }

        public static string withoutPath(string filename)
        {
            string[] filenameArray = filename.Split('\\');
            return filenameArray[filenameArray.Length - 1];
        }

        public static string withoutPathOrExtension(string filename)
        {
            string noPath = withoutPath(filename);
            return noPath.Substring(0, noPath.LastIndexOf('.'));
        }

        public static string onlyAlpha(string text)
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

        public static string artistFromPath(string filename)
        {
            string[] filenameArray = filename.Split('\\');
            return filenameArray[filenameArray.Length - 3];
        }

        public static string albumFromPath(string filename)
        {
            string[] filenameArray = filename.Split('\\');
            return filenameArray[filenameArray.Length - 2];
        }

        public List<Album> getAlbums()
        {
            List<Album> albums = new List<Album>();
            foreach (KeyValuePair<string, Dictionary<string, List<string>>> artist in this.data)
            {
                foreach (var album in artist.Value)
                {
                    if (album.Value.Count() > 0)
                    {
                        Image albumArt = MusicPlayer.Properties.Resources.album_icon;
                        var tfile = TagLib.File.Create(album.Value[0]);
                        foreach (TagLib.IPicture img in tfile.Tag.Pictures)
                        {
                            if (img != null)
                            {
                                albumArt = ImageProcessor.ResizeImage(Image.FromStream(new MemoryStream((byte[])(img.Data.Data))), 200);
                            }
                        }
                        albums.Add(new Album(albumArt, album.Key, artist.Key));
                    }
                }
            }
            return albums;
        }

        public List<string> getSongs(string artist, string album)
        {
            return this.data[artist][album];
        }

        public List<string> getAllSongs()
        {
            return this.songs.Select((song) => withoutPathOrExtension(song)).ToList();
        }

        public List<string> getSongList()
        {
            return this.songs;
        }

        private MusicLibrary(Dictionary<string, Dictionary<string, List<string>>> library)
        {
            this.data = library;
        }
    }
}
