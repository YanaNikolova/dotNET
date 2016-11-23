using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVSeriesCalendar.Models
{
    public class Season
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime? AirDate { get; set; }

        public string Credits { get; set; }

        public int EpisodeCount { get; set; }

        public int Episodes { get; set; }

        public int ExternalIds { get; set; }

        public string Image { get; set; }

        public string Overview { get; set; }

        public string PosterPath { get; set; }

        public int SeasonNumber { get; set; }

        public string Videos { get; set; }
    }
}