using System;
namespace Colab.Models
{
    using System.Collections.Generic;

    public class Feed
    {
        private ICollection<Post> posts;

        public Feed()
        {
            this.posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return posts; }
            set { posts = value; }
        }
    }
}
