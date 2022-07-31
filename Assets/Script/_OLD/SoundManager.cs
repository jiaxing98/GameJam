using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private AudioSource _BGM;
    private AudioSource _treeSfx;
    private AudioSource _houseSfx;
    private Queue<Sound> _treeSoundQueue = new Queue<Sound>();
    private Queue<Sound> _houseSoundQueue = new Queue<Sound>();

    [SerializeField] private int _maximumSounds = 3;
    [SerializeField] private List<Sound> _bgmSounds = new List<Sound>();
    [SerializeField] private List<Sound> _treeSounds = new List<Sound>();
    [SerializeField] private List<Sound> _houseSounds = new List<Sound>();

    public static Action OnGameOver;

    protected override void Awake()
    {
        base.Awake();

        _BGM = gameObject.AddComponent<AudioSource>();
        _treeSfx = gameObject.AddComponent<AudioSource>();
        _houseSfx = gameObject.AddComponent<AudioSource>();
        
        OnGameOver += GameOver;
    }

    private void Start()
    {
        //PlayBGM(_bgmSounds[0]);
    }

    private void Update()
    {
        if(!_treeSfx.isPlaying&& _treeSoundQueue.Count > 0)
        {
            GetSoundInfo(_treeSoundQueue.Dequeue());
            _treeSfx.Play();
        }

        if (!_houseSfx.isPlaying && _houseSoundQueue.Count > 0)
        {
            GetSoundInfo(_houseSoundQueue.Dequeue());
            _houseSfx.Play();
        }
    }

    public void PlayBGM(Settings.SoundType soundType)
    {
        if (_BGM.isPlaying) _BGM.Stop();

        var s = _bgmSounds.Where(x => x.soundType == soundType).FirstOrDefault();
        if (s != null) _BGM.Play();
    }

    public void PlayTreeSfx(Settings.SoundType soundType)
    {
        var s = _treeSounds.Where(x => x.soundType == soundType).FirstOrDefault();
        if (s != null && _treeSoundQueue.Count < _maximumSounds) 
            _treeSoundQueue.Enqueue(s);
    }

    public void PlayHouseSfx(Settings.SoundType soundType)
    {
        var s = _houseSounds.Where(x => x.soundType == soundType).FirstOrDefault();
        if (s != null && _houseSoundQueue.Count < _maximumSounds)
            _houseSoundQueue.Enqueue(s);
    }

    private void GameOver()
    {
        _BGM.Stop();
    }

    private void GetSoundInfo(Sound sound)
    {
        _treeSfx.clip = sound.clip;
        _treeSfx.volume = sound.volume;
        _treeSfx.pitch = sound.pitch;
        _treeSfx.loop = sound.loop;
    }
}
