using MusicCollection.Models.Singers;

namespace MusicCollection.Models.Interfaces
{
    public interface IGenre
    {
        public string  Title { get; set; }

        public List <Singer> SingerCollection { get; set; }

        void AddSinger(Singer singer);
    }
}
