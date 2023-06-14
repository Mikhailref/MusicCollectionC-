using MusicCollection.Models.Interfaces;

namespace MusicCollection.Utilities.Factory
{
    public interface IGenreFactory
    {
        public IGenre CreateGenre(int id);
    }
}
