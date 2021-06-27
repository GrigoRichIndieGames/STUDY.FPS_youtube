using UnityEngine;


namespace gig.fps
{
    [CreateAssetMenu(fileName = "dataPlayerMovement", menuName = "Data/Player/dataPlayerMovement")]
    public sealed class PlayerMovementData :
        ScriptableObject
    {
        public float Gravity;
        public float JumpForce;
        public float RunSpeed;
        public float WalkSpeed;
    }
}