using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    //public string button_name;
    public GameObject responseText;

    ElectricalCircuitBuildingModule electricalCircuitModule;
    public void actionPerformedClick()
    {
        string buttonName = this.gameObject.name;
        switch (buttonName)
        {
            case "ClickForNext":
                
                responseText.SetActive(false);

                BlackBoardModule bbm = BlackBoardModule.getInstance();
                bbm.nextDemo();
                
                break;

            case "ToggleSwitch":
                //switch clicked on ...
                //find the switch in the scene ...
                GameObject lightswitch = GameObject.Find(ElectricalCircuitBuildingModule.LIGHTSWITCH+"(Clone)");
                lightswitch.GetComponent<LightSwitch>().onSwitchToggle();

                break;

            case "flip_battery":

                GameObject myBattery = GameObject.Find(ElectricalCircuitBuildingModule.BATTERY + "(Clone)");
                Debug.Log("Yet to flip this guy ...");
                break;

            case "flip_diode":

                //get the diode likewise ...

                break;

            default:
                break;
        }

        if (BlackBoardModule.getInstance().content_stage == 0)
        {
            if ((this.gameObject.name == "btn_resistor_q1")
            ||
           (this.gameObject.name == "btn_battery_q1"))
            {

                Renderer rend = GetComponent<Renderer>();

                //Set the main Color of the Material to red
                rend.material.shader = Shader.Find("_Color");
                rend.material.SetColor("_Color", Color.red);

            }
            else
            {
                //set color to green ...
                Renderer rend = GetComponent<Renderer>();

                //Set the main Color of the Material to green
                rend.material.shader = Shader.Find("_Color");
                rend.material.SetColor("_Color", Color.green);
                

            }
        }

        Debug.Log("content stage ... "+BlackBoardModule.getInstance().content_stage);
        if (BlackBoardModule.getInstance().content_stage == 2)
        {
            //GameObject responseText = GameObject.Find("response_text");
            responseText.SetActive(true);
            Debug.Log("Do you get here ...");
            if (this.gameObject.name == "add_battery_q3")
            {
                responseText.GetComponent<TextMesh>().text = "Correct, a battery will \nprovide the current required \nto power the circuit";
            }else 

            if (this.gameObject.name == "add_resistor_q3")
            {
                responseText.GetComponent<TextMesh>().text = "Incorrect, a resistor is \nused to reduce the current \nflow in a circuit";
            }else

            if (this.gameObject.name == "add_capacitor_q3")
            {
                responseText.GetComponent<TextMesh>().text = "Incorrect, a capacitor is \nused to store current flow \nin a circuit";
            }
            else
            {
                //responseText.GetComponent<TextMesh>().text = "Incorrect!";
            }

        }
        
        


            

    }

}
