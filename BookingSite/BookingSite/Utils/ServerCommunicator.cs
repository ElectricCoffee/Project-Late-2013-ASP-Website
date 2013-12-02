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
        private const string APPLICATION_JSON = "application/json";

        private static void GetHelper(string inputUri, Action<WebClient, Uri> clientfunction)
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = APPLICATION_JSON;
            var uri = new Uri(inputUri);
            clientfunction(client, uri);
        }

        public static string Get(string inputUri) 
        {
            string result = "";
            GetHelper(inputUri, (client, uri) => result = client.DownloadString(uri));
            return result;
        }

        public static void GetAsync(string inputUri, DownloadStringCompletedEventHandler downloadStringCompleted)
        {
            GetHelper(inputUri, (client, uri) => { 
                client.DownloadStringCompleted += downloadStringCompleted;
                client.DownloadStringAsync(uri);
            });
        }

        private static void PostHelper(string inputUri, Action<WebClient, Uri> clientfunction)
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = APPLICATION_JSON;
            var uri = new Uri(inputUri);
            clientfunction(client, uri);
        }

        public static void Post(string inputUri, string jsonInput)
        {
            PostHelper(inputUri, (client, uri) => client.UploadString(uri, "POST", jsonInput));
        }

        public static void PostAsync(string inputUri, string jsonInput)
        {
            PostHelper(inputUri, (client, uri) => client.UploadStringAsync(uri, "POST", jsonInput));
        }
    }
} 