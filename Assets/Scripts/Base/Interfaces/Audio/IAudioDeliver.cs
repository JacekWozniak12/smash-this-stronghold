using UnityEngine;

namespace SmashStronghold.Base.Interfaces
{
    public interface IAudioDeliver
    {
         void GetSound(out AudioClip clip, out float volume, out float pitch);
    }
}