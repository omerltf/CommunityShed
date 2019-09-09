using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShed.State
{
    public class Community
    {
        public int CommunityId { get; set; }
        public string CommunityName { get; set; }
        public int CreatorPersonId { get; set; }
        public bool IsOpen { get; set; }
    }
}