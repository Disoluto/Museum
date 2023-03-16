using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Xml;
public class Preguntas : MonoBehaviour
{
    public TextAsset xmlRawFile;
    public Text uiText;
    private void Start()
    {
        string data = xmlRawFile.text;
        parseXmlFile(data);
    }
    void parseXmlFile(string xmlData)
    {
        string totVal = "";
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));
        string xmlPathPattern = "//FT009/Registros";
        XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);
        foreach(XmlNode node in myNodeList)
        {
            XmlNode Obra = node.FirstChild;
            XmlNode Pregunta = Obra.NextSibling;
            XmlNode A = Pregunta.NextSibling;

            totVal = "+Name: " + Obra.InnerXml;
            Debug.Log(totVal);
           // uiText.text = totVal;
        }
    }
}