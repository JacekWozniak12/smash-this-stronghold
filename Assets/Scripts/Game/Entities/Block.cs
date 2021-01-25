using SmashStronghold.Base.Data;
using SmashStronghold.Game.Behaviours;
using UnityEngine;

namespace SmashStronghold.Game.Entities
{
    [RequireComponent(typeof(Rigidbody))]
    public class Block : MonoBehaviour
    {
        [SerializeField]
        MusicalAudioData hitData;
        AudioSource audioSource;


        private void Awake()
        {
            gameObject.AddComponent<ColorRandomizer>();
            gameObject.AddComponent<AudioSource>();
            audioSource = GetComponent<AudioSource>();
        }

        private bool CanPlaySound() => delayBeforeNext <= 0;


        private float time = 0.5f;
        private float delayBeforeNext;

        private void Update()
        {
            if(delayBeforeNext > 0) delayBeforeNext -= Time.deltaTime;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (CanPlaySound() && (other.relativeVelocity.magnitude > 20 || (other.gameObject.tag == "ground" && other.relativeVelocity.magnitude > 2)))
            {
                hitData.GetSound(out AudioClip clip, out float volume, out float pitch);
                audioSource.volume = volume;
                audioSource.pitch = pitch;
                audioSource.PlayOneShot(clip);
                delayBeforeNext = time;
            }
        }
    }
}
