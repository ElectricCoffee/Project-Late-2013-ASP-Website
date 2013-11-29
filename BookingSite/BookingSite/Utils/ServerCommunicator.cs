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
        public static string Get(string inputUri) 
        {
            var uri = new Uri(inputUri);
            return new WebClient().DownloadString(uri);
        }

        private static void PostHelper(string inputUri, Action<WebClient, Uri> clientfunction)
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var uri = new Uri(inputUri);
            clientfunction(client, uri);
        }

        public static void Post(string inputUri, string jsonInput)
        {
            PostHelper(inputUri, (client, uri) => {
                client.UploadString(uri, "POST", jsonInput);
            });
        }

        public static void PostAsync(string inputUri, string jsonInput)
        {
            PostHelper(inputUri, (client, uri) => client.UploadStringAsync(uri, "POST", jsonInput));
        }
    }
} 