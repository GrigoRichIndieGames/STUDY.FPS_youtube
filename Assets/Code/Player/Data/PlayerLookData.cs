using UnityEngine;


namespace gig.fps
{
    [CreateAssetMenu(fileName = "dataPlayerLook", menuName = "Data/Player/dataPlayerLook")]
    public sealed class PlayerLookData :
        ScriptableObject
    {
        public float MouseSence;
        public float MinCameraAngle;
        public float MaxCameraAngle;
    }
}