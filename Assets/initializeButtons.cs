using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

    public class ListContainer
    {
        public static List<string> nameList = new List<string> {"Fynn",
"Fiete",
"Jan",
"Arvid",
"Mats",
"Levin",
"Karl",
"Ansgar",
"Sebastian",
"Malte",
"Dirk",
"Jörg",
"Elmar",
"Carsten",
"Herbert",
"Norwin",
"Siegfried",
"Raik",
"Frank",
"Hagen",
"Lennard",
"Nantwin",
"Hugo",
"Henri",
"Lennart",
"Jonas",
"Dean",
"Len",
"Arian",
"Horst",
"Dietrich",
"Günther",
"Gangolf",
"Gandulf",
"Godehard",
"Gerulf",
"Gernot",
"Leon",
"Luis",
"Leif",
"Siegenot-Beowulf",
"Yorick",
"Pirmin",
"Gottfried",
"Günther",
"Norbert",
"Reinhold",
"Felix",
"Carolin",
"Emma",
"Lara",
"Anna",
"Traudel",
"Selma",
"Hilde",
"Hanna",
"Lorena",
"Sigrun",
"Hedwig",
"Sandra",
"Emilia",
"Leni",
"Hortensia-Rose",
"Pauline",
"Hortensia-Emilia",
"Lina",
"Rena",
"Lone",
"Pia",
"Hanne",
"Merle",
"Maya",
"Mathilda",
"Milla",
"Melina",
"Mercedes",
"Karina",
"Hortensia-Pia",
"Maja",
"Ina",
"Marie-Luise",
"Edith",
"Jule",
"Johanna",
"Jolina",
"Jette",
"Ella",
"Sibylle-Rose",
"Rosalie",
"Amalia-Helene",
"Bea",
"Uta",
"Rose",
"Roswitha",
"Thea",
"Theresia",
"Tamina",
"Giselotte",

 };
        public static List<string> bingoList = new List<string> { "Löwe erzählt aus seinem Leben",
            "Löwen investieren als Team",
            "Gründer weint",
            "Altes Produkt wird gezeigt",
            "Backstage-Mitarbeiter ist unangenehm",
            "Aus dem Grund bin ich raus",
            "Es ist nicht Franks Welt/DNA",
            "Marge zu gering",
            "Produkt hat gute Qualität",
            "Produkt hat Potenzial",
            "Ich bin Ihr Kunde, aber nicht ihr Investor",
            "An die Hand nehmen",
            "Sie sind mir sympathisch",
            "Dümmel kauft 2x hintereinander",
            "Essbares Produkts ist vegan",
            "Nische",
            "25,1%",
            "Unter 50.000€ Umsatz",
            "Ein Löwe testet",
            "Models stellen vor"
        };
    }


public class initializeButtons : MonoBehaviour {
    public static readonly int BOARD_SIZE = 9;
    public GameObject MainPanel;
    public GameObject BingoPanel;
    public InputField iP;
    public Button buttonPrefab;
    public Transform panel;
    public Dictionary<Button, int> clickedButtons = new Dictionary<Button,int>();
    Color defaultColor;
    public List<Button> playerButtons;
    private bool initialized = false;
	public bool gameWon = false;
	public GameObject FireworksPanel;
	public GameObject Explosion;
	private float timeLeft = 2.0f;




    // Use this for initialization
    public void Start()
    {
        int randomName = Random.Range(0, ListContainer.nameList.Count);
        iP.text = ListContainer.nameList[randomName];
        int n = ListContainer.bingoList.Count;
        defaultColor = buttonPrefab.GetComponent<Image>().color;
        List<string> copyList = new List<string>(ListContainer.bingoList);
        while (n > 1)
        {
            int k = (Random.Range(0, n) % n);
            n--;
            string value = copyList[k];
            copyList[k] = copyList[n];
            copyList[n] = value;


        }
        Initialize(copyList);
    }

	public void ShowTextOnButton(){
		for(int i = 0; i < BOARD_SIZE; i++){
			playerButtons [i].GetComponentInChildren<Text> ().enabled = true;
		}
	}


	void Initialize (List<string> copyList) {
        playerButtons = new List<Button>();

        for (int i = 0; i < BOARD_SIZE; i++)
        {
            Debug.Log("button " + i + " has text " + copyList[i]);
            Button button = Instantiate(buttonPrefab);
			button.GetComponentInChildren<Text> ().text = copyList[i];
            button.GetComponentInChildren<Text>().resizeTextForBestFit = true;
			button.GetComponentInChildren<Text> ().enabled = false;
			button.transform.SetParent(BingoPanel.transform);
			button.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
            button.onClick.AddListener(() => { TaskOnClick(button); });

            playerButtons.Add(button);
            clickedButtons.Add(button, 0);
        }
        //unlock
        initialized = true;
    }

	void GameWonProcedure(){
		gameWon = true;
	//	BingoPanel.SetActive (false);
		//Transform left = FireworksPanel.GetComponentInChildren<Transform>();
		//Transform right = FireworksPanel.GetComponentInChildren("FireworkRight").transform;
	//	RectTransform rect = GetComponent<RectTransform>() as RectTransform;
		foreach (Transform child in FireworksPanel.transform){
			if (child.gameObject.name.Equals ("FireworkRight")) {
				child.localPosition = new Vector3 (Screen.width/2, -Screen.height/2, child.position.z);
			} else if (child.gameObject.name.Equals ("FireworkLeft")) {
				child.localPosition = new Vector3 (-Screen.width/2, -Screen.height/2, child.position.z);
			}
	//		Debug.Log (Screen.width);
		}
			
		FireworksPanel.SetActive (true);
		return;
	}

	void CheckForWin(){
		for(int idx = 0; idx < 3; idx++){
			int sum = 0;
			//check columns
			for (int i = 0; i < 9; i+=3) {
				sum += clickedButtons [playerButtons [i + idx]];
			}
			if (sum == 3) {
				GameWonProcedure ();
			}
			sum = 0;
			//check rows
			for (int i = 0; i < 3; i++) {
				sum += clickedButtons [playerButtons [i + 3 * idx]];
			}
			if (sum == 3) {
				GameWonProcedure ();
			}
		}
		//check diagonals
		if (clickedButtons [playerButtons [0]] + clickedButtons [playerButtons [4]] + clickedButtons [playerButtons [8]] == 3
		    || clickedButtons [playerButtons [2]] + clickedButtons [playerButtons [4]] + clickedButtons [playerButtons [6]] == 3) {
			GameWonProcedure ();
		}

	}

    void Rename()
    {
        for(int i = 0; i < 9; i++)
        {
            Button b = playerButtons[i];
            b.GetComponentInChildren<Text>().text = ListContainer.bingoList[i];
        }
    }

    void TaskOnClick(Button b)
    {
		
        if (clickedButtons[b] == 0)
        {
            clickedButtons[b] = 1;
        }
        else
        {
            clickedButtons[b] = 0;
			if (gameWon) {
				gameWon = false;

			}
        }
    }

    public void SavePlayerProfile()
    {
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            int idx = -1;
            // find the index of each button, idx is the index in ListContainer.bingoList
            for(int j = 0; j < ListContainer.bingoList.Count; j++)
            {
                if (ListContainer.bingoList[j].Equals(playerButtons[i].GetComponentInChildren<Text>().text)){
                    idx = j;
                    break;
                }
            }
            //should not happen!
            if(idx == -1)
            {
                Debug.Log("idx -1, theres something wrong!");
            }
            //save the buttons
            PlayerPrefs.SetInt(iP.text + i, idx);
            Debug.Log(PlayerPrefs.GetString(iP.text + i));

            //save which button has been pressed
            Button b = playerButtons[i];
            PlayerPrefs.SetInt(iP.text + i + "pressed",clickedButtons[b]);
        }
        PlayerPrefs.Save();

        //set load button caption to "load"
        var mainPanel = GameObject.Find("MainPanel");
        var x = (LoadButtonCaptionHandler)mainPanel.GetComponent(typeof(LoadButtonCaptionHandler));
        x.ValueChanged();
    }

    public void ReInit()
    {

        clickedButtons=new Dictionary<Button, int>();
        int randomName = Random.Range(0, ListContainer.nameList.Count);
        iP.text = ListContainer.nameList[randomName];
        int n = ListContainer.bingoList.Count;
        defaultColor = buttonPrefab.GetComponent<Image>().color;
        List<string> copyList = new List<string>(ListContainer.bingoList);
        while (n > 1)
        {
            int k = (Random.Range(0, n) % n);
            n--;
            string value = copyList[k];
            copyList[k] = copyList[n];
            copyList[n] = value;


        }
        for(int i = 0; i < BOARD_SIZE; i++)
        {
            Button b = playerButtons[i];
            b.GetComponentInChildren<Text>().text = copyList[i];
			b.GetComponentInChildren<Text> ().enabled = false;
            clickedButtons[b] = 0;
        }
		// reset time on ButtonTextAnimation (for "fancy" fade-in animation)
		var script = GameObject.Find("BingoPanel").GetComponent(typeof(ButtonTextAnimation)) as ButtonTextAnimation;
		script.Restart ();
        initialized = true;
    }

    public void LoadPlayerProfile()
    {
        if (PlayerPrefs.HasKey(iP.text + "0"))
        {
			//deactivate explostion on loading
			Explosion.SetActive(false);
            for (int i = 0; i < BOARD_SIZE; i++)
            {
            // load index in ListContainer.bingoList

                int idx = PlayerPrefs.GetInt(iP.text + i);
                Debug.Log("index: " + idx);

                Button b = playerButtons[i];
                Text caption = b.GetComponentInChildren<Text>();
                caption.text = ListContainer.bingoList[idx];
                int clicked = PlayerPrefs.GetInt(iP.text + i + "pressed");
                clickedButtons[b] = clicked;
            }
            return;
        }
        // lock
        initialized = false;
		//activate explosion for new game
		Explosion.SetActive(true);
		//reset gameWon flag (no game is one (yet))
		gameWon = false;
        Debug.Log("no savegame found! Starting new game");
        ReInit();
    }

	public void RevokeFireworks(){
		FireworksPanel.SetActive (false);
	}



    // Update is called once per frame
    void Update()
    {
		if (initialized)
        {
            // check for each button if pressed
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                Button b = playerButtons[i];
                if (clickedButtons[b]==1)
                    b.GetComponent<Image>().color = Color.green;
                else
                    b.GetComponent<Image>().color = defaultColor;
            }
        }
		if (!gameWon) {
			CheckForWin ();
		}

    }
}
