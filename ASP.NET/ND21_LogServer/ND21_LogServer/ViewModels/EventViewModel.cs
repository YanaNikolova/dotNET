using ND21_LogServer.Models.Events;
using ND21_LogServer.Models.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ND21_LogServer.ViewModels
{
    public class EventViewModel
    {
        public IEnumerable<ExtendedEvent> ExtendedEvents { get; set; }

        public IEnumerable<Project> Projects { get; set; }

        public List<Project> project { get; set; }

        [Display(Name = "ErrorsOnly")]
        public bool ErrorsOnly { get; set; }

        [Display(Name = "Filter by Project")]
        public int FilterByProject { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "From date")]
        public DateTime fromDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "To date")]
        public DateTime toDate { get; set; }
    }
}