using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
public class Preguntas : MonoBehaviour
{
    [SerializeField] string Cuadro;
    public TextAsset xmlRawFile;
    string Rcorrecta = "";
    int Puntos = 0;
    void Start()
    {
        string data = xmlRawFile.text;
        parseXmlFile(data);
        
    }
    void parseXmlFile(string xmlData)
    {
        //Debug.Log(xmlData);
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
    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;
        GUI.Label(new Rect(10, 0, 0, 0), "Puntuación:" + Puntos, style);
    }

    public void BotonA() 
    {
        if (Rcorrecta == "A")
        {
            Puntos = Puntos + 1;
        }
    }
    public void BotonB()
    {
        if (Rcorrecta == "B")
        {
            Puntos = Puntos + 1;
        }
    }
    public void BotonC()
    {
        if (Rcorrecta == "C")
        {
            Puntos = Puntos + 1;
        }
    }
}