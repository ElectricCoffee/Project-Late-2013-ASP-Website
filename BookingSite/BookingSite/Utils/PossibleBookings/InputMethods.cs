using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSite.Utils.PossibleBookings
{
    public class InputMethods
    {
        public static object Clear()
        {
            return null;
        }

        public static string Create(string start, string end, string subject)
        {
            var innerPair = new KeyValuePair<string, string>(start, end);

            var outerPair = new KeyValuePair<string, KeyValuePair<string, string>>(subject, innerPair);

            return outerPair.SerializeToJsonObject(); // {"Key": subject, "Value": {"Key": start, "Value": end}}
        }
    }
}