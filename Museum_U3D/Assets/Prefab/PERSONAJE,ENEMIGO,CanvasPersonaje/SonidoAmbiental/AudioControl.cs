using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayMusic();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StopMusic();
        }
        
    }

    public void PlayMusic()
    {
        audiosource.Play();

    }

    public void StopMusic()
    {
        audiosource.Stop();
    }
}
