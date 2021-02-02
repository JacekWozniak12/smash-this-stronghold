using UnityEngine;
using SmashStronghold.Library;
using SmashStronghold.Game.Managers;
using SmashStronghold.Base.Interfaces;

namespace SmashStronghold.Game.Behaviours
{
    public class AudioRandomizer : MonoBehaviour, IAudioHandler
    {
        public string audioGroup;

        private void Awake()
        {
            AddToManager();
        }

        private void AddToManager()
        {
            GameSoundManager.Instance.Subscribe(this);
        }

        public void RefreshAudio()
        {
            throw new System.NotImplementedException();
        }
    }
}
