using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButtonCaptionHandler : MonoBehaviour {
    public Button loadButton;
    public InputField iP;

	// Use this for initialization
	void Start () {
        iP.onValueChanged.AddListener(delegate { ValueChanged(); });
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    public void ValueChanged()
    {
        if (PlayerPrefs.HasKey(iP.text + "0"))
        {
            loadButton.GetComponentInChildren<Text>().text = "Laden";
        }
        else
        {
            loadButton.GetComponentInChildren<Text>().text = "Neues Spiel";
        }
    }
}
