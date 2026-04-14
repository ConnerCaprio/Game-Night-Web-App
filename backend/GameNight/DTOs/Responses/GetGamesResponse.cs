using GameNight.DTOs.Models;

namespace GameNight.DTOs.Responses
{
    public class GetGamesResponse
    {
        public required List<GameWithPieces> GamesWithPieces { get; set; }
    }
}
