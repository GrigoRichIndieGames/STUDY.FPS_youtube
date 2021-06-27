namespace gig.fps
{
    public sealed class PlayerModel
    {
        public MovementState MovementState { get; set; }


        public PlayerModel()
        {
            MovementState = new MovementState();
        }

    }
}