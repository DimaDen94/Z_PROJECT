using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnStart : MonoBehaviour
{
    [SerializeField] private UISoundManager _soundManager;
    [SerializeField] private SoundType _soundType;
    private void Start()
    {
        _soundManager.PlaySound(_soundType);
    }
}
