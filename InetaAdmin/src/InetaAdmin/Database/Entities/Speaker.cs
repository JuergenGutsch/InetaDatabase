using System;
using Gos.Tools.Azure;

namespace InetaAdmin.Database.Entities
{
    public class Speaker : IItem
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Topics { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Xing { get; set; }
    }
}
