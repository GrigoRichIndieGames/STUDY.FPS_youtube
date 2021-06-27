namespace gig.fps
{
    public sealed class Initializator
    {
        public Initializator(GameData _data, ControllersRepository _repository)
        {
            var uiController = new UIControllerFactory(_data).Create();
            var inputController = new InputControllerFactory(_data).Create();
            var playerController = new PlayerFactory(_data, inputController).Create();

            _repository.Add(uiController);
            _repository.Add(inputController);
            _repository.Add(playerController);
        }
    }
}

