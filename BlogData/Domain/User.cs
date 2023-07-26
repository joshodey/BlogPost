using Microsoft.AspNetCore.Identity;

namespace BlogData.Domain
{
	public class User : IdentityUser
	{
        public string Firstname { get; set; }
		public string Lastname { get; set; }
    }
}
