using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using PushSharp;
using PushSharp.Android;
using PushSharp.Apple;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
     //public static string defaultConnectionString = "Server=127.0.0.1;Database=smartiv; UID=root;Password=password";

       public static string defaultConnectionString ="Database=WIMTACH;Data Source=us-cdbr-azure-east-a.cloudapp.net;User Id=b5fd73cb17df05;Password=9a877923";
        // public static string defaultConnectionString = "Database=SmartIV;Data Source=us-cdbr-azure-east-a.cloudapp.net;User Id=be81889f75498e;Password=8135b687cb1429f";
       MySqlConnection connection;
       MySqlCommand cmd;
       MySqlDataReader reader;

       public void InitializeSQLDEP()
       {
          
       }
        public string GetData(int value)
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
        
        public void SendAdnoirdPush(string APIKey, string DeviceID, string Message)
        {
            String title = "\"Test\"";
            String alert = "\"Hey\"";
            APIKey = "AIzaSyDUTS8zW5vlml5QXsqXZaLguMI75QKUUao";
            DeviceID = "APA91bHhmqJTYoam6e5IDLiVEERJopvZHMaOSW6T2SjTOVXlOcV6Fg327-r9sVizE4s5qZA-dPtpHUFBVfliP7xqKZtu_3eozVaeaMVjCo_Amy27reUD337zWv5OxNioJvkN2RgwOb0-";
            //String s = "{ \"type\": \"callback\", \"source\": { \"pushType\": \"gcm\", \"invocationAPIs\": [], \"bubbleParent\": \"\"true\"\", \"showTrayNotification\": \"\"true\"\", \"enabled\": \"false\", \"__propertiesDefined__\": \"\"true\"\", \"singleCallback\": \"false\", \"_events\": { \"callback\": {}, \"trayClickLaunchedApp\": {}, \"trayClickFocusedApp\": {} }, \"focusAppOnPush\": \"false\", \"debug\": \"\"true\"\", \"showAppOnTrayClick\": \"\"true\"\", \"showTrayNotificationsWhenFocused\": \"\"true\"\", \"apiName\": \"Ti.Module\" }, \"payload\": \"{\"android\":{\"title\":\"Test\",\"sound\":\"none\",\"alert\":\"Hi\",\"vibrate\":\"false\",\"badge\":\"\"}}\", \"bubbles\": \"false\", \"cancelBubble\": \"false\" }";
            String s2 = "{ \"type\": \"callback\", \"source\": {  \"pushType\": \"gcm\", \"invocationAPIs\": [], \"bubbleParent\": true, \"showTrayNotification\": true, \"enabled\": false, \"__propertiesDefined__\": true, \"singleCallback\": false,\"_events\": { \"callback\": {}, \"trayClickLaunchedApp\": {}, \"trayClickFocusedApp\": {} }, \"focusAppOnPush\":false, \"debug\":true, \"showAppOnTrayClick\":true, \"showTrayNotificationsWhenFocused\": true, \"apiName\": \"Ti.Module\", }, \"payload\": {\"android\":{ \"title\":" + title + ",\"sound\":\"none\",\"alert\":" + alert + ",\"vibrate\":true,\"badge\":\"+1\",\"icon\":\"appicon48\"}} ,\"bubbles\":true, \"cancelBubble\":true     }";
            var push = new PushBroker();
            push.RegisterGcmService(new GcmPushChannelSettings(APIKey), "577549764384");
            push.QueueNotification(new GcmNotification().ForDeviceRegistrationId(DeviceID)
                   .WithJson(s2), "577549764384");



            //"{payload:" + s + "}"
            //return "Notification has been send";

        }
        public void SendAdnoirdPush1()
        {
            String title = "\"Test\"";
            String alert = "\"Hey This is the first Notification\"";
            String APIKey = "AIzaSyDUTS8zW5vlml5QXsqXZaLguMI75QKUUao";
            String DeviceID = "APA91bHhmqJTYoam6e5IDLiVEERJopvZHMaOSW6T2SjTOVXlOcV6Fg327-r9sVizE4s5qZA-dPtpHUFBVfliP7xqKZtu_3eozVaeaMVjCo_Amy27reUD337zWv5OxNioJvkN2RgwOb0-";

            String s2 = "{ \"type\": \"callback\", \"source\": {  \"pushType\": \"gcm\", \"invocationAPIs\": [], \"bubbleParent\": true, \"showTrayNotification\": true, \"enabled\": false, \"__propertiesDefined__\": true, \"singleCallback\": false,\"_events\": { \"callback\": {}, \"trayClickLaunchedApp\": {}, \"trayClickFocusedApp\": {} }, \"focusAppOnPush\":false, \"debug\":true, \"showAppOnTrayClick\":true, \"showTrayNotificationsWhenFocused\": true, \"apiName\": \"Ti.Module\", }, \"payload\": {\"android\":{ \"title\":" + title + ",\"sound\":\"Notification1.mp3\",\"alert\":" + alert + ",\"vibrate\":true,\"badge\":\"+1\",\"icon\":\"appicon_max\"}} ,\"bubbles\":true, \"cancelBubble\":true     }";
            var push = new PushBroker();
            push.RegisterGcmService(new GcmPushChannelSettings(APIKey), "577549764384");
            push.QueueNotification(new GcmNotification().ForDeviceRegistrationId(DeviceID)
                   .WithJson(s2), "577549764384");


            //return "Notification has been send";

        }
        public void SendAdnoirdPush2()
        {
            String title = "\"Test\"";
            String alert = "\"Hey\"";
            String APIKey = "AIzaSyDUTS8zW5vlml5QXsqXZaLguMI75QKUUao";
            String DeviceID = "APA91bHhmqJTYoam6e5IDLiVEERJopvZHMaOSW6T2SjTOVXlOcV6Fg327-r9sVizE4s5qZA-dPtpHUFBVfliP7xqKZtu_3eozVaeaMVjCo_Amy27reUD337zWv5OxNioJvkN2RgwOb0-";

            String s2 = "{ \"type\": \"callback\", \"source\": {  \"pushType\": \"gcm\", \"invocationAPIs\": [], \"bubbleParent\": true, \"showTrayNotification\": true, \"enabled\": false, \"__propertiesDefined__\": true, \"singleCallback\": false,\"_events\": { \"callback\": {}, \"trayClickLaunchedApp\": {}, \"trayClickFocusedApp\": {} }, \"focusAppOnPush\":false, \"debug\":true, \"showAppOnTrayClick\":true, \"showTrayNotificationsWhenFocused\": true, \"apiName\": \"Ti.Module\", }, \"payload\": {\"android\":{ \"title\":" + title + ",\"sound\":\"Notification2.mp3\",\"alert\":" + alert + ",\"vibrate\":true,\"badge\":\"+1\",\"icon\":\"appicon_med\"}} ,\"bubbles\":true, \"cancelBubble\":true     }";
            var push = new PushBroker();
            push.RegisterGcmService(new GcmPushChannelSettings(APIKey), "577549764384");
            push.QueueNotification(new GcmNotification().ForDeviceRegistrationId(DeviceID)
                   .WithJson(s2), "577549764384");


            //return "Notification has been send";

        }
        public void SendAdnoirdPush3()
        {
            String title = "\"Test\"";
            String alert = "\"Hey\"";
            String APIKey = "AIzaSyDUTS8zW5vlml5QXsqXZaLguMI75QKUUao";
            String DeviceID = "APA91bHhmqJTYoam6e5IDLiVEERJopvZHMaOSW6T2SjTOVXlOcV6Fg327-r9sVizE4s5qZA-dPtpHUFBVfliP7xqKZtu_3eozVaeaMVjCo_Amy27reUD337zWv5OxNioJvkN2RgwOb0-";

            String s2 = "{ \"type\": \"callback\", \"source\": {  \"pushType\": \"gcm\", \"invocationAPIs\": [], \"bubbleParent\": true, \"showTrayNotification\": true, \"enabled\": false, \"__propertiesDefined__\": true, \"singleCallback\": false,\"_events\": { \"callback\": {}, \"trayClickLaunchedApp\": {}, \"trayClickFocusedApp\": {} }, \"focusAppOnPush\":false, \"debug\":true, \"showAppOnTrayClick\":true, \"showTrayNotificationsWhenFocused\": true, \"apiName\": \"Ti.Module\", }, \"payload\": {\"android\":{ \"title\":" + title + ",\"sound\":\"Notification3.mp3\",\"alert\":" + alert + ",\"vibrate\":true,\"badge\":\"+1\",\"icon\":\"appicon_low\"}} ,\"bubbles\":true, \"cancelBubble\":true     }";
            var push = new PushBroker();
            push.RegisterGcmService(new GcmPushChannelSettings(APIKey), "577549764384");
            push.QueueNotification(new GcmNotification().ForDeviceRegistrationId(DeviceID)
                   .WithJson(s2), "577549764384");


            //return "Notification has been send";

        }
        public void SendAdnoirdPushTest()
        {
            String title = "\"Test\"";
            String alert = "\"Hey This is the first Notification\"";
            string APIKey = "AIzaSyB5vdoi9tcoTvpPf-PVTZO6U7PkE2-o7vo";
            String[] DeviceID
                = {"APA91bHkTgk6Vc3lfOOlCXvOuo8FOf3cJW0vM3QJDAQrhbawUFH7lHnK73Xn77Ij4wnQnjPOG_OmgPpne2iUx3ChBxXAQHgOnj4q3T7Ic4FoRofg4pPQuAEP2UlFqu0lygwoQzHg73PN",
                  "APA91bF1aBTS_iA6kAjlpLfNfxcHYL8MSXJ3VYZo0YStmOz4xVSlaDbQ-SgFE1p5ypineayGI5uV60GhNIsGpVeq6t6egVouMY_fqyt3dgQhYmVb1FIQGaPy8gUGznVYCAdIWA-mjbQ9",
                  "APA91bEebvSMXxP4tCNSiA1LgSErxY-oAbO5yuGFeHe4pFzA-oQezVNQtJzel9ulB5MXt9UMR-FPbbTTAAWGM4f6MYHIOgCjHE959YODPTiLF6XG1UqjH15DwaM0vqaqgT6DHaq53PC6",
                  "APA91bHI_vuxK0U6LHQ-QbSpM7Y5Z0_yAoCTHHtYX9DNDdOCbU5_Zrh7nT8WyQRmPxTeXIgsdBO_UH2dxPQYSKpm-ka8VualgIATEs2tP02V6TrMYeZH0jRJb7RnSCPCGUt8VMZTgbqe",
                  "APA91bGg1ji1CX-aEgYAnbSKlRo-IE50qhCRi7BbzjO4j1L6rIFHk94vBCXCRe6Dc4-iQ7hyuhFnSlzUEvxROdbW2UdXRpr1GxjBOXFCUuUr1z3LxaHBYFwpVya0wtmHCxVLOZppda4v"};
            String s = "{ \"type\": \"callback\", \"source\": {  \"pushType\": \"gcm\", \"invocationAPIs\": [], \"bubbleParent\": true, \"showTrayNotification\": true, \"enabled\": false, \"__propertiesDefined__\": true, \"singleCallback\": false,\"_events\": { \"callback\": {}, \"trayClickLaunchedApp\": {}, \"trayClickFocusedApp\": {} }, \"focusAppOnPush\":false, \"debug\":true, \"showAppOnTrayClick\":true, \"showTrayNotificationsWhenFocused\": true, \"apiName\": \"Ti.Module\", }, \"payload\": {\"android\":{ \"title\":" + title + ",\"sound\":\"Notification.mp3\",\"alert\":" + alert + ",\"vibrate\":true,\"badge\":\"+1\",\"icon\":\"appicon_low\"}} ,\"bubbles\":true, \"cancelBubble\":true     }";

            for (int i = 0; i < DeviceID.Length; i++)
            {
                var push = new PushBroker();
                push.RegisterGcmService(new GcmPushChannelSettings(APIKey), "577549764384");
                push.QueueNotification(new GcmNotification().ForDeviceRegistrationId(DeviceID[i])
                        .WithJson(s), "577549764384");
                
                //return "Notification has been send";

            }

        }

        public void push()
        {
            string QUERY="";
            try
            {
                connection = new MySqlConnection(defaultConnectionString);
                cmd = new MySqlCommand();
                cmd.CommandText = QUERY;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();



            


            }
            catch (Exception E)
            {

            }


        }


/*
        public void SendNotification()
        {
                AppleNotificationPayload ap=new AppleNotificationPayload();
           
             var push = new PushBroker();  
             var appleCert = File.ReadAllBytes(new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath) + "/pushNotificatio.p12");  
             push.RegisterAppleService(new ApplePushChannelSettings);  
             push.QueueNotification(new AppleNotification()  
                           .ForDeviceToken(DeviceID).WithPayload(ap);
             //.WithSound("sound.caf")); //default  
 


        }

        */

        public Stream DeviceInfo(string DeviceId, string DeviceStatus, string Weight)
        {
            var dictionary = new Dictionary<string, object>();
            string json;
            string query = "INSERT INTO wimtach.device(deviceMacId,deviceStatus,deviceInfo)VALUES('" + DeviceId + "','" + DeviceStatus + "','" + Weight + "');";
            try
            {
                connection = new MySqlConnection(defaultConnectionString);
                cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                int a = cmd.ExecuteNonQuery();
               

                dictionary.Add("responseStatus", "SUCCESS");
                dictionary.Add("responseObject", "Device Log inserted at time"+DateTime.Now);
                dictionary["errors"] = "";
                json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                cmd = null;
                connection.Close();
            }
            catch (Exception e)
            {
                return new MemoryStream(Encoding.UTF8.GetBytes(e.Message));
                
            }

            return new MemoryStream(Encoding.UTF8.GetBytes(json)); 
        }


        ////Methods Used For Login Service 

        public Stream ValidateLogin(LoginCredential l)
        {
           // string log="";
                var dictionary = new Dictionary<string, object>();
                string json;
                string query = "SELECT * FROM WIMTACH.user where Binary userName='"+ l.username +"'and password='" + l.password +"';";
            try
            {       


                Boolean expire_Session=false;
                if(checkValidUserName(l.username)){
                   expire_Session= expire_SessionToken(l.username);
                }
                else
                {
                    dictionary.Add("responseStatus", "ERROR");
                    dictionary.Add("responseObject", null);
                    dictionary.Add("errors", "INVALID USERNAME");
                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                    return new MemoryStream(Encoding.UTF8.GetBytes(json));

                }


                if (expire_Session)
                { 
               // createlog("finall UserName and Password : |" + l.username + "|" + l.password + "|");
              //  createlog("final :" + query);
                                connection = new MySqlConnection(defaultConnectionString);
                                cmd = new MySqlCommand();   
                                cmd.CommandText = query;
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = connection;
                                connection.Open();
                                reader= cmd.ExecuteReader();

                                var r = Serialize(reader);
                                Boolean b = reader.HasRows;
                                if (!reader.HasRows)
                                {
                                    dictionary.Add("responseStatus", "ERROR");
                                    dictionary.Add("responseObject", null);
                                    dictionary.Add("errors", "");
                                    if (checkValidUserName(l.username))
                                        {
                                            dictionary["errors"] = "Invalid Password";
                                        }
                                    else
                                        {
                                            dictionary["errors"] = "Invalid UserName";
                                        }

                                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                                    connection.Close();
                                    return new MemoryStream(Encoding.UTF8.GetBytes(json));
                                }

                                if (Login_TimeStamp(l.username))
                                {
                                    dictionary.Add("responseStatus", "SUCCESS");
                                    dictionary.Add("responseObject", r);
                                    dictionary.Add("errors", "");
                                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                                    // Checks if its valid or not
                                    connection.Close();
                                    return new MemoryStream(Encoding.UTF8.GetBytes(json));
                                }
                                else
                                {
                                    dictionary.Add("responseStatus", "SUCCESS");
                                    dictionary.Add("responseObject", r);
                                    dictionary.Add("errors", "LOGIN TIME NOT RECORED");
                                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                                    // Checks if its valid or not
                                    connection.Close();
                                    return new MemoryStream(Encoding.UTF8.GetBytes(json));
                                }

                }
                else
                {
                    dictionary.Add("responseStatus", "ERROR");
                    dictionary.Add("responseObject", null);
                    dictionary.Add("errors", "Error In Session Expiration");
                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                    return new MemoryStream(Encoding.UTF8.GetBytes(json));
                }
            }
            catch (Exception)
            {
                throw;
            }

    
        }

        public Stream expire_SessionToken(SubscriptionControl l)
        {

            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            string applicationSessionKey = request.Headers["X-SmartIV-SessionKey"];
            var dictionary = new Dictionary<string, object>();
            string json;
            if (checkSeesionToken(applicationSessionKey))
            {
                string query = "UPDATE wimtach.user SET sessionKey = md5(uuid()) WHERE userId =" + l.UserId + ";";
                try
                {
                    connection = new MySqlConnection(defaultConnectionString);
                    cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    connection.Open();
                    int a = cmd.ExecuteNonQuery();


                    dictionary.Add("responseStatus", "SUCCESS");
                    dictionary.Add("responseObject", "Session Expired");
                    dictionary["errors"] = "";
                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                    cmd = null;
                    connection.Close();
                }
                catch (Exception e)
                {
                    dictionary.Add("responseStatus", "ERROR");
                    dictionary.Add("responseObject", e.Data);
                    dictionary["errors"] = e.Message;
                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                }
            }
            else
            {
                dictionary.Add("responseStatus", "ERROR");
                dictionary.Add("responseObject", null);
                dictionary.Add("errors", 0);
                json = JsonConvert.SerializeObject(dictionary, Formatting.None);

            }

                return  new MemoryStream(Encoding.UTF8.GetBytes(json));

        }

        public Stream Subscribe(SubscriptionControlN s)
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            string applicationSessionKey = request.Headers["X-SmartIV-SessionKey"];
            var dictionary = new Dictionary<string, object>();
            string query = "INSERT INTO WIMTACH.subscription(deviceId,userId,deviceType)VALUES('"+s.DeviceId+"',"+s.UserId+",'"+s.DeviceType+"');";
            string json="";
            if (checkSeesionToken(applicationSessionKey))
            {
                try
                {
                    connection = new MySqlConnection(defaultConnectionString);
                    cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    connection.Open();
                    int a= cmd.ExecuteNonQuery();
                    //var r = Serialize(reader);
                      
                    dictionary.Add("responseStatus", "SUCCESS");
                    dictionary.Add("responseObject", "You are now Subscribed for notification" );
                    dictionary["errors"] = "";
                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                    cmd = null;
                    connection.Close();
                    
                }
                catch (Exception e)
                { 
                    
                    dictionary.Add("responseStatus", "ERROR");
                    dictionary.Add("responseObject",e.Data);
                    dictionary["errors"] = e.Message;
                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                   // throw;
                }

            }
            else
            {
                dictionary.Add("responseStatus", "ERROR");
                dictionary.Add("responseObject", null);
                dictionary.Add("errors", 0);
                json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                
            }
            return new MemoryStream(Encoding.UTF8.GetBytes(json));
        }

        public Stream UnSubscribe(SubscriptionControl s)
        {

            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            string applicationSessionKey = request.Headers["X-SmartIV-SessionKey"];
            var dictionary = new Dictionary<string, object>();
            string query = "DELETE FROM WIMTACH.subscription WHERE binary deviceId='" + s.DeviceId+"';";
            string json = "";
            if (checkSeesionToken(applicationSessionKey))
            {
                try
                {
                    connection = new MySqlConnection(defaultConnectionString);
                    cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    connection.Open();
                    int a= cmd.ExecuteNonQuery();
                    dictionary.Add("responseStatus", "SUCCESS");
                    dictionary.Add("responseObject", "You are now UnSubscribed for notification");
                    dictionary["errors"] = "";
                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                    cmd = null;
                    connection.Close();
                   
                }
                catch (Exception e)
                {
                    dictionary.Add("responseStatus", "ERROR");
                    dictionary.Add("responseObject", "e.data");
                    dictionary.Add("errors", e.Message); ;
                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                    throw;
                }

            }
            else
            {
                dictionary.Add("responseStatus", "ERROR");
                dictionary.Add("responseObject", null);
                dictionary.Add("errors", 0);
                json = JsonConvert.SerializeObject(dictionary, Formatting.None);
               
            }
            return new MemoryStream(Encoding.UTF8.GetBytes(json));
        }

        public Stream PatientInfo(SubscriptionControl s)
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            string applicationSessionKey = request.Headers["X-SmartIV-SessionKey"];
            var dictionary = new Dictionary<string, object>();
            string json;
            string query = "Select * from patientbasicinfo where patientID IN (SELECT patientID FROM wimtach.patientadmissioninfo where nurseId in (select  nurseId from  wimtach.nurse where userId in (Select userId from wimtach.user where userId ="+s.UserId+"))) ;";
            if (checkSeesionToken(applicationSessionKey))
            {
                                        try
                                        {
                                            connection = new MySqlConnection(defaultConnectionString);
                                            cmd = new MySqlCommand();
                                            cmd.CommandText = query;
                                            cmd.CommandType = CommandType.Text;
                                            cmd.Connection = connection;
                                            connection.Open();
                                            reader= cmd.ExecuteReader();
                                            var r = Serialize(reader);

                                                    if (reader.HasRows)
                                                    {
                                                        dictionary.Add("responseStatus", "SUCCESS");
                                                        dictionary.Add("responseObject", r);
                                                        dictionary["errors"] = "";
                                                        json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                                                   
                                                    }
                                                    else {
                                                        dictionary.Add("responseStatus", "SUCCESS");
                                                        dictionary.Add("responseObject", "No Records Found");
                                                        dictionary["errors"] = "";
                                                        json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                                                    
                                                    }
                                        }
                                        catch (Exception e)
                                        {
                                            dictionary.Add("responseStatus", "ERROR");
                                            dictionary.Add("responseObject", e.Data);
                                            dictionary["errors"] = e.Message;
                                            json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                                      
                                        }
                                finally{
                                      connection.Close();
                                }
                        }
                        else {
                            dictionary.Add("responseStatus", "ERROR");
                            dictionary.Add("responseObject", null);
                            dictionary.Add("errors", 0);
                            json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                        
                        }

                        return new MemoryStream(Encoding.UTF8.GetBytes(json)); 

        }

        public Stream NurseInfo(SubscriptionControl s)
        {

            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            string applicationSessionKey = request.Headers["X-SmartIV-SessionKey"];
            var dictionary = new Dictionary<string, object>();
            string json;
            string query = "select firstName, lastName from nurse where currentShift = 'True' AND userId in (SELECT userId FROM wimtach.subscription);";

            if (checkSeesionToken(applicationSessionKey))
            {
                try
                {
                    connection = new MySqlConnection(defaultConnectionString);
                    cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    connection.Open();
                    reader = cmd.ExecuteReader();
                    var r = Serialize(reader);
                    
                    if (reader.HasRows)
                    {
                        dictionary.Add("responseStatus", "SUCCESS");
                        dictionary.Add("responseObject", r);
                        dictionary["errors"] = "";
                        json = JsonConvert.SerializeObject(dictionary, Formatting.None);

                    }
                    else
                    {
                        dictionary.Add("responseStatus", "SUCCESS");
                        dictionary.Add("responseObject", "No Record Found");
                        dictionary["errors"] = "";
                        json = JsonConvert.SerializeObject(dictionary, Formatting.None);

                    }


                }
                catch (Exception e)
                {
                    dictionary.Add("responseStatus", "ERROR");
                    dictionary.Add("responseObject", e.Data);
                    dictionary["errors"] = e.Message;
                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                }
            }
            else
            {
                dictionary.Add("responseStatus", "ERROR");
                dictionary.Add("responseObject", null);
                dictionary.Add("errors", 0);
                json = JsonConvert.SerializeObject(dictionary, Formatting.None);

            }

             return new MemoryStream(Encoding.UTF8.GetBytes(json));
        }

        public object ValidateLoginTest(string UserName, string Password)
        {
            throw new NotImplementedException();
        }

        public Stream getDeviceInfo(Argu_Patient_INFO a){


            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            string applicationSessionKey = request.Headers["X-SmartIV-SessionKey"];
            var dictionary = new Dictionary<string, object>();
            string json;
            string query = "Select * from wimtach.devicerecordlogs where deviceMacId='" + a.DeviceMacId + "'  order by ServerTimeStamp desc limit 5;";
            if (checkSeesionToken(applicationSessionKey))
            {
                                        try
                                        {
                                            connection = new MySqlConnection(defaultConnectionString);
                                            cmd = new MySqlCommand();
                                            cmd.CommandText = query;
                                            cmd.CommandType = CommandType.Text;
                                            cmd.Connection = connection;
                                            connection.Open();
                                            reader = cmd.ExecuteReader();
                                            var r = Serialize(reader);
                                            Boolean b = reader.HasRows;
                                                                         if (b)
                                                                         {
                                                                             dictionary.Add("responseStatus", "SUCCESS");
                                                                             dictionary.Add("responseObject", r);
                                                                             dictionary.Add("errors", "");
                                                                             json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                                                                             // Checks if its valid or not
                                                                             connection.Close();
                                                                             return new MemoryStream(Encoding.UTF8.GetBytes(json));
                                                                         }
                                                                         else
                                                                         {
                                                                             dictionary.Add("responseStatus", "Error");
                                                                             dictionary.Add("responseObject", null);
                                                                             dictionary.Add("errors", 1);
                                                                             json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                                                                             // Checks if its valid or not
                                                                             connection.Close();
                                                                             return new MemoryStream(Encoding.UTF8.GetBytes(json));

                                                                         }
                                        }
                                        catch (Exception e)
                                        {
                                            dictionary.Add("responseStatus", "Error");
                                            dictionary.Add("responseObject", e.Data);
                                            dictionary.Add("errors", e.Message);
                                            json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                                            // Checks if its valid or not
                                            connection.Close();
                                            return new MemoryStream(Encoding.UTF8.GetBytes(json));
                                            throw;
                                        }
            }
            else
            {
                dictionary.Add("responseStatus", "ERROR");
                dictionary.Add("responseObject", null);
                dictionary.Add("errors",0);
                json = JsonConvert.SerializeObject(dictionary, Formatting.None);
            }

            connection.Close();
            return new MemoryStream(Encoding.UTF8.GetBytes(json));
        
        }

        public Stream setDeviceInfo(String deviceMacId, String deviceCurrentWeight, String deviceBatteryStatus , String deviceTimeStamp )
        {

            var dictionary = new Dictionary<string, object>();
            string json;
            string query = "INSERT INTO wimtach.devicerecordlogs(deviceMacId,deviceCurrentWeight,deviceBatteryStatus,deviceTimeStamp)VALUES('" + deviceMacId + "','" + deviceCurrentWeight + "','" + deviceBatteryStatus + "','" + deviceTimeStamp + "');";
            string query2="UPDATE wimtach.patientbasicinfo SET deviceCurrentWeight ='"+deviceCurrentWeight+"', deviceTimeStamp = '"+deviceTimeStamp+"' , deviceCurrentBattery='"+deviceBatteryStatus+"' WHERE deviceMacID ='"+deviceMacId+"';";
            try
            {
                connection = new MySqlConnection(defaultConnectionString);
                cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                int a=  cmd.ExecuteNonQuery();
                cmd.CommandText = query2;
                int b = cmd.ExecuteNonQuery();
                if (a > 0 && b > 0)
                {
                    dictionary.Add("responseStatus", "SUCCESS");
                    dictionary.Add("responseObject","Number Of Row inserted" +a + b );
                    dictionary.Add("errors", "");
                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                  
                    connection.Close();
                    return new MemoryStream(Encoding.UTF8.GetBytes(json));
                }
                else
                {
                    dictionary.Add("responseStatus", "ERROR");
                    dictionary.Add("responseObject", "Number Of Row inserted" + a);
                    dictionary.Add("errors", "");
                    json = JsonConvert.SerializeObject(dictionary, Formatting.None);
                   
                    connection.Close();
                    return new MemoryStream(Encoding.UTF8.GetBytes(json));
                }



            }catch(Exception e){
                dictionary.Add("responseStatus", "ERROR");
                dictionary.Add("responseObject", e.Data);
                dictionary.Add("errors", e.Message);
                json = JsonConvert.SerializeObject(dictionary, Formatting.None);          
                connection.Close();
                return new MemoryStream(Encoding.UTF8.GetBytes(json));

            }

            
        }

        /* NON-Contract methods */

        public  void decimalCheck(string Value)
        {
            createlog("Checking levels at device " +Value);
        }
        public  Boolean checkValidUserName(string UserName)
        {
            try
            {
                string query = "SELECT * FROM WIMTACH.user where Binary userName='" + UserName + "';";
                connection = new MySqlConnection(defaultConnectionString);
                cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();
                Boolean a = reader.HasRows;
                connection.Close();
                return a;
            }
            catch(Exception)
            {
            }
            return false;
        }
        public  void createlog(string log)
        {
            string query = "INSERT INTO WIMTACH.serverlogs(message)VALUES('"+log+"')";
            try
            {
                connection = new MySqlConnection(defaultConnectionString);
                cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                int a=cmd.ExecuteNonQuery();
                int b = a;
                connection.Close();
            }
            catch(Exception){
                throw;
            }
        }
        public  Boolean checkSeesionToken(string token)
        {

            token.ToString();
            string query = "select * FROM WIMTACH.user where sessionKey='"+token+"';";
            connection = new MySqlConnection(defaultConnectionString);
            cmd = new MySqlCommand();
            Boolean b ;
            try
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();
                b = reader.HasRows;
                cmd = null;
            }
            catch (Exception)
            {
                throw ;
            }
            finally
            {
                connection.Close();
            }
            return b;
        }
        public Boolean expire_SessionToken(String userName)
        {
            string query = "UPDATE wimtach.user SET sessionKey = md5(uuid()) WHERE userName ='" + userName + "';";
            connection = new MySqlConnection(defaultConnectionString);
            cmd = new MySqlCommand();
            try
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                int a = cmd.ExecuteNonQuery();
                connection.Close();
                if (a==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception e){
                return false;
            }
        }
        public Boolean Login_TimeStamp(String userName)
        {
            string query = "UPDATE wimtach.user SET lastLogIn = NOW() WHERE userName ='" + userName + "';";
            connection = new MySqlConnection(defaultConnectionString);
            cmd = new MySqlCommand();
            try
            {
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                int a = cmd.ExecuteNonQuery();
                connection.Close();
                if (a == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public IEnumerable<Dictionary<string, object>> Serialize(MySqlDataReader reader)
        {
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));

            return results;
        }
        private Dictionary<string, object> SerializeRow(IEnumerable<string> cols,
                                                        MySqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
                result.Add(col, reader[col]);
            return result;
        }


        public void iosPushNotification()
        {
           

            var push = new PushBroker();
            AppleNotificationPayload ap =new AppleNotificationPayload("{code = 0;data={alert ="+"hi hi hi hi hi"+";aps ={alert = "+"hi hi hi hi hi"+";sound = default;};sound = default;title = asdfasdg;vibrate = true;};inBackground = 1;source = "+"[object NetworkModule]"+"; success = 1;type = remote;}");
            AppleNotificationPayload bap = new AppleNotificationPayload();
            bap.Sound = "Notification.wav";
            bap.AddCustom("vibrate", true);
            //bap.AddCustom("aps", "{alert = " + "hi hi hi hi hi" + ";sound = default;}");
            //bap.AddCustom("sound", "Notification.wav");
            //bap.AddCustom("alert", "Your IV Level Is Low");
            push.RegisterAppleService(new ApplePushChannelSettings(false,  WCFServiceWebRole1.Properties.Resources.appleCert, "123456789"));
            push.QueueNotification(new AppleNotification()
                                        .ForDeviceToken("b55e79da0ff8f4ec4178e181ffcb512122d39c6652ef0df8a2b9a2c1320acc7d")
                                        //.WithCustomItem("vibrate", true)
                                        //.WithBadge(1)
                                        .WithPayload(bap)
                                        .WithAlert("Your IV Level is low")//the message
                                       //.WithSound("Notification")
                                        //.WithAlert("Your IV level is low")
                                        //the recipient device id
                                        );

            
        }
    }
}
