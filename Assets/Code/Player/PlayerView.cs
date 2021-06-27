using System;
using UnityEngine;


namespace gig.fps
{
    public sealed class PlayerView :
        MonoBehaviour,
        IPlayerView
    {
        public event Action<float> OnChangeHealth = context => { };


        public void ChangeHealth(float hp)
        {
            OnChangeHealth.Invoke(hp);
        }
    }
}

