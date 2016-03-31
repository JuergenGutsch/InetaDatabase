using System;
using Gos.Tools.Azure;

namespace InetaAdmin.Database.Entities
{
    public class Event : IItem
    {
        public Guid Id { get; set; }
        public DateTime DateStart { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UsergroupId { get; set; }
        public Guid SpeakerId { get; set; }
        public string Location { get; set; }
    }
}