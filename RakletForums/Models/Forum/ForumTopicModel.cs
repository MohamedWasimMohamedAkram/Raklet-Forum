using RakletForums.Models.Post;
using System.Collections.Generic;

namespace RakletForums.Models.Forum
{
    public class ForumTopicModel
    {
        public  ForumListingModel Forum { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}
