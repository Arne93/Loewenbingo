using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DynamicGrid : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject BingoPanel;

    public int col, row;
    

    //private Random rng = new Random();
   
    
    // Use this for initialization
    void Start()
    {
       

        RectTransform parent = gameObject.GetComponent<RectTransform>();
        GridLayoutGroup grid = gameObject.GetComponent<GridLayoutGroup>();

        grid.cellSize = new Vector2(parent.rect.width / col, parent.rect.height / row);

        //initialize the buttons
        
        
        

        
    }

   


    

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                MainPanel.SetActive(true);
                BingoPanel.SetActive(false);
                //save bingo fields
                return;
            }
        }
        
        if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                MainPanel.SetActive(true);
                BingoPanel.SetActive(false);
                return;
            }
        }


    }
}
