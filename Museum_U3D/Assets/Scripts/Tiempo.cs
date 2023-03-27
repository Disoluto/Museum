using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Tiempo : MonoBehaviour
{
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
        mitiempo = timeRemaining.ToString("F1") + " segundos";
       // Debug.Log(mitiempo);
        //GameObject.FindWithTag("Tiempo").GetComponent<TextMeshProUGUI>().text = "2222";//mitiempo;//timeRemaining.ToString();
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
    void OnGUI()
    {
        //GUIStyle style = new GUIStyle();

        //style.normal.textColor = Color.red;
        //style.fontSize = 24;
        if (timeRemaining > 120)
        {
            GUI.skin.label.fontSize = 24;
            GUI.contentColor = Color.green;
        }
        if (timeRemaining < 120 & timeRemaining > 60)
        {
            GUI.skin.label.fontSize = 24;
            GUI.contentColor = Color.magenta;
        }
        if (timeRemaining < 60)
        {
            GUI.skin.label.fontSize = 24;
            GUI.contentColor = Color.red;
        }
        GUI.Label(new Rect(10, 20, 300, 48), "Tiempo:  " + mitiempo);
        if (timeRemaining < 1)
        {
            GameObject.FindWithTag("Fin").GetComponent<Canvas>().enabled = true;

        }

    }
}
