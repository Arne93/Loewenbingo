using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetScript : MonoBehaviour {

	public void reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
