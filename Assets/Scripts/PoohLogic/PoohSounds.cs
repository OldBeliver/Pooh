using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PoohSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] _idleSounds;
    [SerializeField] private AudioClip[] _hitSounds;
    [SerializeField] private AudioClip _theEndSound;
    [SerializeField] private float _timeBetweenSpeach;

    private AudioSource _playerAudio;
    private Coroutine _currentCoroutine;
    private bool _isCoroutineRun = false;

    private void Start()
    {
        _playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _currentCoroutine = StartCoroutine(IdleSpeach());
    }

    private IEnumerator IdleSpeach()
    {
        int clipIndex = GetRandomClipIndex(_idleSounds.Length);

        if (_isCoroutineRun == false)
        {
            _isCoroutineRun = true;

            PlaySound(_idleSounds[clipIndex]);

            yield return new WaitForSeconds(_timeBetweenSpeach);

            _isCoroutineRun = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int randomClipIndex = GetRandomClipIndex(_hitSounds.Length);

        TryToStopCoroutine(_currentCoroutine);

        PlaySound(_hitSounds[randomClipIndex]);
    }

    private int GetRandomClipIndex(int count)
    {
        return Random.Range(0, count);
    }

    private void TryToStopCoroutine(Coroutine currentCoroutine)
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
    }

    private void PlaySound(AudioClip clip)
    {
        _playerAudio.clip = clip;
        _playerAudio.Play();
    }
}
