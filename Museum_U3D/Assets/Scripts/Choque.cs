using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choque : MonoBehaviour
{
    ////Preguntas seleccion;
    ////public Preguntas preguntass;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("choca: " + other.gameObject.tag);
        other.GetComponent<Preguntas>().Setpreguntas(other.gameObject.tag);
        ////    other.GetComponent<Preguntas>().Setpreguntas(other.gameObject.tag);
        Debug.Log("choca: " + other.gameObject.tag);
        Destroy(other.gameObject);

  
    }

}
