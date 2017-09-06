using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadScript : MonoBehaviour {
    List<string> newBingoList = new List<string>();
    int size = initializeButtons.bingoList.Count;
    public InputField iP;
	// Use this for initialization
	void Start () {
		
	}
    public void loadPlayerPrefs()
    {
        for(int i = 0; i < size; i++)
        {
            newBingoList.Add( PlayerPrefs.GetString(iP.text + i));
            Debug.Log(PlayerPrefs.GetString(iP.text + i));
        }
        initializeButtons.bingoList = newBingoList;
        initializeButtons.reInit = true;
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
