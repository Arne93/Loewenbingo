using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static readonly int BOARD_SIZE = 9;
    public GameObject menu;
    public GameObject game;
    public Board currentBoard = null;
    private static GameController gameController = null;

    private GameController() {

    }

    public static GameController Instance {
        get {
            if (gameController == null)
                gameController = new GameController();
            return gameController;
        }
    }

    public bool isRunning;

    public void SetRunning(bool running) {
        isRunning = running;
    }

    private void Awake() {
        DontDestroyOnLoad(this);
        gameController = this;
    }

    public void LoadBoard(string name) {
        string[] names = new string[BOARD_SIZE];
        bool[] check = new bool[BOARD_SIZE];
        for (int i = 0; i < BOARD_SIZE; i++) {
            // load index in ListContainer.bingoList

            //int idx = PlayerPrefs.GetInt(name);
            //Debug.Log("index: " + idx);
            names[i] = PlayerPrefs.GetString(name + i);
            //Button b = playerButtons[i];
            //Text caption = b.GetComponentInChildren<Text>();
            //caption.text = ListContainer.bingoList[idx];
            int clicked = PlayerPrefs.GetInt(name + i + "pressed");
            check[i] = clicked == 1;
        }
        currentBoard = new Board(name, names, check);
    }

    public void SaveBoard() {
        if (currentBoard == null)
            return;
        string name = currentBoard.name;
        for (int i = 0; i < BOARD_SIZE; i++) {
            Field field = currentBoard.fields[i];
            //save the buttons
            PlayerPrefs.SetString(name + i, field.text);
          //  Debug.Log(name + i + ",   " + field.text);
            //save which button has been pressed
            PlayerPrefs.SetInt(name + i + "pressed", field.check ? 1 : 0);
        }
        PlayerPrefs.Save();
    }
}

