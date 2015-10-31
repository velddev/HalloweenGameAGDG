using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    [SerializeField]
    private AudioClip[] SFX;
        [SerializeField]
    private AudioSource audioSource;

        float WaitTime;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        WaitTime -= Time.deltaTime;
    }

    public void WalkingSFX(){  
        if (WaitTime <= 0)
        {
            audioSource.pitch = 0.8f;
            audioSource.clip = SFX[Random.Range(0, SFX.Length)];
            audioSource.PlayOneShot(audioSource.clip);
            WaitTime = audioSource.clip.length;
        }
    }

    public void SprintingSFX(){
        if (WaitTime <= 0)
        {
            audioSource.pitch = 1.2f;
            audioSource.clip = SFX[Random.Range(0, SFX.Length)];
            audioSource.PlayOneShot(audioSource.clip);
            WaitTime = audioSource.clip.length;
        }
    }
}
