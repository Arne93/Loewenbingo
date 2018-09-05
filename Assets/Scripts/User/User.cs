using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User {
    // Name has to be unique
    [SerializeField]
    string name { get; }
	
    public User(string user) {
        this.name = user;
    } 
}
