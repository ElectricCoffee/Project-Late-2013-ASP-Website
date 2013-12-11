using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace BookingSite.Utils
{
    public static class ServerCommunicator
    {
        public const string SERVER_URI = "http://localhost:14781/api/";
        private const string
            APPLICATION_JSON = "application/json",
            RESPONSE_PUT     = "PUT",
            RESPONSE_POST    = "POST",
            RESPONSE_DELETE  = "DELETE";

        #region Helper methods
        private static void CommunicationHelper(string inputUri, Action<WebClient, Uri> clientfunction)
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = APPLICATION_JSON;
            var uri = new Uri(inputUri);
            clientfunction(client, uri);
        }

        private static void Request(string inputUri, string method, string input)
        {
            CommunicationHelper(inputUri, (client, uri) => client.UploadString(uri, method, input));
        }
        
        private static void RequestAsync(string inputUri, string method, string input)
        {
            CommunicationHelper(inputUri, (client, uri) => client.UploadStringAsync(uri, method, input));
        }

        #endregion

        #region Get
        public static string Get(string inputUri) 
        {
            string result = "";
            CommunicationHelper(inputUri, (client, uri) => result = client.DownloadString(uri));
            return result;
        }

        public static void GetAsync(string inputUri, DownloadStringCompletedEventHandler downloadStringCompleted)
        {
            CommunicationHelper(inputUri, (client, uri) =>
            { 
                client.DownloadStringCompleted += downloadStringCompleted;
                client.DownloadStringAsync(uri);
            });
        }
        #endregion

        #region Put
        public static void Put(string inputUri, string jsonInput) { Request(inputUri, RESPONSE_PUT, jsonInput); }

        public static void PutAsync(string inputUri, string jsonInput) { RequestAsync(inputUri, RESPONSE_PUT, jsonInput); }
        #endregion

        #region Post
        public static void Post(string inputUri, string jsonInput) { Request(inputUri, RESPONSE_POST, jsonInput); }

        public static void PostAsync(string inputUri, string jsonInput) { RequestAsync(inputUri, RESPONSE_POST, jsonInput); }
        #endregion

        #region Delete
        public static void Delete(string inputUri) { Request(inputUri, RESPONSE_DELETE, ""); }

        public static void DeleteAsync(string inputUri) { RequestAsync(inputUri, RESPONSE_DELETE, ""); }
        #endregion
    }
} 