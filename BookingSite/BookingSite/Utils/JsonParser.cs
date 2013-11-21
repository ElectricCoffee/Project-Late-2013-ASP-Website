using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace BookingSite.Utils
{
    public static class JsonParser
    {
        public static T DeserializeJson<T>(this string input)
        {
            return new JavaScriptSerializer().Deserialize<T>(input);
        }
    }
}