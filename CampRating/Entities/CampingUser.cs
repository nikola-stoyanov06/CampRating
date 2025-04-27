using Microsoft.AspNetCore.Identity;

namespace CampRating.Entities
{
    public class CampingUser : IdentityUser //Inherits IdentityUser, while adapting to the App's requirements
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; } // All reviews by said user
    }
}
