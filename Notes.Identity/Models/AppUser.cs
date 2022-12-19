using Microsoft.AspNetCore.Identity;

namespace Notes.Identity.Models
{
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets User's First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets User's Last Name.
        /// </summary>
        public string LastName { get; set; }
    }
}
