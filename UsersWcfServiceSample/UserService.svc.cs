using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UsersWcfServiceSample.Services;

namespace UsersWcfServiceSample
{
    [ServiceBehavior]
    public class UserService : IUserService
    {
        List<User> users = new List<User>
            {
                new User { Id = 1, Name = "Jose", LastName = "Perez", UserName = "joseperez@gmail.com" },
                new User { Id = 2, Name = "Juan", LastName = "Lopez", UserName = "juanlopez@hotmail.com" },
                new User { Id = 3, Name = "Raul", LastName = "Fernandez", UserName = "raulfernandez@yahoo.com" }
            };

        private readonly IUserServiceProvider _userService;

        public UserService(IUserServiceProvider userService)
        {
            _userService = userService;
        }

        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public User GetUser(string id)
        {
            var user = users.FirstOrDefault(x => x.Id == int.Parse(id));

            if(user == null)
                throw new WebFaultException(HttpStatusCode.NotFound);

            return user;
        }

        public List<User> GetUsers()
        {
            return _userService.GetUsers();
        }

        public XmlSerializerUser GetUserXmlSerializer(string id)
        {
            return new XmlSerializerUser()
            {
                Id = int.Parse(id),
                Name = "Carlos",
                LastName = "Perez",
                UserName = "carlitosp@gmail.com"
            };
        }

        public int PostUser(User user)
        {
            int lastId = 1;

            if (users.Any())
                lastId = users.Last().Id;

            user.Id = ++lastId;

            users.Add(user);


            return lastId;
        }
    }
}
