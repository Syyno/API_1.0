using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models.Auth;
using Project.Models.Domain;

namespace Project.Services
{
    public interface IRepository
    {
        List<string> GetUsersByGroupAndServices(GetRequestModel request);

        #region Auth
        void Register(RegisterModelDb registerModel);

        List<RegisterModelDb> RegisteredUsers();

        RegisterModelDb GetUserById(int id);

        #endregion

        Group GetGroupByName(string groupName);
        List<Service> GetServicesByNames(List<string> services);

        void AddUser(User user);

        User GetUserByNameSurnameAge(string name, string surname, int? age);
    }
}
