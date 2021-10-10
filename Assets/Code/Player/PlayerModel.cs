namespace gig.fps
{
    public sealed class PlayerModel
    {
        public MovementState MovementState { get; set; }
        public LookState LookState { get; set; }


        public PlayerModel()
        {
            MovementState = new MovementState();
            LookState = new LookState();
        }

    }
}