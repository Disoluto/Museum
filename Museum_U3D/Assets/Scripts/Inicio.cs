using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        GameObject.FindWithTag("TextA").GetComponentInChildren<TextMeshProUGUI>().text = (A.InnerXml);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
