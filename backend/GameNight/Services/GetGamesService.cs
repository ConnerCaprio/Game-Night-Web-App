using GameNight.Controllers;
using GameNight.DAOs;
using GameNight.DTOs.Models;
using GameNight.DTOs.Responses;
using GameNight.Entities;
using GameNight.Helpers;


namespace GameNight.Services
{
    public class GetGamesService : IGetGamesService
    {
        private ILogger<GetGamesService> _logger;
        private GameEntityDao _gameEntityDao = new GameEntityDao();
        private GamePieceDao _gamePieceDao = new GamePieceDao();
        public GetGamesService(ILogger<GetGamesService> logger, GameEntityDao gameEntityDao, GamePieceDao gamePieceDao)
        {
            _logger = logger;
            _gameEntityDao = gameEntityDao;
            _gamePieceDao = gamePieceDao;
        }

        public async Task<GetGamesResponse> GetGamesAsync()
        {
            List<GameEntity> gameEntities = await _gameEntityDao.GetGameEntities();
            List<GamePieceEntity> gamePieces = await _gamePieceDao.GetGamePieceEntities();

            var response = new GetGamesResponse
            {
                GamesWithPieces = ResponseHelper.ConnectGameWithItsPieces(gameEntities, gamePieces)
            };

            return response;
        }

        public async Task<GameWithPieces?> GetGameByNameAsync(string gameName)
        {
            GameEntity gameEntity = await _gameEntityDao.GetGameEntityByName(gameName);
            List<GamePieceEntity> gamePieces = await _gamePieceDao.GetGamePiecesByGame(gameName);

            if (gameEntity == null)
                return null;

            var gamesWithPieces = ResponseHelper.ConnectGameWithItsPieces(new List<GameEntity> { gameEntity }, gamePieces);

            return gamesWithPieces.FirstOrDefault();
        }
    }
}
