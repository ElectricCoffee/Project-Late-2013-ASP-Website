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

        private static void PostHelper(string jsonInput, string inputUri, Action<byte[], WebClient, Uri> clientfunction)
        {
            var client = new WebClient();
            var bytes = Encoding.UTF8.GetBytes(jsonInput);
            var uri = new Uri(inputUri);
            clientfunction(bytes, client, uri);
        }

        public static void Post(string inputUri, string jsonInput)
        {
            PostHelper(jsonInput, inputUri, (bytes, client, uri) => client.UploadData(uri, bytes));
        }

        public static void PostAsync(string inputUri, string jsonInput)
        {
            PostHelper(jsonInput, inputUri, (bytes, client, uri) => client.UploadDataAsync(uri, bytes));
        }
    }
} 