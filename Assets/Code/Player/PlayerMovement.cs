using UnityEngine;


namespace gig.fps
{
    public sealed class PlayerMovement :
        IPlayerMovement
    {
        private const string NAME_MOVE_SPEED_PARAMETR = "MoveForwardSpeed";
        private const string NAME_MOVE_STRAFE_PARAMETR = "MoveStrafeSpeed";
        private const float GRAVITY_MOD = -2.0f;

        private CharacterController _characterController;
        private Animator _playerAnimator;
        private PlayerMovementData _data;

        private Vector3 _verticalVelocity;
        private bool _isGrounded;

        public PlayerMovement(PlayerMovementData data, CharacterController characterController, Animator animator)
        {
            _characterController = characterController;
            _playerAnimator = animator;
            _data = data;
        }

        public void CheckGround()
        {
            _isGrounded = _characterController.isGrounded;
        }

        public void Gravity(float delta)
        {
            if (_isGrounded && _verticalVelocity.y < 0)
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
            if (_isGrounded)
            {
                _verticalVelocity.y = Mathf.Sqrt(_data.JumpForce * GRAVITY_MOD * _data.Gravity);
            }
        }

        public void Move(float delta, MovementState state)
        {
            var movement = _characterController.transform.right * state.XAxis +
                           _characterController.transform.forward * state.ZAxis;
            movement *= (state.IsRun ? _data.RunSpeed : _data.WalkSpeed) * delta;

            _playerAnimator.SetFloat(NAME_MOVE_SPEED_PARAMETR, state.ZAxis);
            _playerAnimator.SetFloat(NAME_MOVE_STRAFE_PARAMETR, state.XAxis);
            
            _characterController.Move(movement);
        }
    }
}