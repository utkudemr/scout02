using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Entity
{
    public class UserSocialAccounts
    {
        public string Id { get; set; }
        public DateTime? LastEditionTime { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string GoogleURL { get; set; }
        public string InstagramURL { get; set; }

        public UserContact UserContact { get; set; }
    }
}