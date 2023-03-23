using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choque : MonoBehaviour
{
   //// [SerializeField] Preguntas preguntas;
    void OnTriggerEnter(Collider other)
    {
       //// preguntas.Cuadro = other.gameObject.tag;
        Debug.Log("choca: " + other.gameObject.tag);
        Destroy(other.gameObject);
       // Debug.Log("CHOQUE22");
    }

}
