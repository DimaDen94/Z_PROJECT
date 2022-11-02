using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSoundPlayer : MonoBehaviour
{
    [SerializeField] private UISoundManager _soundManager;
    [SerializeField] private SoundType _soundType;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }
    private void PlaySound() {
        _soundManager.PlaySound(_soundType);
    }
}
