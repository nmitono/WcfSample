using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UsersWcfServiceSample
{
    [ServiceContract]
    public interface IUserService
    {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Xml, UriTemplate = "GetData/{value}/")]
        string GetData(string value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Xml, UriTemplate = "GetUsers/")]
        List<User> GetUsers();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Xml, UriTemplate = "GetUser/{id}")]
        User GetUser(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "PostUser",
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare)]
        int PostUser(User user);

        [OperationContract]
        [XmlSerializerFormat]
        [WebGet(ResponseFormat = WebMessageFormat.Xml, UriTemplate = "GetUserXmlSerializer/{id}")]
        XmlSerializerUser GetUserXmlSerializer(string id);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
