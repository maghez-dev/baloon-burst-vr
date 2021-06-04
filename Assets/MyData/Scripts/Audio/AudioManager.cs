using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource _environmentSource;
    [SerializeField] private AudioSource _balloonSource;
    [SerializeField] private AudioSource _playerSource;

    [SerializeField] private AudioClip _envClip;
    [SerializeField] private AudioClip _popClip;
    [SerializeField] private AudioClip _shootClip;

    public AudioMixer audioMixer;

    public enum SoundLayers
    {
        Environment,
        Sfx,
    }

    public void PlayShoot()
    {
        _playerSource.clip = _shootClip;
        _playerSource.pitch = Random.Range(0.6f, 1.4f);
        _playerSource.loop = false;
        _playerSource.Play();
    }

    public void PlayEnvironment()
    {
        _environmentSource.clip = _envClip;
        _environmentSource.loop = true;
        _environmentSource.Play();
    }

    public void PlayPop()
    {
        _balloonSource.clip = _popClip;
        _balloonSource.pitch = Random.Range(0.6f, 1.4f);
        _balloonSource.loop = false;
        _balloonSource.Play();
    }

    public void StopAudio()
    {
        _environmentSource.Stop();
    }
}
