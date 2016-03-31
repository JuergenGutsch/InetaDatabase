using System;
using Gos.Tools.Azure;

namespace InetaAdmin.Database.Entities
{
    public class Usergroup : IItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
    }
}