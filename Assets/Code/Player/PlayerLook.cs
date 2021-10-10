using UnityEngine;

namespace gig.fps
{
    public class PlayerLook :
        IPlayerLook
    {
        private PlayerLookData _data;
        private Transform _playerTransform;
        private Transform _cameraTransform;
        
        public PlayerLook(PlayerLookData data, Transform playerTransform, Transform cameraTransform)
        {
            _data = data;
            _playerTransform = playerTransform;
            _cameraTransform = cameraTransform;

            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Look(LookState state, float delta)
        {
            var x = state.XAxis * _data.MouseSence * delta;
            var y = state.YAxis * _data.MouseSence * delta;

            state.CameraRotation -= y;
            state.CameraRotation = Mathf.Clamp(state.CameraRotation, _data.MinCameraAngle, _data.MaxCameraAngle);
            
            _cameraTransform.localRotation = Quaternion.Euler(state.CameraRotation, 0f,0f);
            _playerTransform.Rotate(Vector3.up * x);
        }
    }
}