using System;
using System.Collections.Generic;

namespace BobbyPinApp.Models
{
    public partial class Condition
    {
        public Condition()
        {
            Post = new HashSet<Post>();
        }

        public int ConditionId { get; set; }
        public string Cond { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
