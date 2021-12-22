namespace WebApi.Services {
  using Models;
  using Entities;

  public interface IPostService {
		PostResponse Filter(PostRequest model);
    IEnumerable<Post> GetAll();
    Post GetById(int id);
  }

	public class PostService : IPostService {
		public PostResponse Filter(PostRequest model) {
			throw new NotImplementedException();
		}

		public IEnumerable<Post> GetAll() {
			throw new NotImplementedException();
		}

		public Post GetById(int id) {
			throw new NotImplementedException();
		}
	}
}
