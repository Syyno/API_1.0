using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Domain
{
    public class Service
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public List<User> Users { get; set; } = new List<User>();
       // public List<string> UserId { get; set; } = new List<string>();
    }
}
