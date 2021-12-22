﻿namespace WebApi.Entities {
	public class Post {
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
