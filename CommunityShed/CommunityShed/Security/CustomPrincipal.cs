using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CommunityShed.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity identity;
        private List<CommunityRole> communityRoles;

        public CustomPrincipal(CustomIdentity identity, DataTable currentUserInformation)
        {
            this.identity = identity;

            PersonName = currentUserInformation.Rows[0].Field<string>("Name");

            var communityRoles = new List<CommunityRole>();

            foreach (DataRow dr in currentUserInformation.Rows)
            {
                communityRoles.Add(new CommunityRole()
                {
                    CommunityId = dr.Field<int>("CommunityId"),
                    RoleName = dr.Field<string>("RoleName")
                });
            }

            this.communityRoles = communityRoles;
        }

        /// <summary>
        /// The current user's name.
        /// </summary>
        public string PersonName { get; set; }

        public IIdentity Identity
        {
            get
            {
                return identity;
            }
        }

        public CustomIdentity CustomIdentity
        {
            get
            {
                return identity;
            }
        }

        public bool IsInRole(string role)
        {
            throw new ApplicationException("Call the `IsInRole` method that accepts a community ID.");
        }

        /// <summary>
        /// Checks to see if the current user is assigned 
        /// to the provided role for the provided community.
        /// </summary>
        /// <param name="communityId">The community ID to check.</param>
        /// <param name="role">The role to check for.</param>
        /// <returns>A boolean indicating if the current user has the provided role for the provided community.</returns>
        public bool IsInRole(int communityId, string role)
        {
            return communityRoles
                .Exists(cr => cr.CommunityId == communityId && cr.RoleName == role);
        }
    }
}