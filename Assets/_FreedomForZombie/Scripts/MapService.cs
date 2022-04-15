using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapService {
    // Start is called before the first frame update
    private  static bool _mapIsActive = true;

    public static bool MapIsActive { get => _mapIsActive; set => _mapIsActive = value; }
}
