using GameNight.DTOs.Models;
using GameNight.Entities;

namespace GameNight.Helpers
{
    public class ResponseHelper
    {
        public static List<GameWithPieces> ConnectGameWithItsPieces(List<GameEntity> gameEntities, List<GamePieceEntity> gamePieces)
        {
            return gameEntities.Select(game => new GameWithPieces
            {
                Name = game.Name,
                Rules = game.Rules,
                DateAdded = game.DateAdded,
                MinPlayers = game.MinPlayers,
                MaxPlayers = game.MaxPlayers,
                PlayTimeMinutes = game.PlayTimeMinutes,
                Pieces = gamePieces
                    .Where(piece => piece.GamesIncludedIn.Contains(game.Name))
                    .GroupBy(piece => piece.Category)
                    .ToDictionary(
                        group => group.Key,
                        group => group.Select(piece => piece.value).ToList()
                    )
            }).ToList();
        }
    }
}
