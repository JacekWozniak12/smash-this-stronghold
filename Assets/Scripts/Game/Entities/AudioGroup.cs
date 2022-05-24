using System.Collections.Generic;
using SmashStronghold.Base.Data;
using SmashStronghold.Base.Managers;
using UnityEngine;

namespace SmashStronghold.Game.Entities
{
    [System.Serializable]
    public class AudioGroup
    {
        [SerializeField]
        protected string groupName;

        [SerializeField]
        protected AudioData audio;

        [SerializeField]
        protected float[] PitchVariations;

        [SerializeField]
        protected AudioClipData[] audioVariations;

        public string GroupName { get => groupName; protected set => groupName = value; }

        [ContextMenu("Generate Audio Variations")]
        public virtual void GenerateVariations()
        {
            List<AudioClipData> list = new List<AudioClipData>();
            foreach(float pitch in PitchVariations)
            {
                list.Add(new AudioClipData(
                    audio.clips[Random.Range(0, audio.clips.Length)], 
                    audio.volume.min, pitch)
                    );
            }
            audioVariations = list.ToArray();
        }

        public virtual AudioClipData GetRandomAudio()
        {
            return audioVariations[UnityEngine.Random.Range(0, audioVariations.Length)];
        }

    }
}