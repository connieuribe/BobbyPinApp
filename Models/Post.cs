using System;
using System.Collections.Generic;

namespace BobbyPinApp.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ConditionId { get; set; }
        public int? CatId { get; set; }

        public virtual Category Cat { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual LoginInfo User { get; set; }
    }
}
