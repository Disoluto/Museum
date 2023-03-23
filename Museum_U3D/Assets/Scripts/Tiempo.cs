using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    //Variables compartidas en todas las escenas
    public float tiempo = 0; //Para contabilizar el tiempo
    public bool isJuego = true; //Para saber si estoy jugando y que se incremente el tiempo cuando entre en la escena de Juego
    public int vidas = 3; //para contabilizar las vidas
    public int monedas = 20; //para contabilizar las monedas restantes
    //Variable para asociar el objeto Texto Tiempo
    public Text textoTiempo;

    //Script GameManager
    private GameManager gameManager;

    void Start()
    {

        //Inicializo el texto del contador de tiempo
        textoTiempo.text = "Tiempo: 00:00";

        //Capturo el script de GameManager
        gameManager = FindObjectOfType<GameManager>();

    }

    void Update()
    {

        //Escribo tiempo transcurrido (si no se ha acabado el juego)
        if (gameManager.isJuego)
        {
            textoTiempo.text = "Tiempo: " + formatearTiempo();
        }

    }

    //Formatear tiempo (p�blico porque la necesitaremos m�s adelante)
    public string formatearTiempo()
    {

        //A�ado el intervalo transcurrido a la variable tiempo
        if (gameManager.isJuego)
        {
            gameManager.tiempo += Time.deltaTime;
        }

        //Formateo minutos y segundos a dos d�gitos
        string minutos = Mathf.Floor(gameManager.tiempo / 60).ToString("00");
        string segundos = Mathf.Floor(gameManager.tiempo % 60).ToString("00");

        //Devuelvo el string formateado con : como separador
        return minutos + ":" + segundos;

    }
}
