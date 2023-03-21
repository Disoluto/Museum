using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class CCSSVV : MonoBehaviour
{
    public List<string> inventory = new List<string>();
    public List<string> OnlyX = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        string filePath = getPath();

        StreamWriter writer = new StreamWriter(filePath);

        writer.WriteLine("Inventory,OnlyX");

        for (int i = 0; i < inventory.Count; ++i)
        {

            writer.WriteLine(inventory[i]);

        }
        for (int j = 0; j < OnlyX.Count; ++j)
        {

            writer.WriteLine("," + OnlyX[j]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Data/" + "Saved_Inventory.csv";
        //"Participant " + "   " + DateTime.Now.ToString("dd-MM-yy   hh-mm-ss") + ".csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_Inventory.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_Inventory.csv";
#else
        return Application.dataPath +"/"+"Saved_Inventory.csv";
#endif
    }
}
