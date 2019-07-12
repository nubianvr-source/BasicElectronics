using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    //public string button_name;

    ElectricalCircuitBuildingModule electricalCircuitModule;
    public void actionPerformedClick()
    {

        if ((this.gameObject.name == "btn_resistor_q1")
            ||
           (this.gameObject.name == "btn_battery_q1")){

            //set color red else set color to green

        }
        else
        {
            //set color to green ..
        }
        

        
        //electricalCircuitModule = ElectricalCircuitBuildingModule.getInstance();
        

        
        //electricalCircuitModule.callCircuitDone();

    }

}
