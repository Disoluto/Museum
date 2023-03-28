using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inicio : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void Finvideo()
    {
        GameObject.FindWithTag("VideoPlayer").GetComponent<UnityEngine.Video.VideoPlayer>().enabled = false;
        GameObject.FindWithTag("Video").active = false;
        GameObject.FindWithTag("DatosPuntos").GetComponent<Canvas>().enabled = true;
        Time.timeScale = 1;
    }
}
