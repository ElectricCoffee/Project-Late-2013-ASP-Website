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
        private const string
            APPLICATION_JSON = "application/json",
            RESPONSE_POST    = "POST",
            RESPONSE_DELETE  = "DELETE";

        private static void CommunicationHelper(string inputUri, Action<WebClient, Uri> clientfunction)
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = APPLICATION_JSON;
            var uri = new Uri(inputUri);
            clientfunction(client, uri);
        }

        public static string Get(string inputUri) 
        {
            string result = "";
            CommunicationHelper(inputUri, (client, uri) => result = client.DownloadString(uri));
            return result;
        }

        public static void GetAsync(string inputUri, DownloadStringCompletedEventHandler downloadStringCompleted)
        {
            CommunicationHelper(inputUri, (client, uri) => { 
                client.DownloadStringCompleted += downloadStringCompleted;
                client.DownloadStringAsync(uri);
            });
        }

        public static void Post(string inputUri, string jsonInput)
        {
            CommunicationHelper(inputUri, (client, uri) => client.UploadString(uri, RESPONSE_POST, jsonInput));
        }

        public static void PostAsync(string inputUri, string jsonInput)
        {
            CommunicationHelper(inputUri, (client, uri) => client.UploadStringAsync(uri, RESPONSE_POST, jsonInput));
        }

        public static void Delete(string inputUri)
        {
            CommunicationHelper(inputUri, (client, uri) => client.UploadString(uri, RESPONSE_DELETE, ""));
        }

        public static void DeleteAsync(string inputUri)
        {
            CommunicationHelper(inputUri, (client, uri) => client.UploadStringAsync(uri, RESPONSE_DELETE, ""));
        }
    }
} 