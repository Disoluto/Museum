using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Tiempo : MonoBehaviour
{
    Prueba datos;
    public int PPuntos = 0;
    string mitiempo;
    float timeRemaining = 180;
    public bool timerIsRunning = false;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        mitiempo = timeRemaining.ToString("F1");
        CalculoTiempo();
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                //Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    void CalculoTiempo()
    {
        GameObject.FindWithTag("Tiempo").GetComponent<TextMeshProUGUI>().text = mitiempo;
        if (timeRemaining > 120)
        {
            GameObject.FindWithTag("Tiempo").GetComponent<TextMeshProUGUI>().color = new Color(222, 41, 22, 255);
        }
        if (timeRemaining < 120 & timeRemaining > 60)
        {
            GameObject.FindWithTag("Tiempo").GetComponent<TextMeshProUGUI>().color = new Color(255, 231, 0, 255);
        }
        if (timeRemaining < 60)
        {
            GameObject.FindWithTag("Tiempo").GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
        }
        if (timeRemaining < 1)
        {
            GameObject.FindWithTag("Fin").GetComponent<Canvas>().enabled = true;
        }

    }
}
