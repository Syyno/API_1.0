using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;
using Project.Models.Domain;

namespace Project.Util
{
    public static class DataAdd
    {
        public static void AddSomeData(this AppDbContext db)
        {
            var groups = new Group[]
                {
                    new Group() {Id = Guid.Parse("28DD2C67-262A-4971-8EDF-3176F5A5B11A"), Name = "Admin" },
                    new Group() {Id = Guid.Parse("FD312836-7606-45E7-8339-87B4980BD9FA"), Name = "Moderator" },
                    new Group() {Id = Guid.Parse("0207230C-7AD5-46B7-A98F-D48905AA67FF"), Name = "User" }
                };
            db.Groups.AddRange(groups);

            var users = new User[]
            {
                new User()
                {
                    Id = Guid.Parse("B780FDCD-FA4C-49CD-8BFF-9110B1A95CAC"), Age = 20, Name = "Ivan", Surname = "Ivanov",
                    GroupId = groups[2].Id
                },
                new User()
                {
                    Id = Guid.Parse("E0FAFE3F-90FF-4D2C-B8D1-297A43840183"), Age = 35, Name = "Artem", Surname = "Artemov",
                    GroupId = groups[1].Id
                },
                new User()
                {
                    Id = Guid.Parse("9F072381-5F3F-4A53-B402-0F8A1287BFB5"), Age = 37, Name = "Oleg", Surname = "Olegov",
                    GroupId = groups[0].Id
                }
            };
            db.Users.AddRange(users);

            var services = new Service[]
                {
                    new Service() {Id = Guid.Parse("5604C945-EDF5-420C-8814-0137909D2ACF"), Name = "Youtube", Users = new List<User>() {users[0], users[2]} },
                    new Service() {Id = Guid.Parse("E67C6397-D38C-48B2-B1AD-14B7CD9EBDB4"), Name = "Play", Users = new List<User>() {users[1]}},
                    new Service() {Id = Guid.Parse("A1E3E3F5-8643-4D73-ACC7-FC951DDE8482"), Name = "Forum", Users = new List<User>() {users[2]}}
                };
            db.Services.AddRange(services);

            db.SaveChanges();
        }
    }
}
