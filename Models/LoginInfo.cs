using System;
using System.Collections.Generic;

namespace BobbyPinApp.Models
{
    public partial class LoginInfo
    {
        public LoginInfo()
        {
            Post = new HashSet<Post>();
            UserInfo = new HashSet<UserInfo>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
