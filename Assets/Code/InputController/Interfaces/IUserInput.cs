using System;


namespace gig.fps
{
    public interface IUserInput
    {
        event Action<(float x, float z)> OnMoveAxisValueChanged;
        event Action<(float x, float y)> OnMouseAxisValueChanged;
        event Action<bool> OnRun;
        event Action OnJump;
        event Action OnFireAuto;
        event Action OnFire;

        void GetInput();
    }
}

