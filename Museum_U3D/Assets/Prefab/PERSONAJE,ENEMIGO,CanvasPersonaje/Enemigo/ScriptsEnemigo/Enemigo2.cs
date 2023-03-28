using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo2 : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator anim;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;

    public GameObject arma;
    public bool stuneado;
    public RangoEnemigo rango;

    public float speed;

    public NavMeshAgent agente;
    public float distancia_Ataque;
    public float radio_Vision;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Jugador");
    }



    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > radio_Vision)
        {
            agente.enabled = false;
            anim.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro > 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;

            }
            switch (rutina)
            {
                case 0:
                    anim.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    anim.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            agente.enabled = true;
            agente.SetDestination(target.transform.position);

            if (Vector3.Distance(transform.position, target.transform.position)> distancia_Ataque && !atacando)
            {
                anim.SetBool("walk", false);
                anim.SetBool("run", true);
            }
            else
            {
                if (!atacando)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 1);
                    anim.SetBool("walk", false);
                    anim.SetBool("run", false);
                }
            }

        }
        if (atacando)
        {
            agente.enabled = false;
        }
    }
    public void Final_Anim()
    {
        if (Vector3.Distance(transform.position, target.transform.position)>distancia_Ataque + 0.2f)
        {
            anim.SetBool("attack", false);
            atacando = false;
            stuneado = false;
            rango.GetComponent<CapsuleCollider>().enabled = true;

        }
    }
    public void ColliderWeaponTrue()
    {
        arma.GetComponent<BoxCollider>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        arma.GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        Comportamiento_Enemigo();
    }
}