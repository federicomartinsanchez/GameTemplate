using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : GenericSingleton<AudioManager>
{
    public Sound[] Sounds;

    public override void Awake()
    {
        base.Awake();
        foreach (Sound s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(Sounds, s => s.Name == name);

        if (sound == null)
        {
            Debug.LogWarning($"Sound {name} not found!");
            return;
        }

        sound.Source.Play();
    }
}
