using Microsoft.Data.SqlClient;
using MusicCollection.Models.Interfaces;
using MusicCollection.Models.Singers;
using MusicCollection.Utilities.Factory;
using System.Data;

namespace MusicCollection.Utilities.DataBase
{
    public class FetchFromDataBase : IStrategy
    {
        //factory
        private readonly IGenreFactory _genreFactory;
        //genre
        //connection
        public string ConnectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""Song'sCollection"";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        //query
        public string  Query { get; set; }= @"SELECT g.[Genre], s.[Singer], so.[Song], so.[Description]
                         FROM [dbo].[Genres] g
                         INNER JOIN [dbo].[Singers] s ON g.[Id] = s.[IdGenre]
                         INNER JOIN [dbo].[Songs] so ON s.[Id] = so.[IdSinger]
                         WHERE g.[Id] = @GenreId";


        public FetchFromDataBase()
        {
            _genreFactory = new GenreFactory();
        }

        public IGenre FetchGenreFromDataBase(int id)
        {
           IGenre genre=_genreFactory.CreateGenre(id);

            try
            {
                using(SqlConnection connection=new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        IDbDataParameter parametr = command.CreateParameter();
                        parametr.ParameterName = "@GenreId";
                        parametr.Value = id;
                        command.Parameters.Add(parametr);

                        using (IDataReader reader=command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                string GenreTitle=reader.GetString(reader.GetOrdinal("Genre"));
                                string SingerName= reader.GetString(reader.GetOrdinal("Singer"));
                                string Song= reader.GetString(reader.GetOrdinal("Song"));
                                string SongDescription= reader.GetString(reader.GetOrdinal("Description"));

                                genre.Title = GenreTitle;
                                Singer singer = new Singer(SingerName);
                                string [] song =singer.CreateArrayForSong(Song, SongDescription);
                                singer.AddSongArrayToTheListOfSongs(song);
                                genre.AddSinger(singer);

                                //add class for song
                                //make logic for many songs of the same singer
                            }

                            
                        }
                    }
                }
            }

            catch (Exception ex) 
            {
                    throw new Exception("Error while fetching data from databas", ex);
            }

            return genre;
        }
    }

}
