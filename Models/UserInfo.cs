using System;
using System.Collections.Generic;

namespace BobbyPinApp.Models
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string City { get; set; }
        public string UsaState { get; set; }
        public int? Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string DateJoin { get; set; }
        public int? RatingId { get; set; }
        public int? LoginId { get; set; }

        public virtual LoginInfo Login { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
