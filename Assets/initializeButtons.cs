using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class ListContainer
    {
        public static List<string> nameList = new List<string> {
"Fynn",
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
    public static List<string> bingoList = new List<string> {
            "Löwe erzählt aus seinem Leben",
            "Löwen investieren als Team",
            "Gründer weint",
            "Altes Produkt wird gezeigt",
            "Backstage-Mitarbeiter ist unangenehm",
            "Aus den genannten Gründen bin ich raus",
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
            "Models stellen vor",
            "Gründer sind Familienunternehmen",
            "Bewertung zu hoch",
            "Ich als ..., weiß was harte Arbeit ist"

        };
    }


public class initializeButtons : MonoBehaviour {
    public static readonly int BOARD_SIZE = 9;
    public GameObject MainPanel;
    public GameObject BingoPanel;
    public InputField iP;
    public Button buttonPrefab;
    public Transform panel;
    public Dictionary<Button, bool> clickedButtons = new Dictionary<Button,bool>();
    Color defaultColor;
    public List<Button> playerButtons;
    private bool initialized = false;




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
	
	
	void Initialize (List<string> copyList) {
        playerButtons = new List<Button>();
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            Debug.Log("button " + i + " has text " + copyList[i]);
            Button button = Instantiate(buttonPrefab);
            button.GetComponentInChildren<Text>().text = copyList[i];
            button.GetComponentInChildren<Text>().resizeTextForBestFit = true;
            button.transform.parent = panel;
            button.onClick.AddListener(() => { TaskOnClick(button); });

            playerButtons.Add(button);
            clickedButtons.Add(button, false);
        }
        //unlock
        initialized = true;
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

        if (!clickedButtons[b])
        {
            clickedButtons[b] = true;
        }
        else
        {
            clickedButtons[b] = false;
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
            PlayerPrefs.SetInt(iP.text + i + "pressed", System.Convert.ToInt32(clickedButtons[b]));
        }
        PlayerPrefs.Save();

        //set load button caption to "load"
        var mainPanel = GameObject.Find("MainPanel");
        var x = (LoadButtonCaptionHandler)mainPanel.GetComponent(typeof(LoadButtonCaptionHandler));
        x.ValueChanged();
    }

    public void ReInit()
    {
        
        clickedButtons=new Dictionary<Button, bool>();
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
            clickedButtons[b] = false;
        }
        initialized = true;
    }

    public void LoadPlayerProfile()
    {
        if (PlayerPrefs.HasKey(iP.text + "0")) 
        {
            for (int i = 0; i < BOARD_SIZE; i++) 
            {
            // load index in ListContainer.bingoLis
          
                int idx = PlayerPrefs.GetInt(iP.text + i);
                Debug.Log("index: " + idx);

                Button b = playerButtons[i];
                Text caption = b.GetComponentInChildren<Text>();
                caption.text = ListContainer.bingoList[idx];
                int clicked = PlayerPrefs.GetInt(iP.text + i + "pressed");
                clickedButtons[b] = clicked == 0 ? false : true;
            }
            return;
        }
        // lock
        initialized = false;
        Debug.Log("no savegame found! Starting new game");
        ReInit();
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
                if (clickedButtons[b])
                    b.GetComponent<Image>().color = Color.green;
                else
                    b.GetComponent<Image>().color = defaultColor;
            }
        }
    }
}
