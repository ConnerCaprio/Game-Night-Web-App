using GameNight.DTOs.Models;
using GameNight.Entities;

namespace GameNight.DTOs.Requests
{
    public class AddGameRequest
    {
        public required string Name { get; set; }
        public string? Rules { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int PlayTimeMinutes { get; set; }
        public List<GamePieceEntity>? GamePieces { get; set; }
    }
}
