using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace UsersWcfServiceSample.Services
{
    public class UserServiceProvider : IUserServiceProvider
    {
        List<User> users = new List<User>
            {
                new User { Id = 1, Name = "Jose", LastName = "Perez", UserName = "joseperez@gmail.com" },
                new User { Id = 2, Name = "Juan", LastName = "Lopez", UserName = "juanlopez@hotmail.com" },
                new User { Id = 3, Name = "Raul", LastName = "Fernandez", UserName = "raulfernandez@yahoo.com" }
            };

        public List<User> GetUsers()
        {
            return users;
        }
    }
}