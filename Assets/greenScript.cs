using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class greenScript : MonoBehaviour {
    public bool isClicked = true;
	

     public void onClick()
    {
        if (isClicked)
        {
            GetComponent<Image>().color = Color.green;
            isClicked = false;
        }
        else GetComponent<Image>().color = Color.grey;

    }
}
