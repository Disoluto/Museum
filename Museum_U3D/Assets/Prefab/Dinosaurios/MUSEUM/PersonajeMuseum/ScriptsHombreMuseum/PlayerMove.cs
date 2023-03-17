using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int velCorrer;

    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 200f;

    public float velocidadInicial;
    public float velocidadCorriendo;

    private Animator anim;

    public float x, y;

    private void Start()
    {
        anim = GetComponent<Animator>();

        velocidadInicial = velocidadMovimiento;
        velocidadCorriendo = velocidadMovimiento * 1.5f;
    }


    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
       

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("correr", true);
            velocidadMovimiento = velocidadCorriendo;
        }
        else
        {
            anim.SetBool("correr", false);
            velocidadMovimiento = velocidadInicial;
        }
       



        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);



    }
}
