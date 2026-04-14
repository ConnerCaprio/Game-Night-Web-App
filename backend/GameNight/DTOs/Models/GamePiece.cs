namespace GameNight.DTOs.Models
{
    public class GamePiece
    {
        public string[] GamesIncludedIn { get; set; } = Array.Empty<string>();
        public required string value { get; set; }
        public required string Category { get; set; }
    }
}
