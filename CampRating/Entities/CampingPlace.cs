using System.ComponentModel.DataAnnotations;

namespace CampRating.Entities
{
    public class CampingPlace
    {
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PhotoUrl { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; } // All reviews for CampingPlace
    }
}