using GameNight.DTOs.Models;
using GameNight.DTOs.Responses;

namespace GameNight.Services
{
    public interface IGetGamesService
    {
        Task<GetGamesResponse> GetGamesAsync();
        Task<GameWithPieces?> GetGameByNameAsync(string gameName);
    }
}