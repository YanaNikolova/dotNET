using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVSeriesCalendar_3.Models
{
    public class Season
    {
        public int Id { get; set; }

        public string ShowName { get; set; }

        public int SeasonNumber { get; set; }

        public int EpisodeCount { get; set; }

        public DateTime AirDate { get; set; }

        public string Overview { get; set; } 

        public string PosterPath { get; set; }

        public Uri VideoPath { get; set; }

        public IEnumerable<Episode> EpisodesList { get; set; }
    }
}