using System;
using System.Collections.Generic;

namespace BobbyPinApp.Models
{
    public partial class Rating
    {
        public Rating()
        {
            UserInfo = new HashSet<UserInfo>();
        }

        public int RatingId { get; set; }
        public int? Rating1 { get; set; }

        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
