using System;
using System.ComponentModel.DataAnnotations;

namespace LembreMeServer.API.Models
{
    public class TaskModel
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public virtual LocationModel? Location { get; set; }
    }
}
