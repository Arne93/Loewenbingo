using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Board {
    public string name;
    public List<Field> fields = new List<Field>();

    public Board(string name, string[] fieldNames, bool[] check) {
        if (check.Length != fieldNames.Length)
            return;
        for (int i = 0; i < fieldNames.Length; i++)  {
            string s = fieldNames[i];
            bool _check = check[i];
            fields.Add(new Field(s, _check));
        }
        this.name = name;
    }
}
