namespace WebApi.Models {
	using Entities;


	public class PostRequest {
		public int CategoryId { get; set; }

		public string Keyword { get; set; }
	}

	public class PostResponse {

		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; }

		public PostResponse(Post obj){
			Id = obj.Id;
			Title = obj.Title;
			Content = obj.Content;
			CreatedAt = obj.CreatedAt;

		}
	}
}
