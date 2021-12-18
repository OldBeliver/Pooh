using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClip;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = _audioClip[1];

        _audioSource.Play();
    }
}
