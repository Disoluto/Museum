using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
public class Prueba : MonoBehaviour
{
    FIN salir;
    string Cuadro = "C3";
    string pprueba = "";
    public TextAsset xmlRawFile;
    string Rcorrecta;
    int Puntuacion = 0;
    string Atexxto;
    FIN ter;

    private void Start()
    {

        GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        GameObject.FindWithTag("DatosPuntos").GetComponent<Canvas>().enabled = false;
        string data = xmlRawFile.text;
        Atexxto = xmlRawFile.text;
        parseXmlFile(data);
        Debug.Log(data);
        //ter.Exit();

    }
    void parseXmlFile(string xmlData)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));
        string xmlPathPattern = "//FT009/Registros";
        XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
        Debug.Log(xmlPathPattern);
        foreach (XmlNode node in myNodeList)
        {
            XmlNode Obra = node.FirstChild;
            XmlNode Pregunta = Obra.NextSibling;
            XmlNode A = Pregunta.NextSibling;
            XmlNode B = A.NextSibling;
            XmlNode C = B.NextSibling;
            XmlNode D = C.NextSibling;

            if (Obra.InnerXml.Equals(Cuadro))
            {
                GameObject.FindWithTag("Pregunta").GetComponent<TextMeshProUGUI>().text = (Pregunta.InnerXml);
                GameObject.FindWithTag("TextA").GetComponentInChildren<TextMeshProUGUI>().text = (A.InnerXml);
                GameObject.FindWithTag("TextB").GetComponentInChildren<TextMeshProUGUI>().text = (B.InnerXml);
                GameObject.FindWithTag("TextC").GetComponentInChildren<TextMeshProUGUI>().text = (C.InnerXml);
                GameObject.FindWithTag("Respuesta").GetComponent<TextMeshProUGUI>().text = (D.InnerXml);
                Rcorrecta = GameObject.FindWithTag("Respuesta").GetComponent<TextMeshProUGUI>().text;
                Time.timeScale = 0;
                
            }

        }

    }

    void BotonA()
    {
        pprueba = "A";
        Time.timeScale = 1;
        if (GameObject.FindWithTag("Respuesta").GetComponent<TextMeshProUGUI>().text.Equals(pprueba))
        {
            SumoPuntos();
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
            GameObject.FindWithTag("Pausa").GetComponent<TextMeshProUGUI>().text = "C O R R E C T A";
            Debug.Log("T O T A L -A-:  " + Puntuacion);
            //Actualizo PUNTOS
            GameObject.FindWithTag("Puntos").GetComponent<TextMeshProUGUI>().text = "Puntos: " + (Puntuacion);
            comienzo();
        }
        else
        {
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
            GameObject.FindWithTag("Pausa").GetComponent<TextMeshProUGUI>().text = "E R R O R";
            comienzo();
            if (Puntuacion > 10)
            {
             Puntuacion = Puntuacion - 10;
             GameObject.FindWithTag("Puntos").GetComponent<TextMeshProUGUI>().text = "Puntos: " + (Puntuacion);

            }
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        }

    }
    void BotonB()
    {
        pprueba = "B";
        Time.timeScale = 1;
        if (GameObject.FindWithTag("Respuesta").GetComponent<TextMeshProUGUI>().text.Equals(pprueba))
        {
            SumoPuntos();
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
            GameObject.FindWithTag("Pausa").GetComponent<TextMeshProUGUI>().text = "C O R R E C T A";
            Debug.Log("T O T A L -B-:  " + Puntuacion);
            //Actualizo PUNTOS
            GameObject.FindWithTag("Puntos").GetComponent<TextMeshProUGUI>().text = "Puntos: " + (Puntuacion);
            comienzo();
        }
        else
        {
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
            GameObject.FindWithTag("Pausa").GetComponent<TextMeshProUGUI>().text = "E R R O R";
            comienzo();
            if (Puntuacion > 10)
            {
                Puntuacion = Puntuacion - 10;
                GameObject.FindWithTag("Puntos").GetComponent<TextMeshProUGUI>().text = "Puntos: " + (Puntuacion);

            }
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        }
    }
     void BotonC()
    {
        pprueba = "C";
        Time.timeScale = 1;
        if (GameObject.FindWithTag("Respuesta").GetComponent<TextMeshProUGUI>().text.Equals(pprueba))
        {
            SumoPuntos();
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
            GameObject.FindWithTag("Pausa").GetComponent<TextMeshProUGUI>().text = "C O R R E C T A";
            Debug.Log("T O T A L -C-:  " + Puntuacion);
            //Actualizo PUNTOS
            GameObject.FindWithTag("Puntos").GetComponent<TextMeshProUGUI>().text = "Puntos: " + (Puntuacion);
            comienzo();
        }
        else
        {
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
            GameObject.FindWithTag("Pausa").GetComponent<TextMeshProUGUI>().text = "E R R O R";
            comienzo();
            if (Puntuacion > 10)
            {
                Puntuacion = Puntuacion - 10;
                GameObject.FindWithTag("Puntos").GetComponent<TextMeshProUGUI>().text = "Puntos: " + (Puntuacion);

            }
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Cuadro = other.gameObject.tag;
        Debug.Log("choca: " + other.gameObject.tag);

        parseXmlFile(Atexxto);
        GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = true;
        Debug.Log("choca: " + other.gameObject.tag);
        Destroy(other.gameObject);
       

    }

    void comienzo()
    {

        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        Time.timeScale = 0;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(3);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        Time.timeScale = 1;
        GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        GameObject.FindWithTag("Pausa").GetComponent<TextMeshProUGUI>().text = "";
    }
    void SumoPuntos()
    {
        Puntuacion = Puntuacion + 80;
        if (Puntuacion > 80)
        {
            GameObject.FindWithTag("Pausa").GetComponent<TextMeshProUGUI>().text = "G A N A S T E";
            comienzo();
            Debug.Log("Enhorabuena" );
            Application.Quit();
        }
        //Debug.Log("T O T A L       P U N T O S:  " + Puntuacion + "  " + pprueba);
    }

}