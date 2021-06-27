using System;


namespace gig.fps
{
    public interface IPlayerView
    {
        event Action<float> OnChangeHealth;
        void ChangeHealth(float hp);
    }
}