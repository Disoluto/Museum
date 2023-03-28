using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float TransLayers;

    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 200f;

    private Animator anim;
    public float x, y;



    void Start()
    {

        anim = GetComponent<Animator>();

    }


    void Update()
    {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        Correr();
        Move();


        if (Input.GetKeyDown(KeyCode.V))
        {
            anim.SetTrigger("parry");
        }
    }

    void Correr()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
    void Move()
    {
        if (Input.GetButton("Fire2"))
        {
            if (TransLayers <= 1)
            {
                TransLayers += 4 * Time.deltaTime;
            }
            anim.SetLayerWeight(1, TransLayers);
        }
        else
        {
            if (TransLayers > 0)
            {
                TransLayers -= 4 * Time.deltaTime;
            }
            anim.SetLayerWeight(1, TransLayers);
        }

    }


}

