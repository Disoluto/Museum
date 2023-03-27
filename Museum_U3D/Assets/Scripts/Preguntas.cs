using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using System;

public class Preguntas : MonoBehaviour
{

    public TextAsset xmlRawFile;
    string Rcorrecta = "";
    int Puntos;
    XmlNodeList myNodeList;
    void Start()
    {
        string data = xmlRawFile.text;
        parseXmlFile(data);
        Debug.Log(data);

    }
    void parseXmlFile(string xmlData)

    {

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("Assets/Resources/Preg_M.xml");
        string xmlPathPattern = "//FT009/Registros";
        myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
        Debug.Log(xmlPathPattern);


    }
    public void Setpreguntas(string v)
    {
        Debug.Log(v);
        string Rcorrecta = "";
        XmlDocument xmlDoc = new XmlDocument();
        ////xmlDoc.Load(new StringReader(xmlData));
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
            if (Obra.InnerXml == v)
            {
                GameObject.FindWithTag("Pregunta").GetComponent<TextMeshProUGUI>().text = (Pregunta.InnerXml);
                GameObject.FindWithTag("TextA").GetComponentInChildren<TextMeshProUGUI>().text = (A.InnerXml);
                GameObject.FindWithTag("TextB").GetComponentInChildren<TextMeshProUGUI>().text = (B.InnerXml);
                GameObject.FindWithTag("TextC").GetComponentInChildren<TextMeshProUGUI>().text = (C.InnerXml);
                Rcorrecta = D.InnerXml;
            }
                Debug.Log(Rcorrecta);
        }
    }


    //void OnGUI()
    //{

    //    ////GUI.skin.label.fontSize = 24;
    //    ////GUI.contentColor = Color.green;
    //    //////GUIStyle style = new GUIStyle();
    //    //////style.fontSize = 24;
    //    ////GUI.Label(new Rect(10, 0, 150, 33), "Puntuación: " + Puntos);
    //}

    //public void BotonA() 
    //{
    //    if (Rcorrecta == "A")
    //    {
    //        Puntos = Puntos + 50;
    //    }
    //    else
    //    {
    //        Puntos = Puntos - 10;
    //    }
    //}
    //public void BotonB()
    //{
    //    if (Rcorrecta == "B")
    //    {
    //        Puntos = Puntos + 50;
    //    }
    //    else 
    //    {
    //        Puntos = Puntos - 10;
    //    }
    //}
    //public void BotonC()
    //{
    //    if (Rcorrecta == "C")
    //    {
    //        Puntos = Puntos + 50;
    //    }
    //    else
    //    {
    //        Puntos = Puntos - 10;
    //    }
    //}
}