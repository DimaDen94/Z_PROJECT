using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Audio/New AudioList", order = 51)]
public class AudioSO : ScriptableObject
{
    [SerializeField] private List<AudioItem> _audioClips;
    public AudioClip GetAudioClipByType(SoundType type) {
        foreach (AudioItem audioItem in _audioClips)
            if (audioItem.SoundType == type)
                return audioItem.Clip;
        return null;
    }
}

