using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HacerDanio : MonoBehaviour
{
    public float cantidadDanio;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("PJ") && coll.GetComponent<Salud>())
        {
            coll.GetComponent<Salud>().RecibirDanio(cantidadDanio);
        }
    }

}
