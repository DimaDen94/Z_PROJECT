using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Scenes _scene;

    public void OpenScene() {
        SceneManager.LoadScene(_scene.ToString());
    }
  
}
