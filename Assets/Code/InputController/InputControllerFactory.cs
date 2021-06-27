using TMPro;
using UnityEngine;

namespace gig.fps
{
    public sealed class InputControllerFactory :
        IFactory<InputController>
    {
        private GameData _gameData;
        private IUserInput _userInput;

        public InputControllerFactory(GameData data)
        {
            _gameData = data;

            switch (Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WebGLPlayer:
                case RuntimePlatform.WindowsEditor:
                    _userInput = GetPCUserInput(_gameData.GetDataPCUserInput);
                    break;
                case RuntimePlatform.IPhonePlayer:
                case RuntimePlatform.Android:
                    GetMobileUserInput();
                    break;
                default:
                    throw new System.NullReferenceException("Can not load user input");
            }
        }

        public InputController Create()
        {
            return new InputController(_userInput);
        }


        private PCUserInput GetPCUserInput(PCInputData data)
        {
            var userInput = new PCUserInput(data);
            return userInput;
        }
        private void GetMobileUserInput()
        {
            throw new System.NullReferenceException("Can not load mobile input");
        }
    }
}

