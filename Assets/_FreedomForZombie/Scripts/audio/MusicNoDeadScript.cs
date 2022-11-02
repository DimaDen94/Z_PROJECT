using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNoDeadScript : MonoBehaviour
{
    // Start is called before the first frame update
    private static MusicNoDeadScript instance = null;
    public static MusicNoDeadScript Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
