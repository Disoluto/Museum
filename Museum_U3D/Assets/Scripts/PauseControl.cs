using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Debug.Log("SE PARA EL TIEMPO");
            GameObject.FindWithTag("Pausa").GetComponent<TextMeshProUGUI>().text = "P A U S A";
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
            GameObject.FindWithTag("Pausa").GetComponent<TextMeshProUGUI>().text = "";
        }
    }
}
