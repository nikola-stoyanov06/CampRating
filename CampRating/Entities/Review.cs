namespace CampRating.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; } 
        public string UserId { get; set; }
        public virtual CampingUser? User { get; set; }
        public int CampingPlaceId { get; set; }
        public virtual CampingPlace? CampingPlace { get; set; }
    }

}