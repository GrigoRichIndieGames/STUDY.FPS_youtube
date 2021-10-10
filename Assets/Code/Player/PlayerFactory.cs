using TMPro;
using UnityEngine;

namespace gig.fps
{
    public sealed class PlayerFactory :
        IFactory<PlayerController>
    {
        private GameData _gameData;
        private InputController _inputController;

        public PlayerFactory(GameData data, InputController inputController)
        {
            _gameData = data;
            _inputController = inputController;
        }

        public PlayerController Create()
        {
            var startPosition = GameObject.FindGameObjectWithTag(_gameData.TagPlayerStartPosition).transform;
            var view = Object.Instantiate(_gameData.GetPrfPlayer, startPosition);
            var movementData = _gameData.GetDataPlayerMovement;
            var lookData = _gameData.GetDataPlayerLook;

            return new PlayerController(
                view,
                movementData,
                lookData,
                _inputController
                );
        }
    }
}

