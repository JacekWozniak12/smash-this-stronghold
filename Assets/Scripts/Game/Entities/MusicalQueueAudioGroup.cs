using System;
using SmashStronghold.Base.Data;
using SmashStronghold.Base.Managers;
using UnityEngine;

namespace SmashStronghold.Game.Entities
{
    [Serializable]
    public class MusicalQueueAudioGroup : AudioGroup
    {

        
        public MusicalQueueAudioGroup(string name, AudioData audio, int amount) : base(name, audio, amount)
        {
            

        }

        [ContextMenu("Generate Audio Variations")]
        public override void GenerateVariations()
        {
            
        }

        int index = 0;

        public override AudioData GetRandomAudio()
        {
            index = Mathf.Clamp(++index, 0, audioVariations.Length);
            return audioVariations[index];
        }

    }
}