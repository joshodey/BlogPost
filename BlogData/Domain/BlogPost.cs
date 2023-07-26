using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace BlogData.Domain
{
	public class BlogPost
	{
		[Key]
        public string BlogId { get; set; }
		public string Title { get; set;}
		public string Description { get; set;}
		public string CreatedAt { get; set;}
        public string UserId { get; set; }

    }

	
}
