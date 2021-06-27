using UnityEngine;


namespace gig.fps
{
    public sealed class PlayerMovement :
        IPlayerMovement
    {
        private const float GRAVITY_MOD = -2.0f;

        private CharacterController _characterController;
        private PlayerMovementData _data;

        private Vector3 _verticalVelocity;

        public PlayerMovement(PlayerMovementData data, CharacterController characterController)
        {
            _characterController = characterController;
            _data = data;
        }

        public void Gravity(float delta)
        {
            if (_characterController.isGrounded && _verticalVelocity.y < 0)
            {
                _verticalVelocity.y = GRAVITY_MOD;
            }
            else
            {
                _verticalVelocity.y += _data.Gravity * delta;
            }

            _characterController.Move(_verticalVelocity * delta);
        }

        public void Jump()
        {
            if (_characterController.isGrounded)
            {
                _verticalVelocity.y = Mathf.Sqrt(_data.JumpForce * GRAVITY_MOD * _data.Gravity);
            }
        }

        public void Move(float delta, MovementState state)
        {
            var movement = _characterController.transform.right * state.XAxis +
                _characterController.transform.forward * state.ZAxis;
            movement *= (state.IsRun ? _data.RunSpeed : _data.WalkSpeed) * delta;

            _characterController.Move(movement);
        }
    }
}