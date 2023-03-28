using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choque : MonoBehaviour
{
    string Etiqueta;
    void OnTriggerEnter(Collider other)

    {
        Etiqueta = other.gameObject.tag;
        if (Etiqueta.Equals("Mujer"))
        {
            Debug.Log("MUJER");
        }
        Debug.Log("choca: " + other.gameObject.tag);
        ////////other.GetComponent<Preguntas>().Setpreguntas(other.gameObject.tag);
        Debug.Log("choca: " + other.gameObject.tag);
        Destroy(other.gameObject);

  
    }

}
