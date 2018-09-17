using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;



public class SaveTextScript : MonoBehaviour {

    public static List<string> bingoList = new List<string> {
            "Löwe erzählt aus seinem Leben",
            "Löwen investieren als Team",
            "Gründer weint",
            "Altes Produkt wird gezeigt",
            "Backstage-Mitarbeiter ist unangenehm",
            "Aus den genannten Gründen bin ich raus",
            "Es ist nicht Franks Welt/DNA",
            "Marge zu gering",
            "Produkt hat gute Qualität",
            "Produkt hat Potenzial",
            "Ich bin Ihr Kunde, aber nicht ihr Investor",
            "An die Hand nehmen",
            "Sie sind mir sympathisch",
            "Dümmel kauft 2x hintereinander",
            "Essbares Produkts ist vegan",
            "Nische",
            "25,1%",
            "Unter 50.000€ Umsatz",
            "Ein Löwe testet",
            "Models stellen vor",
            "Gründer sind Familienunternehmen",
            "Bewertung zu hoch",
            "Ich als ..., weiß was harte Arbeit ist",
            "Was ist euer USP?",
            "Ich hab Bock das mit euch groß zu machen"

        };
    string newString;

public InputField iP;
    string message;
    string loadMessage = "Yeah working";
    string data;
    FileInfo f;
    string path;
    string path2;


    // Use this for initialization
    void Start () {
        path = "Assets/Resources/test.txt";
        path2 = Application.persistentDataPath + "\\" + "bingoList.txt";
        f = new FileInfo(path);
        Debug.Log(Application.persistentDataPath);

        if (f.Exists)
        {
            newString = Load();
        }
        else
        {
            iP.text = writeListToString();
            newString = writeListToString();
            onClick();
        }

        iP.text = newString;
    }

    public void onClick()
    {
        using (StreamWriter sw = f.CreateText())
        {
            sw.Write(iP.text);
        }
        //iP.text = writeListToString();



    }

    string Load()
    {
        string s = "";
        using (StreamReader sr = f.OpenText())
        {
            s = sr.ReadToEnd();
        }

        return s;
    }

    

    string writeListToString()
    {
        string listString ="";
        foreach (string s in bingoList)
        {
             listString = listString + s + "\r\n" ;
            
        }
        return listString;
    }

    void writeToInputField()
    {
     
    }


}
	

