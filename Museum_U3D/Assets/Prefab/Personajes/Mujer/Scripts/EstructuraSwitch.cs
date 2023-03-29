
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EstructuraSwitch : MonoBehaviour

{
    int ataque = 0;
    int salud = 0;
    int CuentaVida = 3;
    NavMeshAgent agente;
    Transform jugador;
    int estado = 0;
    [SerializeField] float cronometro = 0;
    bool inicioEstado = true;
    float distanciaJugador;
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()

    {

        //cronometro = cronometro + Time.deltaTime;
        // agente.destination = jugador.position;
        switch (estado)
        {
            case 0: Patrulla(); break;
            case 1: PerseguirPlayer(); break;
            case 2: Ataque(); break;
        }
    }
    void Patrulla()
    {
        cronometro = cronometro + Time.deltaTime;
        distanciaJugador = Vector3.Distance(transform.position, jugador.position);
        if (inicioEstado)
        {
            float randonX = Random.Range(-7.0f, 7.0f);
            float randonZ = Random.Range(-7.0f, 7.0f);

            agente.destination = new Vector3(randonX, 0, randonZ)+ transform.position;
            inicioEstado = false;
            ////Debug.Log("Patrulla");
        }
        cronometro = cronometro + Time.deltaTime;
        distanciaJugador = Vector3.Distance(transform.position, jugador.position);
        ////Debug.Log("Patrulla");

        if (cronometro > 10f)
        {
            CambiarEstado(0);
        }
        if (distanciaJugador < 15)
        {
            CambiarEstado(1);
        }

    }
    void PerseguirPlayer()
    {
        
            
        if (inicioEstado)
        {
            inicioEstado = false;
        }
        cronometro = cronometro + Time.deltaTime;
        distanciaJugador = Vector3.Distance(transform.position, jugador.position); //Debug.Log("Perseguir Player");
        agente.destination = jugador.position;
        ////Debug.Log("persigue");
        if (distanciaJugador > 5 && cronometro > 5)
            
        {
            ////Debug.Log("no persigue");
            CambiarEstado(0);
        }
        if (distanciaJugador < 2.5f)
        {
            CambiarEstado(2);
        }
        //else
        //{
        //    CambiarEstado(1);
        //}
    }
    void Ataque()
    {


        if (inicioEstado)
        {
            
            ataque = ataque + 1;
           /// Debug.Log("ataquEEEE " + (ataque));
            if (ataque == 1)
            {
                salud = int.Parse(GameObject.FindWithTag("Vida").GetComponent<TextMeshProUGUI>().text) ;
                salud = salud - 1;
                ataque = 0;
                GameObject.FindWithTag("Vida").GetComponent<TextMeshProUGUI>().text = salud.ToString();
                if (salud < 1 & CuentaVida == 3 )
                {
                    GameObject.FindWithTag("Vidas").GetComponent<TextMeshProUGUI>().text = "Vidas: 2";
                    CuentaVida = 2;
                    salud = 120;
                    GameObject.FindWithTag("Vida").GetComponent<TextMeshProUGUI>().text = salud.ToString();
                }
                if (salud < 1 & CuentaVida == 2)
                {
                    GameObject.FindWithTag("Vidas").GetComponent<TextMeshProUGUI>().text = "Vidas: 1";
                    CuentaVida = 1;
                    salud = 120;
                    GameObject.FindWithTag("Vida").GetComponent<TextMeshProUGUI>().text = salud.ToString();
                }
                if (salud < 1 & CuentaVida == 1)
                {
                    GameObject.FindWithTag("Vidas").GetComponent<TextMeshProUGUI>().text = "Vidas: 0";
                    CuentaVida = 0;
                    salud = 120;
                    GameObject.FindWithTag("Vida").GetComponent<TextMeshProUGUI>().text = salud.ToString();
                }
            }
            inicioEstado = false;
            agente.destination = transform.position;
        }
        cronometro = cronometro + Time.deltaTime;
        distanciaJugador = Vector3.Distance(transform.position, jugador.position); //Debug.Log("Perseguir Player");
                                                                                   // cambios del estado.

        if (distanciaJugador > 1.5f)
        {
            CambiarEstado(1);
        }
    }
    void CambiarEstado(int e)
    {
        estado = e;
        cronometro = 0;
        inicioEstado = true;

    }
}


