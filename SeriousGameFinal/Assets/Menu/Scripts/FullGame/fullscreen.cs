using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullscreen : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }
    public void Fullscreen()
    {
        // Toggle fullscreen
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void Windowed()
    {
        // Toggle fullscreen
        Screen.fullScreen = Screen.fullScreen;
    }
}

