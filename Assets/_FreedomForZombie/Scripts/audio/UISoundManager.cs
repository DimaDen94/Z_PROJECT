using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioSO _audioSO;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(SoundType type) {
        _audioSource.clip = _audioSO.GetAudioClipByType(type);
        _audioSource.Play();
    }
}



