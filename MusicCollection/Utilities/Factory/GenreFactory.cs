using MusicCollection.Models.Genres;
using MusicCollection.Models.Interfaces;
using Song_sCollection.Models.Genres;

namespace MusicCollection.Utilities.Factory
{
    public class GenreFactory : IGenreFactory
    {
        public IGenre CreateGenre(int id)
        {
            switch (id)
            {
                case 1:
                    return new Pop();
                case 2:
                    return new Rock();
                case 3:
                    return new HipHop();
                case 4:
                    return new RandB();
                case 5:
                    return new Country();
                case 6:
                    return new Jazz();
                case 7:
                    return new Blues();
                case 8:
                    return new Electronic();
                case 9:
                    return new Classical();
                case 10:
                    return new Reggae();
                default:
                    throw new ArgumentException("Invalid Genre");
            }
        }
    }
}
