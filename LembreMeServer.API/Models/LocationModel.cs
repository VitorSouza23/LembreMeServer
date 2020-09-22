using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LembreMeServer.API.Models
{
    public class LocationModel
    {
        public string? Street { get; set; }
        public int? Number { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? FederativeUnit { get; set; }
    }
}
