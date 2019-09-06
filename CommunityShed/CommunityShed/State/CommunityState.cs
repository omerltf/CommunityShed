using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShed.State
{
    /// <summary>
    /// Persists the current user's selected community across requests.
    /// </summary>
    public static class CommunityState
    {
        private const string ActiveCommunitySessionKey = "ActiveCommunity";

        /// <summary>
        /// Gets the current user's active community ID.
        /// </summary>
        /// <returns>The ID for the active community.</returns>
        public static int? GetActiveCommunity()
        {
            int? communityId = null;
            object communityIdSessionValue = 
                HttpContext.Current.Session[ActiveCommunitySessionKey];

            if (communityIdSessionValue != null)
            {
                communityId = (int)communityIdSessionValue;
            }

            return communityId;
        }

        /// <summary>
        /// Sets the current user's active community.
        /// </summary>
        /// <param name="communityId">The community ID to make the current user's active community.</param>
        public static void SetActiveCommunity(int communityId)
        {
            HttpContext.Current.Session[ActiveCommunitySessionKey] = communityId;
        }
    }
}