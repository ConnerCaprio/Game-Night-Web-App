using GameNight.Entities;
using System.Text.Json;

namespace GameNight.DAOs
{
    public class GameEntityDao
    {
        private readonly List<GameEntity> _gameEntities;

        public GameEntityDao(IWebHostEnvironment env)
        {
            var filePath = Path.Combine(env.ContentRootPath, "Data", "games.json");

            var json = File.ReadAllText(filePath);

            _gameEntities = JsonSerializer.Deserialize<List<GameEntity>>(json)
                            ?? new List<GameEntity>();
        }

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
