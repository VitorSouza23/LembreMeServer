using System;
using System.Collections.Generic;
using System.Text;

namespace LembreMeServer.Domain.Entities
{
    public class Location
    {
        public long ID { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string FederativeUnit { get; set; }
    }
}
