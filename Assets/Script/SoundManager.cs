using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<Sound> sounds = new List<Sound>();

    public static Action OnGameOver;

    private void Awake()
    {
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
        Play(SoundType.BGMStart);
    }

    public void Play(SoundType soundType)
    {
        var s = sounds.Where(x => x.soundType == soundType).FirstOrDefault();
        if (s != null) s.source.Play();
    }

    public void Stop(SoundType soundType)
    {
        var s = sounds.Where(x => x.soundType == soundType).FirstOrDefault();
        if (s != null) s.source.Stop();
    }

    public void GameOver()
    {
        var s = sounds.Where(x => x.soundType == SoundType.BGMStart).FirstOrDefault();
        if (s != null) s.source.Stop();
    }
}

public enum SoundType
{
    EasterEgg = 0,
    Move = 1,
    Jump = 2,
    TreeCry = 3,
    TreeFall = 4,
    TreeSpirit = 5,
    HouseCrashed = 6,
    BGMStart = 7,
    BGMEnd = 8

}
