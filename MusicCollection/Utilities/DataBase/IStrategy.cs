using MusicCollection.Models.Interfaces;

namespace MusicCollection.Utilities.DataBase
{
    public interface IStrategy
    {
        IGenre FetchGenreFromDataBase(int id);
    }
}
