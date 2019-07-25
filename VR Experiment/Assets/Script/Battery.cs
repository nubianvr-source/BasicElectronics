using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void actionPerformedOnClick()
    {
        Debug.Log("content stage " + BlackBoardModule.getInstance().content_stage);
        if (BlackBoardModule.getInstance().content_stage == 5)
        {
            //the ring around that guy  and a click on that board brings the battery ...
            GameObject ringSelector = GameObject.Find("RingSelector");
            ringSelector.GetComponent<Renderer>().enabled = true;

            //this.componentActiveState = ComponentActiveStates.active;

        }
    }

    public void moveToPosition()
    {
        ///move the battery to the board ...
        transform.position = ElectricalCircuitBuildingModule.getInstance().activePositions[0].position;
        transform.rotation = ElectricalCircuitBuildingModule.getInstance().activePositions[0].rotation;

        GameObject ringSelector = GameObject.Find("RingSelector");
        ringSelector.GetComponent<Renderer>().enabled = false;

    }

    float zAxis = 180f;
    public void flipBattery()
    {
        //flip only if battery is active ...
        Debug.Log("flip this ...");
        
        zAxis = -zAxis;
        transform.Rotate(0f, 0f, zAxis, Space.Self);

        Debug.Log("Current rotation values\n x-" + transform.localRotation.x + " y- " + transform.localRotation.y + " z- " + transform.localRotation.z);

    }
    
}
