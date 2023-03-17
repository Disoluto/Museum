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

    public AudioSource pasos;
    private bool Hactivo;
    private bool Vactivo;

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
        if (Input.GetButtonDown("Horizontal"))
        {
            Hactivo = true;
            pasos.Play();
        }
        if (Input.GetButtonDown("Vertical"))
        {
            if (Hactivo == false)
            {
                Vactivo = true;
                pasos.Play();

            }
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            Hactivo = false;
            if (Vactivo == false)
            {
                pasos.Pause();

            }
        }
        if (Input.GetButtonUp("Vertical"))
        {
            Vactivo = false;
            if (Hactivo == false)
            {
                pasos.Pause();

            }
        }




        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);



    }
}
