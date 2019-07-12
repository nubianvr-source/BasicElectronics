using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoardModule : MonoBehaviour
{
    public GameObject[] boardContent;
    string[] componentsOnTable = { "Diode", "Switch", "2V Bulb" };
    public string currentResponseExpected = "";
    GameObject previousBoard;
    public int content_stage = 0;

    public static BlackBoardModule instance;

    public static BlackBoardModule getInstance()
    {
        if (instance == null)
        {
            return new BlackBoardModule();
        }
        else
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    //In the beginning, everything is inactive ...
    // Start is called before the first frame update
    void Start()
    {
        boardContent[content_stage].SetActive(true);
        previousBoard = boardContent[content_stage];
        
    }

    public void nextDemo()
    {
        content_stage++;
        previousBoard.SetActive(false);
        boardContent[content_stage].SetActive(true);

        //the stage where you loop to put all items on table ...
        if (content_stage == 1)
        {
            string textmeshtext = "Point to the " + componentsOnTable[0] + " in the circuit";
            boardContent[1].GetComponentInChildren<TextMesh>().text = textmeshtext;

            textmeshtext = "Point to the " + componentsOnTable[1] + " in the circuit";
            textmeshtext = "Point to the " + componentsOnTable[2] + " in the circuit";
        }


        if (content_stage == 4)
        {
            //put rings around the active positions ...
            //Transform batterypos, switchPos, diodePoc, bulb;
            //batterypos = GameObject.Find("BatteryActive_pos").transform;

            //at this point ... 
            

        }
        
        previousBoard = boardContent[content_stage];


    }
   
}
