using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapPoint : MonoBehaviour
{
    [SerializeField] private int _pointNumber;
    [SerializeField] private TextMeshPro _pointNumberText;
    [SerializeField] private StarContainer _starsContainer;
    private void Start()
    {
        _pointNumberText.text = _pointNumber.ToString();
        
    }
    private void OnMouseUpAsButton()
    {
        SceneManager.LoadScene(Scenes.MainGameScene.ToString());

    }
}
