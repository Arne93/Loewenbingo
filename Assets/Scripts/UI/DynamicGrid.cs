using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DynamicGrid : MonoBehaviour
{
	public GameObject Canvas;
    public GameObject MainPanel;
    public GameObject BingoPanel;
	public GameObject FireworksPanel;

    public int col, row;


    //private Random rng = new Random();


    // Use this for initialization
    void Start()
    {


       // RectTransform parent = gameObject.GetComponent<RectTransform>();
       // GridLayoutGroup grid = gameObject.GetComponent<GridLayoutGroup>();
		GridLayoutGroup grid = BingoPanel.GetComponent<GridLayoutGroup> ();
		RectTransform parent = Canvas.GetComponent<RectTransform> ();
		//Debug.Log (parent.transform.localScale);
		//Debug.Log (parent.rect.width / col);

	//	grid.cellSize = new Vector2(parent.rect.width / col, parent.rect.height / row);
		grid.cellSize = new Vector2(Screen.width/(float)col, Screen.height/(float)row);
	//	grid.cellSize = new Vector2(10.333f,10.333f);


        //initialize the buttons

    }






    // Update is called once per frame
    void Update()
    {
		
		/* needed if the screen aspect ratio changes, should not happen normally. (poor garbage collection) */
//		GridLayoutGroup grid = BingoPanel.GetComponent<GridLayoutGroup> ();
//		grid.cellSize = new Vector2(Screen.width/(float)col, Screen.height/(float)row);
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                MainPanel.SetActive(true);
                BingoPanel.SetActive(false);
				FireworksPanel.SetActive (false);
                // set load button caption
                var mainPanel = GameObject.Find("MainPanel");
                var x = (LoadButtonCaptionHandler)mainPanel.GetComponent(typeof(LoadButtonCaptionHandler));
                x.ValueChanged();
                return;
            }
        }

        if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.LinuxPlayer 
			|| Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.LinuxEditor 
			|| Application.platform == RuntimePlatform.LinuxPlayer)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

                MainPanel.SetActive(true);
                BingoPanel.SetActive(false);
				FireworksPanel.SetActive(false);
                // set load button caption
                var mainPanel = GameObject.Find("MainPanel");
                var x = (LoadButtonCaptionHandler)mainPanel.GetComponent(typeof(LoadButtonCaptionHandler));
                x.ValueChanged();
                return;
            }
        }


    }
}
