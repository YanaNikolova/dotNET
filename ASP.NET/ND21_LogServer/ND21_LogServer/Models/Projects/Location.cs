using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ND21_LogServer.Models.Projects
{
    public class Location
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public string Notes { get; set; }
        public Guid APIKey { get; set; }
        public bool Active { get; set; }
    }
}