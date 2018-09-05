using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using System.Runtime.Remoting.Channels;

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
            "Berwertung zu hoch",
            "Ich als ..., weiß was harte Arbeit ist",
            "Was ist euer USP?",
            "Ich hab Bock das mit euch groß zu machen"

        };
    }


public class initializeButtons : MonoBehaviour {
    public GameObject MainPanel;
    public GameObject BingoPanel;
    public InputField iP;
    public Button buttonPrefab;
    public Transform panel;
    public Dictionary<Button, Field> buttonField = new Dictionary<Button, Field>();
    Color defaultColor;
    public List<Button> playerButtons;
    private bool initialized = false;
    public bool gameWon = false;
    public GameObject FireworksPanel;
    public GameObject Explosion;
    public LoadButtonCaptionHandler captionHandler;
    public ButtonTextAnimation textAnim;



    // Use this for initialization
    public void Start() {
        int randomName = Random.Range(0, ListContainer.nameList.Count);
        iP.text = ListContainer.nameList[randomName];
        defaultColor = buttonPrefab.GetComponent<Image>().color;
        
    }

    public void OnEnable() {
    }

    public void ShowTextOnButton() {
        for (int i = 0; i < GameController.BOARD_SIZE; i++) {
            playerButtons[i].GetComponentInChildren<Text>().enabled = true;
        }
    }


    void Initialize(List<string> copyList) {
        foreach(var b in playerButtons) {
            b.gameObject.SetActive(false);
            Destroy(b.gameObject);
        }
        playerButtons.Clear();
        string[] names = new string[GameController.BOARD_SIZE];
        bool[] check = new bool[GameController.BOARD_SIZE];
        for (int i = 0; i < GameController.BOARD_SIZE; i++) {

            Button button = Instantiate(buttonPrefab);
            button.GetComponentInChildren<Text>().text = copyList[i];
            button.GetComponentInChildren<Text>().resizeTextForBestFit = true;
            button.GetComponentInChildren<Text>().enabled = false;
            button.transform.SetParent(BingoPanel.transform);
            button.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            button.onClick.AddListener(() => { TaskOnClick(button); });

            playerButtons.Add(button);
            check[i] = false;
            names[i] = copyList[i];
        }
        GameController.Instance.currentBoard = new Board(iP.text, names, check);
        for (int i = 0; i < GameController.BOARD_SIZE; i++) {
            buttonField.Add(playerButtons[i], GameController.Instance.currentBoard.fields[i]);
        }
        initialized = true;
        textAnim.Restart();
    }

    void GameWonProcedure() {
        gameWon = true;
        foreach (Transform child in FireworksPanel.transform) {
            if (child.gameObject.name.Equals("FireworkRight")) {
                child.localPosition = new Vector3(Screen.width / 2, -Screen.height / 2, child.position.z);
            } else if (child.gameObject.name.Equals("FireworkLeft")) {
                child.localPosition = new Vector3(-Screen.width / 2, -Screen.height / 2, child.position.z);
            }
            //		Debug.Log (Screen.width);
        }

        FireworksPanel.SetActive(true);
        return;
    }

    void CheckForWin() {
        for (int idx = 0; idx < 3; idx++) {
            int sum = 0;
            //check columns
            for (int i = 0; i < 9; i += 3) {
                sum += buttonField[playerButtons[i + idx]].check ? 1 : 0;
            }
            if (sum == 3) {
                GameWonProcedure();
            }
            sum = 0;
            //check rows
            for (int i = 0; i < 3; i++) {
                sum += buttonField[playerButtons[i + 3 * idx]].check ? 1 : 0;
            }
            if (sum == 3) {
                GameWonProcedure();
            }
        }
        //check diagonals
        if (buttonField[playerButtons[0]].check && buttonField[playerButtons[4]].check && buttonField[playerButtons[8]].check
            || buttonField[playerButtons[2]].check && buttonField[playerButtons[4]].check && buttonField[playerButtons[6]].check) {
            GameWonProcedure();
        }

    }

    void Rename() {
        for (int i = 0; i < 9; i++) {
            Button b = playerButtons[i];
            b.GetComponentInChildren<Text>().text = ListContainer.bingoList[i];
        }
    }

    void TaskOnClick(Button b) {


        if (!buttonField[b].check) {
            buttonField[b].check = true;
            b.GetComponent<Image>().color = Color.green;
            CheckForWin();
        } else {
            buttonField[b].check = false;
            if (gameWon) {
                gameWon = false;
            }
            b.GetComponent<Image>().color = defaultColor;
        }
        SavePlayerProfile();
    }

    public void SavePlayerProfile() {
        GameController.Instance.SaveBoard();

        //set load button caption to "load"
        captionHandler.ValueChanged();
    }

    private void ButtonsFromBoard() {
        Board board = GameController.Instance.currentBoard;
        for (int i = 0; i < GameController.BOARD_SIZE; i++) {
            Button b = playerButtons[i];
            Field field = board.fields[i];
            FieldToButton(field, b);
        }
    }

    public void LoadPlayerProfile() {
        if (PlayerPrefs.HasKey(iP.text + "0")) {
            //deactivate explostion on loading
            Explosion.SetActive(false);
            GameController.Instance.LoadBoard(iP.text);
            ButtonsFromBoard();
            return;
        }
        Explosion.SetActive(true);
        gameWon = false;
        List<string> copyList = new List<string>(ListContainer.bingoList);

        int n = ListContainer.bingoList.Count;
        while (n > 1) {
            int k = (Random.Range(0, n) % n);
            n--;
            string value = copyList[k];
            copyList[k] = copyList[n];
            copyList[n] = value;


        }
        Initialize(copyList);
    }

    public void RevokeFireworks() {
        FireworksPanel.SetActive(false);
    }

    private void InitFromBoard() {
        Board board = GameController.Instance.currentBoard;
        var fields = board.fields;
        for (int i = 0; i < GameController.BOARD_SIZE; i++) {
            Field field = fields[i];
            FieldToButton(field, playerButtons[i]);
        }
    }

    public void FieldToButton(Field field, Button button) {
        button.GetComponent<Text>().text = field.text;
        button.GetComponent<Image>().color = field.check ? Color.green : defaultColor;
    }

}
