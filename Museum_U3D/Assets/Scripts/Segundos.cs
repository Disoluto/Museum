using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segundos : MonoBehaviour
{
    // Start is called before the first frame update
    public void comienzo()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        Time.timeScale = 0;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        Time.timeScale = 1;
    }
}
