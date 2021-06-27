using UnityEngine;


namespace gig.fps
{
    [CreateAssetMenu(fileName = "dataPCInput", menuName = "Data/Input/dataPCInput")]
    public sealed class PCInputData :
        ScriptableObject
    {
        public string NameHorizontalAxis;
        public string NameVerticalAxis;
        public string NameMouseXAxis;
        public string NameMouseYAxis;
        public KeyCode KeyRun;
        public KeyCode KeyJump;
        public KeyCode KeyFire;
    }
}