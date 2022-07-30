using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private AudioSource _BGM;
    private AudioSource _SFX;
    private Queue<Sound> _soundQueue = new Queue<Sound>();

    [SerializeField] private int _maximumSounds = 3;

    public List<Sound> sounds = new List<Sound>();
    public static Action OnGameOver;

    protected override void Awake()
    {
        base.Awake();

        var audioSources = GetComponents<AudioSource>();
        _BGM = audioSources?[0];
        _SFX = audioSources?[1];

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
        //_BGM.Play();
    }

    private void Update()
    {
        if(_SFX.isPlaying == false && _soundQueue.Count > 0)
        {
            GetSoundInfo(_soundQueue.Dequeue());
            _SFX.Play();
        }
    }

    public void Play(Settings.SoundType soundType)
    {
        var s = sounds.Where(x => x.soundType == soundType).FirstOrDefault();
        if (s != null && _soundQueue.Count < _maximumSounds) 
            _soundQueue.Enqueue(s);
    }

    public void Stop(Settings.SoundType soundType)
    {
        var s = sounds.Where(x => x.soundType == soundType).FirstOrDefault();
        if (s != null) s.source.Stop();
    }

    private void GameOver()
    {
        _BGM.Stop();
    }

    private void GetSoundInfo(Sound sound)
    {
        _SFX.clip = sound.clip;
        _SFX.volume = sound.volume;
        _SFX.pitch = sound.pitch;
        _SFX.loop = sound.loop;
    }
}
