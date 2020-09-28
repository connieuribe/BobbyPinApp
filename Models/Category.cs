using System;
using System.Collections.Generic;

namespace BobbyPinApp.Models
{
    public partial class Category
    {
        public Category()
        {
            Post = new HashSet<Post>();
        }

        public int CatId { get; set; }
        public string CatDescription { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
