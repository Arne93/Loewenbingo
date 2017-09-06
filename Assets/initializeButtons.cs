using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        public static List<string> bingoList = new List<string> { "Löwe erzählt aus seinem Leben", "Löwen investieren als Team", "Gründer weint", "Altes Produkt wird gezeigt", "Backstage-Mitarbeiter ist unangenehm", "Aus dem Grund bin ich raus", "Es ist nicht Franks Welt/DNA", "Marge zu gering", "Produkt hat gute Qualität", "Produkt hat Potenzial", "Ich bin Ihr Kunde, aber nicht ihr Investor", "An die Hand nehmen", "Sie sind mir sympathisch", "Dümmel kauft 2x hintereinander", "Essbares Produkts ist vegan", "Nische", "25,1%", "Unter 50.000€ Umsatz", "Ein Löwe testet", "Models stellen vor" };
    }



public class initializeButtons : MonoBehaviour {
    public GameObject MainPanel;
    public GameObject BingoPanel;
    public InputField iP;
    public Button buttonPrefab;
    public Transform panel;
    //bool isButtonClicked = false;
    public Dictionary<Button, bool> clickedButtons = new Dictionary<Button,bool>();
    Color defaultColor;
    //public List<string> bingoList;// new List<string> {"Löwe erzählt aus seinem Leben","Löwen investieren als Team","Gründer weint","Altes Produkt wird gezeigt","Backstage-Mitarbeiter ist unangenehm","Aus dem Grund bin ich raus","Es ist nicht Franks Welt/DNA","Marge zu gering","Produkt hat gute Qualität", "Produkt hat Potenzial","Ich bin Ihr Kunde, aber nicht ihr Investor", "An die Hand nehmen", "Sie sind mir sympathisch", "Dümmel kauft 2x hintereinander", "Essbares Produkts ist vegan", "Nische", "25,1%", "Unter 50.000€ Umsatz", "Ein Löwe testet", "Models stellen vor" };
    public static List<Button> buttonList = new List<Button>();
   // public List<string> nameList; 
    public static bool reInit = false;




    // Use this for initialization
    public void Start()
    {
        //nameList = ListContainer.nameList;
        //bingoList = ListContainer.bingoList;
        int randomName = Random.Range(0, ListContainer.nameList.Count);
        iP.text = ListContainer.nameList[randomName];
        int n = ListContainer.bingoList.Count;
        defaultColor = buttonPrefab.GetComponent<Image>().color;
        while (n > 1)
        {
            int k = (Random.Range(0, n) % n);
            n--;
            string value = ListContainer.bingoList[k];
            ListContainer.bingoList[k] = ListContainer.bingoList[n];
            ListContainer.bingoList[n] = value;

            
        }
        Initialize();
    }
	
	
	void Initialize () {
        for (int i = 0; i < 9; i++)
        {
            Debug.Log("button " + i + " has text " + ListContainer.bingoList[i]);
            Button button = Instantiate(buttonPrefab);
            button.GetComponentInChildren<Text>().text = ListContainer.bingoList[i];
            button.GetComponentInChildren<Text>().resizeTextForBestFit = true;
            button.transform.parent = panel;
            button.onClick.AddListener(() => { TaskOnClick(button); });

            buttonList.Add(button);
            clickedButtons.Add(button, false);
        }
    }

    void rename()
    {
        for(int i = 0; i < 9; i++)
        {
            Button b = (Button)buttonList[i];
            b.GetComponentInChildren<Text>().text = ListContainer.bingoList[i];
        }
    }

    void TaskOnClick(Button b)
    {

        if (!clickedButtons[b])
        {
            b.GetComponent<Image>().color = Color.green;
            clickedButtons[b] = true;
        }
        else
        {
            b.GetComponent<Image>().color = defaultColor;
            clickedButtons[b] = false;
        }
    }

    public void SavePlayerProfile()
    {
        for (int i = 0; i < ListContainer.bingoList.Count; i++)
        {
            PlayerPrefs.SetString(iP.text + i, ListContainer.bingoList[i]); //key: ipText0-i, value: copy[i]
            Debug.Log(PlayerPrefs.GetString(iP.text + i));
        }
        PlayerPrefs.Save(); 
    }


   
    // Update is called once per frame
    void Update()
    {
        if (reInit)
        {
            rename();
            reInit = false;
        }
    }
}
