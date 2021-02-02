using UnityEngine;

namespace SmashStronghold.Base.Data
{
    [CreateAssetMenu(fileName = "MusicalAudioData", menuName = "smash-this-stronghold/MusicalScale", order = 0)]
    public class MusicalScale : ScriptableObject
    {
        MusicalAudioData[] sounds;
        
    }
}