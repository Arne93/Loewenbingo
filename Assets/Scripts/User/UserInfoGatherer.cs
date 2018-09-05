using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UserInfoGatherer : MonoBehaviour {
    public InputField infoField;

    public void SendInfo() {
        UserController.Instance.ReceiveInfo(infoField.text);
    }
}
