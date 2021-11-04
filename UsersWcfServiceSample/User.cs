using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace UsersWcfServiceSample
{
    [DataContract(Namespace = "http://schemas.sample.com")]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember(Name = "Email", Order = 4)]
        public string UserName { get; set; }
    }
}