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

    public Segundos espera;

    public TextAsset xmlRawFile;
    string Rcorrecta = "";
    int Puntos = 0;
    string Atexxto;
    Canvas CanvasObject;
    private void Start()
    {
        GameObject.FindWithTag("Fin").GetComponent<Canvas>().enabled = false;
        GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        ////CanvasObject.GetComponent<Canvas>().enabled = false;
        string data = xmlRawFile.text;
        Atexxto = xmlRawFile.text;
        parseXmlFile(data);
        Debug.Log(data);
    }
    void parseXmlFile(string xmlData)
    {
        //string totVal = "";
        //string AA = "";
        string Rcorrecta = "";
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
            if (Obra.InnerXml == Cuadro)
            {
                GameObject.FindWithTag("Pregunta").GetComponent<TextMeshProUGUI>().text = (Pregunta.InnerXml);
                GameObject.FindWithTag("TextA").GetComponentInChildren<TextMeshProUGUI>().text = (A.InnerXml);
                GameObject.FindWithTag("TextB").GetComponentInChildren<TextMeshProUGUI>().text = (B.InnerXml);
                GameObject.FindWithTag("TextC").GetComponentInChildren<TextMeshProUGUI>().text = (C.InnerXml);
                Rcorrecta = D.InnerXml;
            }
            //totVal = "+Name: " + Obra.InnerXml;
            Debug.Log(Rcorrecta);
            // uiText.text = totVal;
            //GameObject.Find("RA").GetComponentInChildren<Text>().text = "la di da";



            //GameObject.Find("Pregunta").GetComponentInChildren<TextMesh>().text = "Button Text";
        }

    }

    public void BotonA()
    {
        if (Rcorrecta == "A")
        {
            Puntos = Puntos + 50;
        }
        else
        {
            Puntos = Puntos - 10;
        }
        espera.comienzo();
       // yield return new WaitForSecondsRealtime(5);
        GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAA");
        
    }
    public void BotonB()
    {
        if (Rcorrecta == "B")
        {
            Puntos = Puntos + 50;
        }
        else
        {
            Puntos = Puntos - 10;
        }
        GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
        GetComponent<Segundos>();
    }
    public void BotonC()
    {
        if (Rcorrecta == "C")
        {
            Puntos = Puntos + 50;
        }
        else
        {
            Puntos = Puntos - 10;
        }
        GetComponent<Segundos>();
        GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Cuadro = other.gameObject.tag;
        Debug.Log("choca: " + other.gameObject.tag);

        parseXmlFile(Atexxto);
        GameObject.FindWithTag("Canvass").GetComponent<Canvas>().enabled = true;
        ////other.GetComponent<Preguntas>().Setpreguntas(other.gameObject.tag);
        ////    other.GetComponent<Preguntas>().Setpreguntas(other.gameObject.tag);
        Debug.Log("choca: " + other.gameObject.tag);
        Destroy(other.gameObject);


    }
    void OnGUI()
    {
        //GUIStyle style = new GUIStyle();
        //style.fontSize = 24;
        GUI.skin.label.fontSize = 24;
        GUI.contentColor = Color.yellow;
        GUI.Label(new Rect(10, 0, 200, 33), "                   ");
        GUI.Label(new Rect(10, 0, 200, 33), "Puntos:  " + Puntos);
    }
}