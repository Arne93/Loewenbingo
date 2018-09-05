using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTextAnimation : MonoBehaviour {
    public GameObject canvas;
	// Use this for initialization
	void OnEnable () {
        //StartCoroutine(FadeInRoutine());
	}

	public void Restart(){
        StartCoroutine(FadeInRoutine());
	}

    private IEnumerator FadeInRoutine() {
        yield return new WaitForSecondsRealtime(2.2f);
        var mainPanel = canvas;
        var x = (initializeButtons)mainPanel.GetComponent(typeof(initializeButtons));
        x.ShowTextOnButton();
    }

	// Update is called once per frame
	void Update () {
	}
}
