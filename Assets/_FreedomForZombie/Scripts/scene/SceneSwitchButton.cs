using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class SceneSwitchButton : MonoBehaviour
{
    [SerializeField] private SceneEnum _sceneType;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ReloadScene);
    }
    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_sceneType.ToString());
    }
    enum SceneEnum {
        MainGameScene,
        MapScene,
        ShopScene,
        UpgradeScene
    }
}
