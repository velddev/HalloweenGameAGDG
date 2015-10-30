using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public bool canPlayWalkSFX, canPlaySprintSFX;
    [SerializeField]
    private AudioClip[] SFX;
    public AudioClip test;

    public AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = test;
    }

    public void WalkingSFX(){  
        if (!audioSource.isPlaying)
        {
            audioSource.pitch = 0.8f;
            audioSource.clip = SFX[Random.Range(0, SFX.Length)];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    public void SprintingSFX(){
        if (!audioSource.isPlaying)
        {
            audioSource.pitch = 1.2f;
            audioSource.clip = SFX[Random.Range(0, SFX.Length)];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
