using System;
using System.Collections.Generic;
using System.Text;

namespace LembreMeServer.Domain.Entities
{
    public class Location
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string FederativeUnit { get; set; }
        public long TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
