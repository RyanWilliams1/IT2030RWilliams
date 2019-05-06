using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RyansEventManager.Models
{
    public class SampleData : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {
            var genres = new List<Genre>
            {
                new Genre { Name = "Rock" },
            };

            var artists = new List<Artist>
            {
                new Artist { Name = "Aaron Copland & London Symphony Orchestra" },
            };

            new List<Album>
            {
                new Album { Title = "A Copland Celebration, Vol. I", Genre = genres.Single(g => g.Name == "Classical"), Price = 8.99M, Artist = artists.Single(a => a.Name == "Aaron Copland & London Symphony Orchestra"), AlbumArtUrl = "/Content/Images/placeholder.gif" },

            }.ForEach(a => context.Albums.Add(a));
        }
    }
}