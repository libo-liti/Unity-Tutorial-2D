using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        
        public AudioClip introBgmClip;
        public AudioClip bgmClip;
        
        public AudioClip jumpClip;
        public AudioClip colliderClip;

       public void SetBGMSound(string bgmName)
        {
            if (bgmName == "Intro")
                audioSource.clip = introBgmClip;
            else if (bgmName == "Play")
                audioSource.clip = bgmClip;
            
            audioSource.loop = true;
            audioSource.Play();
        }
        
        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip);
        }

        public void OnColliderSound()
        {
            audioSource.PlayOneShot(colliderClip);
        }
    }
}
