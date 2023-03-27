using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.FindWithTag("VideoPlayer").GetComponent<UnityEngine.Video.VideoPlayer>().enabled = true;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void Finvideo()
    {
        GameObject.FindWithTag("Video").GetComponent<Canvas>().enabled = false;

        Time.timeScale = 1;
       GameObject.FindWithTag("VideoPlayer").GetComponent<UnityEngine.Video.VideoPlayer>().enabled = false;
       GameObject.FindWithTag("Juego").GetComponent<Camera>().enabled = true;
    }
}
