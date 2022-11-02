using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
[RequireComponent(typeof(Image), typeof(Button))]
public class AudioButton : MonoBehaviour
{
    [SerializeField] private Sprite _acticeState;
    [SerializeField] private Sprite _inacticeState;
    [SerializeField] private AudioEnum _audioType;
    [SerializeField] private AudioMixer _audioMixer;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(ChangeStatus);
        UpdateSprite();
        bool music = PlayerPrefs.GetString(_audioType.ToString(), true.ToString()).Equals("True");
        UpdateVolume(music);
    }

    public void ChangeStatus() {

        bool music = !PlayerPrefs.GetString(_audioType.ToString(), true.ToString()).Equals("True");
        Debug.Log(music.ToString());
        PlayerPrefs.SetString(_audioType.ToString(), music.ToString());
        PlayerPrefs.Save();
        UpdateSprite();
        UpdateVolume(music);
    }
    private void UpdateSprite()
    {

        bool music = PlayerPrefs.GetString(_audioType.ToString(), true.ToString()).Equals("True");
        if (music)
            _image.sprite = _acticeState;
        else
            _image.sprite = _inacticeState;
    }
    private void UpdateVolume(bool music)
    {
        Debug.Log(_audioType.ToString());
        if (music)
            _audioMixer.SetFloat(_audioType.ToString(), 1f);
        else
            _audioMixer.SetFloat(_audioType.ToString(), -80f);
    }
    public enum AudioEnum{
        Sound,
        Music
    }
}
