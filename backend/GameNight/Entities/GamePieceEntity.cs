namespace GameNight.Entities
{
    public class GamePieceEntity
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string[] GamesIncludedIn { get; set; } = Array.Empty<string>();
        public required string value { get; set; }
        public required string Category { get; set; }
    }
}
