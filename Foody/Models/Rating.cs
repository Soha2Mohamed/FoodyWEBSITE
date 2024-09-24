namespace Foody.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Score { get; set; }

        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public DateTime Created_at { get; set; }

        public Recipe Recipe { get; set; }
        public User User { get; set; }

    }
}
