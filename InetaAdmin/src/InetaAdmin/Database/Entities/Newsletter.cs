using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Threading.Tasks;
using Gos.Tools.Azure;

namespace InetaAdmin.Database.Entities
{
    public class Newsletter : IItem
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Recipients { get; set; }
        public DateTime SendDate { get; set; }
    }
}
