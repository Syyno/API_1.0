using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.OpenApi.Any;
using Project.Models;
using Project.Models.Auth;
using Project.Models.Domain;
using Project.Util;

namespace Project.Services
{
    public class EFRepository : IRepository
    {
        private readonly AppDbContext _db;

        public EFRepository(AppDbContext db)
        {
            _db = db;
        }

        public List<string> GetUsersByGroupAndServices(GetRequestModel request)
        {
            var usersOfGroup = _db.Users.Where(u => u.Group.Name.ToLower().Trim() == request.Group.ToLower().Trim()).ToList(); // GET ALL ADMINS
            var usersOfServices = _db.Users.Where(u => u.Services.Any(s => s.Name.ToLower().Trim() == request.Services.FirstOrDefault().ToLower().Trim()  )).ToList();  // GET ALL YOUTUBE USERS
            return usersOfGroup.Join(usersOfServices, ug => ug.Id, us => us.Id, (ug, us) => new {ug.Name}).Select(u => u.Name).ToList();
        }

        public void PostUserWithHisGroupAndServices(PostUser postUser)
        {

        }

        public void Register(RegisterModelDb registerModel)
        {
            _db.RegisteredUsers.Add(registerModel);
            _db.SaveChanges();
        }

        public List<RegisterModelDb> RegisteredUsers() => _db.RegisteredUsers.ToList();
        public RegisterModelDb GetUserById(int id) => _db.RegisteredUsers.FirstOrDefault(u => u.Id == id);
        public Group GetGroupByName(string groupName)
        {
            return _db.Groups.FirstOrDefault(g => g.Name.ToLower() == groupName.ToLower().Trim());
        }

        public List<Service> GetServicesByNames(List<string> services)
        {
            List<Service> returnList = new List<Service>();
            foreach (var serviceName in services)
            {
                returnList.Add( _db.Services.FirstOrDefault(s => s.Name.ToLower() == serviceName.ToLower().Trim()));
            }

            return returnList.Count != 0 ? returnList : null;
        }

        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }


        public User GetUserByNameSurnameAge(string name, string surname, int? age)
        {
            return _db.Users.FirstOrDefault(u =>
                u.Name.ToLower() == name.ToLower().Trim() && u.Surname.ToLower() == surname.ToLower().Trim() &&
                u.Age != null && age != null && u.Age == age);
        }
    }
}
