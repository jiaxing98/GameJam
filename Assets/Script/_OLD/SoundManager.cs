using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private int _maximumSounds = 3;
    [SerializeField] private List<Sound> _bgmSounds = new List<Sound>();
    [SerializeField] private List<Sound> _treeSounds = new List<Sound>();
    [SerializeField] private List<Sound> _houseSounds = new List<Sound>();
    [SerializeField] private List<Sound> _tractorSounds = new List<Sound>();

    private AudioSource _BGM;
    private AudioSource _treeSfx;
    private AudioSource _houseSfx;
    private AudioSource _tractorSfx;
    private Queue<Sound> _treeSoundQueue = new Queue<Sound>();
    private Queue<Sound> _houseSoundQueue = new Queue<Sound>();
    private Queue<Sound> _tractorSoundQueue = new Queue<Sound>();

    public static Action OnGameOver;

    protected override void Awake()
    {
        base.Awake();

        _BGM = gameObject.AddComponent<AudioSource>();
        _treeSfx = gameObject.AddComponent<AudioSource>();
        _houseSfx = gameObject.AddComponent<AudioSource>();
        _tractorSfx = gameObject.AddComponent<AudioSource>();
        
        OnGameOver += GameOver;
    }

    private void Start()
    {
        PlayBGM(Settings.SoundType.BGMStart);
    }

    private void Update()
    {
        if(!_treeSfx.isPlaying && _treeSoundQueue.Count > 0)
        {
            AudioSourceMapping(_treeSfx, _treeSoundQueue.Dequeue());
            _treeSfx.Play();
        }

        if (!_houseSfx.isPlaying && _houseSoundQueue.Count > 0)
        {
            AudioSourceMapping(_houseSfx, _houseSoundQueue.Dequeue());
            _houseSfx.Play();
        }

        if (!_tractorSfx.isPlaying && _tractorSoundQueue.Count > 0)
        {
            AudioSourceMapping(_tractorSfx, _tractorSoundQueue.Dequeue());
            _tractorSfx.Play();
        }
    }

    private void AudioSourceMapping(AudioSource target, Sound sound)
    {
        target.clip = sound.clip;
        target.volume = sound.volume;
        target.pitch = sound.pitch;
        target.loop = sound.loop;
    }

    public void PlayBGM(Settings.SoundType soundType)
    {
        if (_BGM.isPlaying) _BGM.Stop();

        var s = _bgmSounds.Where(x => x.soundType == soundType).FirstOrDefault();
        if (s != null)
        {
            AudioSourceMapping(_BGM, s);
            _BGM.Play();
        }
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

    public void PlayTractorSfx(Settings.SoundType soundType)
    {
        var s = _tractorSounds.Where(x => x.soundType == soundType).FirstOrDefault();
        if (s != null && _tractorSoundQueue.Count < _maximumSounds)
            _tractorSoundQueue.Enqueue(s);
    }

    public void StopPlayingSfx(Settings.SfxType sfxType)
    {
        switch (sfxType)
        {
            case Settings.SfxType.Bgm:
                _BGM.Stop();
                break;
            case Settings.SfxType.Tree:
                _treeSfx.Stop();
                break;
            case Settings.SfxType.House:
                _houseSfx.Stop();
                break;
            case Settings.SfxType.Tractor:
                _tractorSfx.Stop();
                break;
        }
    }

    private void GameOver()
    {
        _BGM.Stop();
    }
}
