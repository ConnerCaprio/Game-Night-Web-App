using GameNight.Entities;

namespace GameNight.DAOs
{
    public class GameEntityDao
    {
        private List<GameEntity> _gameEntities = new List<GameEntity>()
        {
            
            // Implementation to retrieve game entities from a database
            new GameEntity(){
                Id = "KingsCup",
                DateAdded = DateTime.UtcNow,
                Name = "Kings Cup",
                Rules = "Players take turns drawing cards and performing actions based on the card drawn. The game continues until all cards have been drawn.",
                PlayTimeMinutes = 45,
                MinPlayers = 3
            },
            new GameEntity(){
                Id = "CheersToTheGovernor",
                DateAdded = DateTime.UtcNow,
                Name = "Cheers to the Governor",
                Rules = "Players take turns saying incremental numbers or applied rules. Once 21 is reached a number is replaced with a new rule from the last player to speak",
                PlayTimeMinutes = 60,
                MinPlayers = 4,
                MaxPlayers = 6
            }

        };
        public async Task<List<GameEntity>> GetGameEntities()
        {
            return _gameEntities;
        }

        public async Task<GameEntity> GetGameEntityByName(string title)
        {
            return _gameEntities.FirstOrDefault(g => g.Id == title);
        }
    }
}
