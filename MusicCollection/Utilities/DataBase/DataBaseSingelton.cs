using MusicCollection.Models.Interfaces;

namespace MusicCollection.Utilities.DataBase
{
    public class DataBaseSingelton
    {
        private static DataBaseSingelton instance=new DataBaseSingelton();
        private IStrategy strategyToFetchData;

        private DataBaseSingelton()
        {
            strategyToFetchData = new FetchFromDataBase();
        }

        public static DataBaseSingelton Instance
        {
            get { return instance; }
        }


        public IGenre FetchGenreFromDataBase(int id)
        {
            return strategyToFetchData.FetchGenreFromDataBase(id);
        }
    }
}
