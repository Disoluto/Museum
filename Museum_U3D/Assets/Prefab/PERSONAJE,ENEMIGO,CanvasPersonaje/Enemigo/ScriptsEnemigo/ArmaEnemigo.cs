using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaEnemigo : MonoBehaviour
{
    public GameObject enemigo;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("PJ"))
        {
            print("Danio");
        }

        if (coll.CompareTag("escudo"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            print("Bloqueo");
        }
        if (coll.CompareTag("parry"))
        {
            enemigo.GetComponent<Enemigo2>().stuneado = true;
            enemigo.GetComponent<Animator>().SetBool("stun", true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void Start()
    {
        
    }


    void Update()
    {

    }
}
