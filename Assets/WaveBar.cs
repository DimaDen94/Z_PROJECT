using UnityEngine;
using UnityEngine.UI;

public class WaveBar : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] Text _text;

    public void ChangeTimer(float total, float current)
    {
        _slider.maxValue = total;
        _slider.value = current;
    }
    public void ChangeWaveNumber(float total, float current)
    {
        _text.text = "Wave " + current + "/" + total;
    }
    public void WavePause(float current)
    {
        _text.text = "new wave after - " + current;
    }
    public void WaveComplated() {
        _text.text = "all waves complated";
    }
}
