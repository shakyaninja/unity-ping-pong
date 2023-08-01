using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    [SerializeField]private Sound[] sounds;
    public static AudioManager Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        foreach(Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.loop = s.loop;
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string sound_name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == sound_name);
        if (s == null)
            return;
        s.audioSource.Play();
    }
}
