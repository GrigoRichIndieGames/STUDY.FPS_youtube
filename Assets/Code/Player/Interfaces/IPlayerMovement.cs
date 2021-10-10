namespace gig.fps
{
    public interface IPlayerMovement
    {
        void CheckGround();
        void Move(float delta, MovementState state);
        void Gravity(float delta);
        void Jump();
    }
}

