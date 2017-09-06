using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveScript : MonoBehaviour {
    public InputField iP;
    string ipText;
    List<string> copy = initializeButtons.bingoList;
	// Use this for initialization
	void Start () {

	}



    public void safePlayerPrefs()
    {
        ipText = iP.text;
        
        Debug.Log(ipText);
        for(int i = 0; i < copy.Count; i++)
        {
            PlayerPrefs.SetString(ipText + i, copy[i]); //key: ipText0-i, value: copy[i]
            Debug.Log(PlayerPrefs.GetString(iP.text + i));
        }
        PlayerPrefs.Save();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
