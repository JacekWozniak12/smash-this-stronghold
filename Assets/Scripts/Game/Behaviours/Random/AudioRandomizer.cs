using UnityEngine;
using SmashStronghold.Library;
using SmashStronghold.Game.Managers;
using SmashStronghold.Base.Interfaces;
using SmashStronghold.Base.Data;

namespace SmashStronghold.Game.Behaviours
{
    public class AudioRandomizer : MonoBehaviour, IAudioHandler
    {
        public string AudioGroup;
        private GameSoundManager manager;

        private void Awake()
        {
            manager = GameSoundManager.Instance;
            AddToManager();
        }

        private void AddToManager() => manager.Subscribe(this);

        public AudioClipData GetAudio()
        {
            return manager.GetRandomAudioFromGroup(AudioGroup);
        }

        public void RefreshAudio()
        {
            manager.RefreshAudio();
        }
    }
}
