using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVSeriesCalendar.Models
{
    public class Episode
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime AirDate { get; set; }

        public string Credits { get; set; }

        public string Crew { get; set; }

        public int EpisodeNumber { get; set; }

        public int ExternalIds { get; set; }

        public string Image { get; set; }

        public string Overview { get; set; }

        public string ProductionCode { get; set; }

        public int SeasonNumber { get; set; }

        public string StillPath { get; set; }

        public string Videos { get; set; }

        public double VoteAverage { get; set; }

        public int VoteCount { get; set; }
    }
}