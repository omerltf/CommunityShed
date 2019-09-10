using CommunityShed.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        /// Gets the current user's active community.
        /// </summary>
        /// <returns>The active community.</returns>
        public static Community GetActiveCommunity()
        {
            Community community = null;
            object communityIdSessionValue = 
                HttpContext.Current.Session[ActiveCommunitySessionKey];

            if (communityIdSessionValue != null)
            {
                community = (Community)communityIdSessionValue;
            }

            return community;
        }

        /// <summary>
        /// Gets the current user's active community ID.
        /// </summary>
        /// <returns>The active community ID.</returns>
        public static int? GetActiveCommunityId()
        {
            Community commumity = GetActiveCommunity();

            return commumity != null ? commumity.CommunityId : (int?)null;
        }

        /// <summary>
        /// Sets the current user's active community.
        /// </summary>
        /// <param name="communityId">The community ID to make the current user's active community.</param>
        /// <param name="personId">The current person ID.</param>
        public static void SetActiveCommunity(int communityId, int personId)
        {
            DataTable communityDataTable = DatabaseHelper.Retrieve(@"
                    select c.CommunityId, c.CommunityName, c.CreatorPersonId, c.IsOpen
                    from Community c
                    join PersonCommunity pc on pc.CommunityId = c.CommunityId
                    where c.CommunityId = @CommunityId and pc.PersonId = @PersonId
                ",
                new SqlParameter("@CommunityId", communityId),
                new SqlParameter("@PersonId", personId));

            if (communityDataTable.Rows.Count == 0)
            {
                throw new ArgumentException("Unable to retrieve the provided person/community.");
            }

            DataRow dr = communityDataTable.Rows[0];

            Community community = new Community()
            {
                CommunityId = communityId,
                CommunityName = dr.Field<string>("CommunityName"),
                CreatorPersonId = dr.Field<int>("CreatorPersonId"),
                IsOpen = dr.Field<bool>("IsOpen")
            };

            HttpContext.Current.Session[ActiveCommunitySessionKey] = community;
        }
    }
}