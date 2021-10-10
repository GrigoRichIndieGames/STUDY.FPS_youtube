using UnityEngine;

namespace gig.fps
{
    [CreateAssetMenu(fileName = "dataGame", menuName = "Data/dataGame")]
    public sealed class GameData :
        ScriptableObject
    {
        [Header("came version")]
        public string CurrentGameVersion;
        [Header("root paths")]
        public string RootPrefabs;
        public string RootDatas;
        [Header("input controller")]
        public string RootInputController;
        public string DataPCUserInput;
        [Header("ui controller")]
        public string RootUIController;
        public string PrfMainCanvas;
        public string PrfGameVersion;
        [Header("player controller")]
        public string TagPlayerStartPosition;
        public string RootPlayerController;
        public string PrfPlayer;
        public string DataPlayerMovement;
        public string DataPlayerLook;


        #region InputController

        public PCInputData GetDataPCUserInput
        {
            get =>
                Load<PCInputData>($"{RootDatas}/{RootInputController}/{DataPCUserInput}");
        }

        #endregion

        #region UIController

        public Transform GetPrfMainCanvas { get => Load<Transform>($"{RootPrefabs}/{RootUIController}/{PrfMainCanvas}"); }
        public Transform GetPrfGameVersion { get => Load<Transform>($"{RootPrefabs}/{RootUIController}/{PrfGameVersion}"); }

        #endregion

        #region PlayerController

        public PlayerView GetPrfPlayer { get => Load<PlayerView>($"{RootPrefabs}/{RootPlayerController}/{PrfPlayer}"); }
        public PlayerMovementData GetDataPlayerMovement
        {
            get => Load<PlayerMovementData>($"{RootDatas}/{RootPlayerController}/{DataPlayerMovement}");
        }
        
        public PlayerLookData GetDataPlayerLook
        {
            get => Load<PlayerLookData>($"{RootDatas}/{RootPlayerController}/{DataPlayerLook}");
        }

        #endregion

        public T Load<T>(string path) where T : Object
        {
            var file = Resources.Load<T>(path);
            if (file == null) throw new System.NullReferenceException($"file not found in path: Resources/{path}");
            return file;
        }
    }
}
