using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public static SFXController Instance;
    public List<ClipNames> clips;
    AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
        Instance.audioSource = Instance.GetComponent<AudioSource>();
    }

    public static void Play(string clipName)
    {
        ClipNames clipToPlay;
        clipToPlay = Instance.clips.Find(clip => clip.name == clipName);
        if (clipToPlay != null)
        {
            Instance.audioSource.clip = clipToPlay.clip;
            Instance.audioSource.Play();
        }
    }
}

[System.Serializable]
public class ClipNames
{
    public string name;
    public AudioClip clip;
}