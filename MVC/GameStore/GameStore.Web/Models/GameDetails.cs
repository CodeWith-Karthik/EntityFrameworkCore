namespace GameStore.Web.Models
{
    public class GameDetails
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateOnly ReleasedYear { get; set; }

        public double Price { get; set; }
    }
}
