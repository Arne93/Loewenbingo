using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTextAnimation : MonoBehaviour {

	float timeLeft = 2.2f;
	// Use this for initialization
	void Start () {
		timeLeft = 2.2f;	
	}

	public void Restart(){
		timeLeft = 2.2f;
	}
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			var mainPanel = GameObject.Find("Canvas");
			var x = (initializeButtons)mainPanel.GetComponent(typeof(initializeButtons));
			x.ShowTextOnButton ();
		}	
	}
}
