using GameNight.Entities;

namespace GameNight.DAOs
{
    public class GamePieceDao
    {
        private List<GamePieceEntity> _gamePieces = new List<GamePieceEntity>()
            {
                new GamePieceEntity
                {
                    Id = Guid.NewGuid(),
                    DateAdded = DateTime.UtcNow,
                    GamesIncludedIn = new[] { "Kings Cup" },
                    value = "Never have I ever used Gemini AI",
                    Category = "Jack"
                },
                new GamePieceEntity
                {
                    Id = Guid.NewGuid(),
                    DateAdded = DateTime.UtcNow,
                    GamesIncludedIn = new[] { "Kings Cup" },
                    value = "Never have I ever written a song more than 4 lines",
                    Category = "Jack"
                },
                new GamePieceEntity
                {
                    Id = Guid.NewGuid(),
                    DateAdded = DateTime.UtcNow,
                    GamesIncludedIn = new[] { "Kings Cup" },
                    value = "Mates are reversed",
                    Category = "King"
                },
                new GamePieceEntity
                {
                    Id = Guid.NewGuid(),
                    DateAdded = DateTime.UtcNow,
                    GamesIncludedIn = new[] { "Kings Cup" },
                    value = "Hockey Teams",
                    Category = "10"
                },
                new GamePieceEntity
                {
                    Id = Guid.NewGuid(),
                    DateAdded = DateTime.UtcNow,
                    GamesIncludedIn = new[] { "Cheers to the Governor" },
                    value = "Moo",
                    Category = "Rules"
                }

            };
        public async Task<List<GamePieceEntity>> GetGamePieceEntities()
        {
            return _gamePieces;
        }

        public async Task<List<GamePieceEntity>> GetGamePiecesByGame(string game)
        {
            return _gamePieces.Where(g => g.GamesIncludedIn.Contains(game)).ToList();
        }
    }
}
