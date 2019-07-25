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
                responseText.GetComponent<TextMesh>().text = "";
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
                myBattery.GetComponent<Battery>().flipBattery();

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
                Material m_Btn_mat = rend.material;
                m_Btn_mat.color = Color.red;
                
            }
            else
            {
                //get what was clicked on ...
                BlackBoardModule.getInstance().clickOnWhichCompoent(this.gameObject);

                //set color to green ...
                Renderer rend = GetComponent<Renderer>();
                Material m_Btn_mat = rend.material;
                m_Btn_mat.color = Color.green;


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

        if (BlackBoardModule.getInstance().content_stage == 7)
        {
            responseText.SetActive(true);
            
            Debug.Log("Stage 7 actions we go we go");
            if (this.gameObject.name == "terminal_wrong_q8")
            {
                Debug.Log("First option correct?");
                responseText.GetComponent<TextMesh>().text = "Correct, a battery will provide \nthe current required to power \nthe circuit";
            }
            else
            if (this.gameObject.name == "wrong_battery_q8")
            {
                responseText.GetComponent<TextMesh>().text = "Incorrect, a 3 volts battery generates \nenough electricity to light up \na 2 volts bulb";
            }
            else
            if (this.gameObject.name == "switch_off_q8")
            {
                responseText.GetComponent<TextMesh>().text = "Incorrect, remember you turned on \nthe switch to activate the circuit.";
            }
        }

        if (BlackBoardModule.getInstance().content_stage == 8)
        {
            responseText.SetActive(true);
            
            if (this.gameObject.name == "blue_button_press_q9")
            {
                responseText.GetComponent<TextMesh>().text = "Correct, flipping the terminal \nwill allow the current flow";
            }
            else
           if (this.gameObject.name == "removing_battery_q9")
            {
                responseText.GetComponent<TextMesh>().text = "Incorrect, that will remove the \nsource of electrical energy";
            }
            else
           if (this.gameObject.name == "turn_off_switch_q9")
            {
                responseText.GetComponent<TextMesh>().text = "Incorrect, turning off the switch\n will prevent current from flowing \nin the circuit";
            }

        }
        
        


            

    }

}
