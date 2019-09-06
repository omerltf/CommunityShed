using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShed.Security
{
    public class CommunityRole
    {
        public int CommunityId { get; set; }
        public string RoleName { get; set; }

        /// <summary>
        /// Overriding this method to assist with debugging.
        /// </summary>
        /// <returns>A string containing the property values.</returns>
        public override string ToString()
        {
            return $"CommunityId: {CommunityId}, RoleName: {RoleName}";
        }
    }
}