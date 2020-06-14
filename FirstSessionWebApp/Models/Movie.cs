using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;

namespace FirstSessionWebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Rating { get; set; }

        public string Description { get; set; }

        /* extend movie model with trailer field */
        public string Trailer { get; set; }
    }
}
