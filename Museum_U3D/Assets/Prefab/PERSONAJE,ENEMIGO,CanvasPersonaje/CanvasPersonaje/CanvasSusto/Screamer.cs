using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    public GameObject susto;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("PJ"))
        {
            Instantiate(susto);
            Destroy(gameObject);
        }
    }

}
