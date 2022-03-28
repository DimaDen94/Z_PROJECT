using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class RepeatButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ReloadScene);
    }
    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
