using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Field{
    public bool check { get; set; }
    public string text { get; }

    public Field(string text, bool check = false) {
        this.text = text;
        this.check = false;
    }
}