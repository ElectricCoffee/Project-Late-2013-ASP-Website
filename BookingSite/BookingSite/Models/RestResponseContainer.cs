using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSite.Models
{
    public class RestResponseContainer
    {
        /// <summary>
        /// Contains the text of the response, which are statuses.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Contains another Key-Value pair 
        /// which are the access level and the GUID of the person logged in.
        /// </summary>
        public InnerValue Value { get; set; }

        public class InnerValue
        {
            /// <summary>
            /// Stores the Access level of the person who logged in, 1 for students, 2 for teachers, and 3 for admins
            /// </summary>
            public string Key { get; set; }
            /// <summary>
            /// Stores the GUID of the person who logged in.
            /// </summary>
            public string Value { get; set; }
        }
    }
} 