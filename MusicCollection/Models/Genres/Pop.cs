using MusicCollection.Models.Interfaces;
using MusicCollection.Models.Singers;

namespace MusicCollection.Models.Genres
{
    public class Pop : IGenre
    {
        public string Title { get; set; }
        public List<Singer> SingerCollection { get; set; }

        public Pop()
        {
            SingerCollection = new List<Singer>();
            
        }
        public void AddSinger(Singer singer)
        {
            SingerCollection.Add(singer);
        }
    }
}
