namespace Foody.Models
{
    public class FeaturedMeal
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int Rating { get; set; }
        public DateTime Week_of {  get; set; }

        public Recipe Recipe { get; set; }
    }
}
