using GameNight.Entities;
using System.Text.Json;

namespace GameNight.DAOs
{
    public class GamePieceDao
    {
        private readonly List<GamePieceEntity> _gamePieces;

        public GamePieceDao(IWebHostEnvironment env)
        {
            var filePath = Path.Combine(env.ContentRootPath, "Data", "gamePieces.json");
            var json = File.ReadAllText(filePath);
            _gamePieces = JsonSerializer.Deserialize<List<GamePieceEntity>>(json)
                            ?? new List<GamePieceEntity>();
        }
        public async Task<List<GamePieceEntity>> GetGamePieceEntities()
        {
            return _gamePieces;
        }

        public async Task<List<GamePieceEntity>> GetGamePiecesByGame(string game)
        {
            return _gamePieces
                .Where(g => g.GamesIncludedIn
                    .Any(name =>
                        name.Replace(" ", "").ToLowerInvariant() ==
                        game.Replace(" ", "").ToLowerInvariant()
                    ))
                .ToList();
        }
    }
}
