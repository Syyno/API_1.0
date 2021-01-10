using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Domain
{
    public class GetRequestModel
    {
        public string Group { get; set; }
        public List<string> Services { get; set; }

    }
}   
