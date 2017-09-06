using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initializeButtons : MonoBehaviour {
    public GameObject MainPanel;
    public GameObject BingoPanel;
    public InputField iP;
    public Button buttonPrefab;
    public Transform panel;
    bool isButtonClicked = false;
    Color defaultColor;
    public static List<string> bingoList = new List<string> {"Löwe erzählt aus seinem Leben","Löwen investieren als Team","Gründer weint","Altes Produkt wird gezeigt","Backstage-Mitarbeiter ist unangenehm","Aus dem Grund bin ich raus","Es ist nicht Franks Welt/DNA","Marge zu gering","Produkt hat gute Qualität", "Produkt hat Potenzial","Ich bin Ihr Kunde, aber nicht ihr Investor", "An die Hand nehmen", "Sie sind mir sympathisch", "Dümmel kauft 2x hintereinander", "Essbares Produkts ist vegan", "Nische", "25,1%", "Unter 50.000€ Umsatz", "Ein Löwe testet", "Models stellen vor" };
    public static ArrayList buttonList = new ArrayList();
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
    public static bool reInit = false;




    // Use this for initialization
    void Start()
    {
        int randomName = Random.Range(0, nameList.Count);
        iP.text = nameList[randomName];
        int n = bingoList.Count;
        defaultColor = buttonPrefab.GetComponent<Image>().color;
        while (n > 1)
        {
            int k = (Random.Range(0, n) % n);
            n--;
            string value = bingoList[k];
            bingoList[k] = bingoList[n];
            bingoList[n] = value;

            
        }
        Initialize(buttonList);
    }
	
	// Update is called once per frame
	void Initialize (ArrayList l) {
        for (int i = 0; i < 9; i++)
        {
            Button button = Instantiate(buttonPrefab);
            button.GetComponentInChildren<Text>().text = bingoList[i];
            button.GetComponentInChildren<Text>().resizeTextForBestFit = true;
            button.transform.parent = panel;
            button.onClick.AddListener(() => { TaskOnClick(button); });
            l.Add(button);
        }
    }

    void rename()
    {
        for(int i = 0; i < 9; i++)
        {
            Button b = (Button)buttonList[i];
            b.GetComponentInChildren<Text>().text = bingoList[i];
        }
    }

    void TaskOnClick(Button b)
    {
        if (!isButtonClicked)
        {
            b.GetComponent<Image>().color = Color.green;
            isButtonClicked = true;
        }
        else
        {
            b.GetComponent<Image>().color = defaultColor;
            isButtonClicked = false;
        }
    }

    void Update()
    {
        if (reInit)
        {
            rename();
            reInit = false;
        }
    }
}
