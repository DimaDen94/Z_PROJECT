using UnityEngine;

public class PauseDialog : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
