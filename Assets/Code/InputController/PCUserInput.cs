using System;
using UnityEngine;


namespace gig.fps
{
    public sealed class PCUserInput :
        IUserInput
    {
        public event Action<(float x, float z)> OnMoveAxisValueChanged = context => { };
        public event Action<(float x, float y)> OnMouseAxisValueChanged = context => { };
        public event Action<bool> OnRun = context => { };
        public event Action OnJump = () => { };
        public event Action OnFireAuto = () => { };
        public event Action OnFire = () => { };

        private PCInputData _data;

        public PCUserInput(PCInputData data)
        {
            _data = data;
        }

        public void GetInput()
        {
            OnMoveAxisValueChanged.Invoke((Input.GetAxis(_data.NameHorizontalAxis),
                Input.GetAxis(_data.NameVerticalAxis)));
            OnMouseAxisValueChanged.Invoke((Input.GetAxis(_data.NameMouseXAxis),
                Input.GetAxis(_data.NameMouseYAxis)));

            OnRun.Invoke(Input.GetKey(_data.KeyRun));

            if (Input.GetKeyDown(_data.KeyJump)) OnJump.Invoke();
            if (Input.GetKeyDown(_data.KeyFire)) OnFire.Invoke();
            if (Input.GetKey(_data.KeyFire)) OnFireAuto.Invoke();
        }
    }
}