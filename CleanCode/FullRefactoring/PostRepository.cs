using System.Linq;

namespace CleanCode.FullRefactoring
{
    public class PostRepository
    {
        private readonly PostDbContext _dBContext;
        public PostRepository()
        {
            _dBContext = new PostDbContext();
        }
        public Post GetPost(int postId) => _dBContext.Posts.SingleOrDefault(p => p.Id == postId);
        public void SavePost(Post post)
        {
            _dBContext.Posts.Add(post);
            _dBContext.SaveChanges();
        }

    }
}
