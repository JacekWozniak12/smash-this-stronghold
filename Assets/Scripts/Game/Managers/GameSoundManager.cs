using UnityEngine;
using SmashStronghold.Base.Managers;
using SmashStronghold.Base.Interfaces;
using System.Collections.Generic;
using SmashStronghold.Game.Entities;
using SmashStronghold.Base.Data;

namespace SmashStronghold.Game.Managers
{
    public class GameSoundManager : BaseManager<GameSoundManager>
    {
        [SerializeField]
        private List<AudioGroup> groups;
        private List<IAudioHandler> handlers = new List<IAudioHandler>();

        private void Start()
        {
            groups.ForEach(x => x.GenerateVariations());
            RefreshAudio();
        }

        [ContextMenu("Refresh Audio")]
        public void RefreshAudio()
        {
            groups.ForEach(x => x.GenerateVariations());
            handlers.ForEach(x => x.RefreshAudio());
        }

        public AudioClipData GetRandomAudioFromGroup(string groupName) =>
            groups.Find(x => x.GroupName == groupName).
            GetRandomAudio();

        public void Subscribe(IAudioHandler item) => 
            handlers.Add(item);

        public void UnSubscribe(IAudioHandler item) => 
            handlers.Remove(item);
    }
}