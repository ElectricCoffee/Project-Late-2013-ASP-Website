﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace BookingSite.Utils
{
    /// <summary>
    /// Serves to remove boilerplate code, by simply letting the user call a method directly on the object you're using
    /// </summary>
    public static class JsonConverter
    {
        /// <summary>
        /// Takes any JSON Object in string form, and deserializes it to the specified class
        /// </summary>
        /// <typeparam name="T">Any Class with fields that match the JSON object</typeparam>
        /// <param name="input">Any JSON Object string</param>
        /// <returns>An Object that contains the data</returns>
        public static T DeserializeJson<T>(this string input)
        {
            Debug.WriteLine(input);

            if (input.Equals("{}"))
            {
                if (typeof(T) == typeof(IEnumerable<>).MakeGenericType(typeof(T).GetGenericArguments()[0]))
                    return (T) Activator.CreateInstance(typeof(List<>).MakeGenericType(typeof(T).GetGenericArguments()[0]));
                else
                    return Activator.CreateInstance<T>();
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(input);
            //return new JavaScriptSerializer().Deserialize<T>(input);
        }

        /// <summary>
        /// Takes any object and turns it into a string containing a JSON Object
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="input">Any Object</param>
        /// <returns>String containing a JSON Object</returns>
        public static string SerializeToJsonObject<T>(this T input)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(input);
            //return new JavaScriptSerializer().Serialize(input);
        }
    }
}