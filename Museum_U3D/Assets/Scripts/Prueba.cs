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
    public Segundos espera;

    public TextAsset xmlRawFile;
    string Rcorrecta;
    public int Puntos = 0;
    string Atexxto;
    Canvas CanvasObject;
    private void Start()
    {
        Time.timeScale = 0;
        GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        string data = xmlRawFile.text;
        Atexxto = xmlRawFile.text;
        parseXmlFile(data);
        Debug.Log(data);

    }
    void parseXmlFile(string xmlData)
    {
        //string totVal = "";
        //string AA = "";
        
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

            //totVal = Pregunta.InnerXml;
            // AA = A.InnerXml;
            if (Obra.InnerXml.Equals(Cuadro))
            {
                GameObject.FindWithTag("Pregunta").GetComponent<TextMeshProUGUI>().text = (Pregunta.InnerXml);
                GameObject.FindWithTag("TextA").GetComponentInChildren<TextMeshProUGUI>().text = (A.InnerXml);
                GameObject.FindWithTag("TextB").GetComponentInChildren<TextMeshProUGUI>().text = (B.InnerXml);
                GameObject.FindWithTag("TextC").GetComponentInChildren<TextMeshProUGUI>().text = (C.InnerXml);
                Rcorrecta = D.InnerXml;
            }
            pprueba = Rcorrecta;
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAA---------" + Rcorrecta);
        }

    }

    public void BotonA()
    {
        pprueba = "A";
        if (Rcorrecta.Equals(pprueba))
        {
            GameObject.FindWithTag("TextA").GetComponentInChildren<TextMeshProUGUI>().text = " C O R R E C T A";
            Puntos = Puntos + 80;
            
            comienzo();
        }
        else
        {
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        }
        ///Invoke("Tiempos", 10.0f);
        //GetComponent<Segundos>();
    }
    public void BotonB()
    {
        pprueba = "B";
        if (Rcorrecta.Equals(pprueba))
        {
            GameObject.FindWithTag("Pregunta").GetComponentInChildren<TextMeshProUGUI>().text = " C O R R E C T A";
            Puntos = Puntos + 80;
            comienzo();
        }
        else
        {
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        }
        ///Invoke("Tiempos", 10.0f);
        //GetComponent<Segundos>();
    }
    public void BotonC()
    {
        pprueba = "C";
        if (Rcorrecta.Equals(pprueba))
        {
            GameObject.FindWithTag("TextC").GetComponentInChildren<TextMeshProUGUI>().text = " C O R R E C T A";
            Puntos = Puntos + 80;
            comienzo();
        }
        else
        {
            GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        }
        ///Invoke("Tiempos", 10.0f);
       // GetComponent<Segundos>();
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
    void OnGUI()
    {
        GUI.skin.label.fontSize = 24;
        GUI.contentColor = Color.yellow;
        GUI.Label(new Rect(10, 0, 200, 33), "Puntos:  " + Puntos);


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