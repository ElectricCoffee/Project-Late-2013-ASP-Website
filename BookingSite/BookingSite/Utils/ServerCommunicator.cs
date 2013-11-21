using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // add Put, Post, and Delete when needed
    }
} 