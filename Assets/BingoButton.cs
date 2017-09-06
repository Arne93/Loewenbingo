using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BingoButton : MonoBehaviour {

    string content;
    bool isChecked = false;

    BingoButton(string s, bool b)
    {
        content = s;
        isChecked = b;
    }

}
