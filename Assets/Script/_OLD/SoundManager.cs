using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public List<Sound> sounds = new List<Sound>();

    public static Action OnGameOver;

    protected override void Awake()
    {
        base.Awake();

        OnGameOver += GameOver;

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
       // Play(Settings.SoundType.BGMStart);
    }

    public void Play(Settings.SoundType soundType)
    {
        var s = sounds.Where(x => x.soundType == soundType).FirstOrDefault();
        if (s != null) s.source.Play();
    }

    public void Stop(Settings.SoundType soundType)
    {
        var s = sounds.Where(x => x.soundType == soundType).FirstOrDefault();
        if (s != null) s.source.Stop();
    }

    public void GameOver()
    {
        var s = sounds.Where(x => x.soundType == Settings.SoundType.BGMStart).FirstOrDefault();
        if (s != null) s.source.Stop();
    }
}
