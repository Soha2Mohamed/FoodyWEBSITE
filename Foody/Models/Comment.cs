namespace Foody.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public DateTime Created_at { get; set; }

        public Recipe Recipe { get; set; }
        public User User { get; set; }

        
    }
}
