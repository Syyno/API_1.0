using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.Domain;

namespace Project.Models.Builder
{
    public class Director
    {
        private AbstractBuilder _builder;
        private PostUser _postUser;

        public Director(AbstractBuilder builder, PostUser postUser)
        {
            _builder = builder;
            _postUser = postUser;
        }

        public void Construct()
        {
            _builder.CreateUserWithBasicInfo(_postUser);
            _builder.AddServicesToUser(_postUser);
            _builder.AddGroupToUser(_postUser);
        }
    }
}
