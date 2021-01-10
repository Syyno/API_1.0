using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.Domain;

namespace Project.Models.Builder
{
    public abstract class AbstractBuilder
    {
        public abstract void CreateUserWithBasicInfo(PostUser user);
        public abstract void AddGroupToUser(PostUser user);
        public abstract void AddServicesToUser(PostUser user);
        public abstract User GetResult();
    }
}
