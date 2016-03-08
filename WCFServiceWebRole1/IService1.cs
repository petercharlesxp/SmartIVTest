using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Channels;
using System.IO;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here


        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Notification?APIKey={APIKey}&DeviceID={DeviceID}&Message={Message}")]

        void SendAdnoirdPush(string APIKey, string DeviceID, string Message);



        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "notify1")]
        void SendAdnoirdPush1();

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "notify2")]

        void SendAdnoirdPush2();

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "notify3")]

        void SendAdnoirdPush3();


        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "notifyApple")]

        void iosPushNotification();


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "notifytest")]
        void SendAdnoirdPushTest();


        [OperationContract]
        [WebInvoke(Method ="POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "LoginValidation"
          )]
        
        Stream ValidateLogin(LoginCredential l);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SubscribeNotification")]
        Stream Subscribe(SubscriptionControlN s);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UnSubscribeNotification")]
        Stream UnSubscribe(SubscriptionControl s);

       

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "PatientInfo")]
        Stream PatientInfo(SubscriptionControl s);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "NurseOnShift")]
        Stream NurseInfo(SubscriptionControl s);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "LoginValidationTest?UserName={UserName}&Password={Password}")]
        object ValidateLoginTest(string UserName, string Password);


        [OperationContract]
        [WebInvoke (Method ="GET",
        ResponseFormat=WebMessageFormat.Json,
        RequestFormat=WebMessageFormat.Json,
        UriTemplate="DecimalCheck/Value={Value}")]
        void decimalCheck(string Value);


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "getDeviceInfo")]
        Stream getDeviceInfo(Argu_Patient_INFO a);


        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "setDeviceInfo?deviceMacId={deviceMacId}&deviceCurrentWeight={deviceCurrentWeight}&deviceBatteryStatus={deviceBatteryStatus}&deviceTimeStamp={deviceTimeStamp}")]
        Stream setDeviceInfo(String deviceMacId, String deviceCurrentWeight, String deviceBatteryStatus, String deviceTimeStamp);




        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "expire_SessionToken")]

         Stream expire_SessionToken(SubscriptionControl l);



       

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

    [DataContract]
    public class LoginCredential
    {
        [DataMember(Order=1)]
        public string username { get; set ; }

        [DataMember(Order=2)]
        public string password {get; set ;  }
    }

    [DataContract]
    public class SubscriptionControl
    {
        [DataMember(Order = 1)]
        public int UserId { get; set; }
        
        [DataMember(Order = 2)]
        public string DeviceId {get; set;}
        
    }

    [DataContract]
    public class SubscriptionControlN
    {
        [DataMember(Order = 1)]
        public int UserId { get; set; }

        [DataMember(Order = 2)]
        public string DeviceId { get; set; }

        [DataMember(Order = 3)]
        public string DeviceType { get; set; }
  
    }


    [DataContract]
    public class  Argu_Patient_INFO
    {

         [DataMember(Order = 1)]
        public string DeviceMacId { get; set; }

    }

}
