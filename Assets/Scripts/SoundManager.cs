using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip bgm1;
    public AudioClip bgm2;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }

        source = GetComponent<AudioSource>();
        PlayBGM(bgm1);
    }

    public void PlayOneShot(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    public void PlayBGM(AudioClip clip)
    {
        source.loop = true;
        source.clip = clip;
        source.Play();
    }
}
