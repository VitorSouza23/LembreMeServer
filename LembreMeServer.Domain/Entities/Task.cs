using System;
using System.Collections.Generic;
using System.Text;

namespace LembreMeServer.Domain.Entities
{
    public class Task
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public virtual Location Location { get; set; }
    }
}
