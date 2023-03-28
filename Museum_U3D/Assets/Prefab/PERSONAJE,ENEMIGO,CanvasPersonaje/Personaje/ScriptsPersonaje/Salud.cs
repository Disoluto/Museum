using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Salud : MonoBehaviour
{
    public float salud = 100;
    public float saludMaxima = 100;

    [Header("Interfaz")]
    public Image barraSalud;
    public Text textoSalud;
    public CanvasGroup golpe;

    [Header("Muerto")]
    public GameObject Muerto;


    void Update()
    {
        if (golpe.alpha>0)
        {
            golpe.alpha -= Time.deltaTime;
        }
        ActualizarInterfaz();
    }

    public void RecibirDanio(float danio)
    {
        salud -= danio;
        golpe.alpha = 1;

        if (salud <=0)
        {
            Instantiate(Muerto);
            //Destroy(gameObject);
        }
    }

    void ActualizarInterfaz()
    {
        barraSalud.fillAmount = salud / saludMaxima;
        textoSalud.text = "Salud: " + salud.ToString("f0");
    }
}
