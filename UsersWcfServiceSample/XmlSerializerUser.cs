using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace UsersWcfServiceSample
{
    [XmlRoot("User", Namespace = "http://www.cpandl.com")]
    public class XmlSerializerUser
    {
        [XmlAttribute]
        public int Id { get; set; }
        [XmlElement]
        public string Name { get; set; }
        [XmlElement]
        public string LastName { get; set; }
        [XmlElement]
        public string UserName { get; set; }
    }
}