﻿using MusicCollection.Models.Interfaces;
using MusicCollection.Models.Singers;

namespace Song_sCollection.Models.Genres
{
    public class Rock : IGenre
    {
        public string Title { get; set; }
        public List<Singer> SingerCollection { get; set; }

        public Rock()
        {
            SingerCollection = new List<Singer>();
        }

        public void AddSinger(Singer singer) 
        { 
           SingerCollection.Add(singer);
        }

    }
}
