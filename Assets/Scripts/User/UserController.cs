using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour {
    private readonly string userInfo = "user_info";
    private static UserController m_UserController = null;
    public GameObject infoGatherer;

    private User m_CurrentUser;

    public User CurrentUser {
        get {
            return m_CurrentUser;
        }
    }

    private UserController() {

    }

    public static UserController Instance
    {
        get
        {
            if (m_UserController == null)
                m_UserController = new UserController();
            return m_UserController;
        }
    }

    // Use this for initialization
    private void Awake()
    {
        if (m_UserController == null)
            m_UserController = this;
    }

    void Start () {
        // there is already a user registered
        if (PlayerPrefs.HasKey(userInfo)) {
            m_CurrentUser = new User(PlayerPrefs.GetString("user_info"));
            return;
        }
        infoGatherer.SetActive(true);
    }
	
	public void ReceiveInfo(string info) {
        m_CurrentUser = new User(info);
        PlayerPrefs.SetString(userInfo,info);
        PlayerPrefs.Save();
    }
    


}
