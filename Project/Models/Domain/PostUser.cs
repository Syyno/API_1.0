using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Domain
{
    public class PostUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public List<string> Services { get; set; } = new List<string>();
        public string GroupName { get; set; }
    }
}
