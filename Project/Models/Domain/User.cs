using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();
        public Group Group { get; set; }
        public Guid GroupId { get; set; }
    }
}
    