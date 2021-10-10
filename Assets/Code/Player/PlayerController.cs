using UnityEngine;


namespace gig.fps
{
    public sealed class PlayerController :
        IController,
        ILogicUpdatable
    {
        private PlayerModel _model;
        private IPlayerView _view;
        private IPlayerMovement _movement;
        private IPlayerLook _look;

        public PlayerController(
            IPlayerView view,
            PlayerMovementData movementData,
            PlayerLookData lookData,
            InputController input
        )
        {
            _model = new PlayerModel();

            if (view is MonoBehaviour mono)
            {
                mono.TryGetComponent(out CharacterController controller);
                mono.TryGetComponent(out Animator animator);
                _movement = new PlayerMovement(movementData, controller, animator);

                var camera = Camera.allCameras[0].transform;
                _look = new PlayerLook(lookData, mono.transform, camera);
            }
            else throw new System.NullReferenceException("Can not get CharacterController from player view");

            view.OnChangeHealth += ChangeHealth;

            input.UserInput.OnMoveAxisValueChanged += MovementInput;
            input.UserInput.OnMouseAxisValueChanged += MouseInput;
            input.UserInput.OnJump += Jump;
            input.UserInput.OnRun += Run;
            input.UserInput.OnFire += Fire;
            input.UserInput.OnFireAuto += FireAuto;
        }


        private void ChangeHealth(float hp)
        {
        }

        private void MovementInput((float x, float z) axis)
        {
            _model.MovementState.XAxis = axis.x;
            _model.MovementState.ZAxis = axis.z;
        }

        private void MouseInput((float x, float y) axis)
        {
            _model.LookState.XAxis = axis.x;
            _model.LookState.YAxis = axis.y;
        }

        private void Jump() => _movement.Jump();
        private void Run(bool isRun) => _model.MovementState.IsRun = isRun;
        private void Fire() => Debug.Log("Fire");
        private void FireAuto() => Debug.Log("Fire auto");

        public void LogicUpdate(float delta)
        {
            _movement.Move(delta, _model.MovementState);
            _movement.Gravity(delta);
            _movement.CheckGround();
            _look.Look(_model.LookState, delta);
        }
    }
}