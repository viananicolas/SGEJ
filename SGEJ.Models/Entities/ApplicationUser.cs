using Microsoft.AspNetCore.Identity;

namespace SGEJ.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarURL { get; set; }
        public string DateRegistered { get; set; }
        public string Position { get; set; }
        public string NickName { get; set; }
    }
}
