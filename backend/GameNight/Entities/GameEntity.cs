namespace GameNight.Entities
{
    public class GameEntity
    {
        public Guid Guid { get; set; }
        public required string Name { get; set; }
        public string? Rules { get; set; }
        public DateTime DateAdded { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int PlayTimeMinutes { get; set; }

    }
}
