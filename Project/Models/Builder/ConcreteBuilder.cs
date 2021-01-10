using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.Domain;
using Project.Services;

namespace Project.Models.Builder
{
    public class ConcreteBuilder : AbstractBuilder
    {
        private readonly IRepository _repository;

        public ConcreteBuilder(IRepository repository)
        {
            _repository = repository;
        }


        User user = new User();
        public override void CreateUserWithBasicInfo(PostUser postUser)
        {
            user.Age = postUser.Age;
            user.Name = postUser.Name;
            user.Surname = postUser.Surname;
        }

        public override void AddGroupToUser(PostUser postUser)
        {
            user.Group = _repository.GetGroupByName(postUser.GroupName);
        }

        public override void AddServicesToUser(PostUser postUser)
        {
            var services = _repository.GetServicesByNames(postUser.Services);
            if (services == null)
                user.Services = new List<Service>();
            else
                user.Services = services;
        }

        public override User GetResult()
        {
            _repository.AddUser(user);
            return user;
        }
    }
}
