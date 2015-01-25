using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioObject:MonoBehaviour
{
    /*private Dictionary<string, AudioSource> m_dicAudioSources = new Dictionary<string, AudioSource>();

    public AudioObject(string[] names, AudioClip[] clips)
    {
        for (int i = 0; i < clips.Length; i++)
        {
            AudioSource newSource = new AudioSource();
            newSource.clip = clips[i];
            m_dicAudioSources.Add(names[i], newSource);
        }
    }

    public void play(string name)
    {
        AudioSource currentSource = m_dicAudioSources[name];
        currentSource.Play();
    }

    public void stop(string name)
    {
        AudioSource currentSource = m_dicAudioSources[name];
        currentSource.Stop();
    }*/

    public string[] names;
    public AudioClip[] clips;

    private Dictionary<string, AudioClip> m_dicAudioClips = new Dictionary<string, AudioClip>();
    //private AudioSource m_audioSource;

    void Start()
    {
       // m_audioSource = gameObject.GetComponent<AudioSource>();

        for (int i = 0; i < clips.Length; i++)
        {
            m_dicAudioClips.Add(names[i], clips[i]);
        }
    }


    public void playOnly(string clipName)
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }

        audio.clip = m_dicAudioClips[clipName];
        audio.Play();

        Debug.Log("end of playOnly()");
    }

    public void playOneShot(string clipName)
    {
        audio.PlayOneShot(m_dicAudioClips[clipName]);
    }

    public void stop()
    {
        audio.Stop();
    }
}
