using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
// Service URL : http://localhost:64862/Service1.svc

namespace AWT_Assgn1_T3_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string HelloWorld(string value);

        //[OperationContract]
        //string SearchCommodity(string message);

        [OperationContract]
        string AddCommodity(CommDetails CommInfo);
        
        
        [OperationContract]
        string ListAllLaptops();

        [OperationContract]
        string SearchCommodity(string Keyword);

        [OperationContract]
        string AddNewFeature(string Typeno, string Featureno, string Feature);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CommDetails
    {
        string id = string.Empty;
        string name = string.Empty;
        string typeno = string.Empty;
        string type = string.Empty;
        string price = string.Empty;
        string brand = string.Empty;
        string size = string.Empty;
        string stock = string.Empty;

        [DataMember]
        public string Id
        {
            get { return id;  }
            set { id = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        [DataMember]
        public string Typeno
        {
            get { return typeno; }
            set { typeno = value; }
        }
        [DataMember]
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        [DataMember]
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        [DataMember]
        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        [DataMember]
        public string Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }

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
