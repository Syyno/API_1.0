using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Domain
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
       // public List<User> Users { get; set; } = new List<User>();
        //public Service Service { get; set; }
        //public Guid ServiceId { get; set; }
    }
}
