using System;
using SmashStronghold.Base.Data;
using SmashStronghold.Base.Managers;
using UnityEngine;

namespace SmashStronghold.Game.Entities
{
    [Serializable]
    public class AudioGroup
    {
        [SerializeField]
        protected string groupName;

        [SerializeField]
        protected AudioData audio;

        [SerializeField]
        protected AudioData[] audioVariations;

        public string GroupName { get => groupName; protected set => groupName = value; }

        public AudioGroup(string name, AudioData audio, int amount)
        {
            groupName = name;

            
        }

        [ContextMenu("Generate Audio Variations")]
        public virtual void GenerateVariations()
        {
            
        }

        public virtual AudioData GetRandomAudio()
        {
            return audioVariations[UnityEngine.Random.Range(0, audioVariations.Length)];
        }

    }
}