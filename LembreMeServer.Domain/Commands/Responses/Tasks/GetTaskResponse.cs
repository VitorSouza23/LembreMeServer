using LembreMeServer.Domain.Entities;
using System;

namespace LembreMeServer.Domain.Commands.Responses.Tasks
{
    public class GetTaskResponse
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime? Deadline { get; set; }
        public virtual Location? Location { get; set; }
    }
}
