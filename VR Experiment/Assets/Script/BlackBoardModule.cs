using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoardModule : MonoBehaviour
{
    public GameObject[] boardContent;
    GameObject previousBoard;
    int content_stage = 0;

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

        if (content_stage == 1)
        {
            //then loop around different object ...
        }




        previousBoard = boardContent[content_stage];


    }
   
}
