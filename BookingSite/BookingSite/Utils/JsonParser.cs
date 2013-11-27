﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace BookingSite.Utils
{
    public static class JsonParser
    {
        /// <summary>
        /// Takes any JSON Object in string form, and deserializes it to the specified class
        /// </summary>
        /// <typeparam name="T">Any Class with fields that match the JSON object</typeparam>
        /// <param name="input">Any JSON Object string</param>
        /// <returns>An Object that contains the data</returns>
        public static T DeserializeJson<T>(this string input)
        {
            return new JavaScriptSerializer().Deserialize<T>(input);
        }

        /// <summary>
        /// Takes any object and turns it into a string containing a JSON Object
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="input">Any Object</param>
        /// <returns>String containing a JSON Object</returns>
        public static string SerializeToJsonObject<T>(this T input)
        {
            return new JavaScriptSerializer().Serialize(input);
        }
    }
}