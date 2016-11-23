using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TVSeriesCalendar.Models
{
    public class ShowViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FirstAirDate { get; set; }

        public string OriginalName { get; set; }

        public string OriginCountry { get; set; }

        public double Popularity { get; set; }

        public Uri PosterPath { get; set; }

        public double VoteAverage { get; set; }

        public int VoteCount { get; set; }

        public TMDbLib.Objects.TvShows.Credits Credits { get; set; }

        public string Overview { get; set; }

        public TMDbLib.Objects.General.SearchContainer<TMDbLib.Objects.Search.SearchTv> SimilarTVShows { get; set; }

        public IEnumerable<Show> AllResults { get; set; }
    }
}