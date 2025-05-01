using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip explosionSound;
    
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
    
    // Optional helpers:
    public void PlayJumpSound() => PlaySound(jumpSound);
    public void PlayDeathSound() => PlaySound(deathSound);
    public void PlayExplosionSound() => PlaySound(explosionSound);
}
