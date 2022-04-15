using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class UnitSoundManager : MonoBehaviour
{
    [SerializeField] AudioClip[] _atackSounds; 
    [SerializeField] AudioClip[] _takeDamageSounds; 
    [SerializeField] AudioClip[] _spawningSounds;
    [SerializeField] AudioClip[] _dyingSounds;
    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();

    }
    public void PlayAtackSound() {
        if (_atackSounds.Length != 0 && IsNeedToPlay(100)) {
            source.PlayOneShot(_atackSounds[Random.Range(0, _atackSounds.Length - 1)]);
        }
    }
    public void PlayTakeDamageSound()
    {
        if (_takeDamageSounds.Length != 0 && IsNeedToPlay(10))
        {
            source.PlayOneShot(_takeDamageSounds[Random.Range(0, _takeDamageSounds.Length - 1)]);
        }
    }
    public void PlaySpawningSound()
    {
        if (_spawningSounds.Length != 0 && IsNeedToPlay(50))
        {
            source.PlayOneShot(_spawningSounds[Random.Range(0, _spawningSounds.Length - 1)]);
        }
    }
    public void PlayDyingSound()
    {
        if (_dyingSounds.Length != 0 && IsNeedToPlay(50))
        {
            source.PlayOneShot(_dyingSounds[Random.Range(0, _dyingSounds.Length - 1)]);
        }
    }

    private bool IsNeedToPlay(int chance) {

        return chance >= Random.Range(0, 100);
    }
    
}
