using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
public class Prueba : MonoBehaviour
{

    string Cuadro = "C3";
    string pprueba = "";
    public TextAsset xmlRawFile;
    string Rcorrecta;
    public int Puntos = 0;
    string Atexxto;

    private void Start()
    {

        GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        GameObject.FindWithTag("DatosPuntos").GetComponent<Canvas>().enabled = false;
        string data = xmlRawFile.text;
        Atexxto = xmlRawFile.text;
        parseXmlFile(data);
        Debug.Log(data);

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
            }

        }

    }

    public void BotonA()
    {
        pprueba = "A";
        if (GameObject.FindWithTag("Respuesta").GetComponent<TextMeshProUGUI>().text.Equals(pprueba))
        {
            GameObject.FindWithTag("Pregunta").GetComponent<TextMeshProUGUI>().text = " C O R R E C T A";
            Puntos = Puntos + 80;
            //Actualizo PUNTOS
            GameObject.FindWithTag("Puntos").GetComponent<TextMeshProUGUI>().text = "Puntos: " + Puntos.ToString();
            comienzo();
        }
        else
        {
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
            if (Puntos > 10)
            {
                Puntos = Puntos - 10;
            }    
            //Actualizo PUNTOS
            GameObject.FindWithTag("Puntos").GetComponent<TextMeshProUGUI>().text = "Puntos: " + Puntos.ToString();
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        }

    }
    public void BotonB()
    {
        
        pprueba = "B";
        if (GameObject.FindWithTag("Respuesta").GetComponent<TextMeshProUGUI>().text.Equals(pprueba))
        {
            GameObject.FindWithTag("Pregunta").GetComponent<TextMeshProUGUI>().text = " C O R R E C T A";
            Puntos = Puntos + 80;
            //Actualizo PUNTOS
            GameObject.FindWithTag("Puntos").GetComponent<TextMeshProUGUI>().text = "Puntos: " + Puntos.ToString();
            comienzo();
        }
        else
        {
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
            if (Puntos > 10)
            {
                Puntos = Puntos - 10;
            }
            //Actualizo PUNTOS
            GameObject.FindWithTag("Puntos").GetComponent<TextMeshProUGUI>().text = "Puntos: " + Puntos.ToString();
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        }

    }
    public void BotonC()
    {
        pprueba = "C";
        if (GameObject.FindWithTag("Respuesta").GetComponent<TextMeshProUGUI>().text.Equals(pprueba))
        {
            GameObject.FindWithTag("Pregunta").GetComponent<TextMeshProUGUI>().text = " C O R R E C T A";
            Puntos = Puntos + 80;
            //Actualizo PUNTOS
            GameObject.FindWithTag("Puntos").GetComponent<TextMeshProUGUI>().text = "Puntos: " + Puntos.ToString();
            comienzo();
        }
        else
        {
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
            if (Puntos > 10)
            {
                Puntos = Puntos - 10;
            }
            //Actualizo PUNTOS
            GameObject.FindWithTag("Puntos").GetComponent<TextMeshProUGUI>().text = "Puntos: " + Puntos.ToString();
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
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        Time.timeScale = 0;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        Time.timeScale = 1;
        GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
    }
}