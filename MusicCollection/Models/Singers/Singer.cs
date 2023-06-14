namespace MusicCollection.Models.Singers
{
    public class Singer
    {
        public string name { get; set; }

        public List<string[]> ListOfSongs { get; set; }

        public Singer(string Name)
        {
            name=Name;
            ListOfSongs = new List<string[]>();
            
        }

        public string[] CreateArrayForSong(string songName, string songDescription)
        {
            string[] SongData = new string[2] {songName, songDescription};
            return SongData;
        }

        public void AddSongArrayToTheListOfSongs(string[] SongData) 
        {
          ListOfSongs.Add(SongData);
        }
    }
}
