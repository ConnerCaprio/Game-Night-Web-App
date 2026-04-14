namespace GameNight.DTOs.Models
{
    public class Game
    {
        public required string Name { get; set; }
        public string? Rules { get; set; }
        public DateTime DateAdded { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int PlayTimeMinutes { get; set; }

    }
    public class GameWithPieces : Game
    {
        public required Dictionary<string, List<string>> Pieces { get; set; }
    }
}
