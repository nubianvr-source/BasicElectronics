using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalCircuitBuildingModule : MonoBehaviour
{
    public ElectricalComponent[] electricalComponents;
    public Transform[] inactivePosition;
    public Transform[] activePositions;
    public Transform circuitPath;
    public static int demonstration_level = 0;
    public TextMesh textInfo;
    ElectricalComponent electricalComponent;

    public GameObject circuitFlowVisuals;

    public enum CircuitState
    {
        active,
        inactive
    }

    public CircuitState circuitState = CircuitState.inactive;

    private static ElectricalCircuitBuildingModule instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //start the distin ...
        //DEMOSTRATION 1
        //Show only one battery and the position to put the battery
        demonstration_level = 1;
        textInfo.text = "Demonstration "+ demonstration_level;
        electricalComponent = Instantiate(electricalComponents[0], inactivePosition[0].transform.position, Quaternion.identity);
        electricalComponent.componentState = ElectricalComponent.ComponentState.inactive;

        electricalComponent.activeTransform = activePositions[0];
        electricalComponent.gameObject.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (circuitState == CircuitState.active)
        {
            //move the trail renderer on the path ...
        }
    }

    public void changeWireColorBasedOnSwitch(LightSwitch.SwitchState switchState)
    {

        if (wireLineRenderer != null)
        {
            Color c1 = Color.green;
            Color c2 = Color.red;
            if (switchState == LightSwitch.SwitchState.on)
            {
                Debug.Log("Wire is active!!!");
                circuitState = CircuitState.active;
                wireLineRenderer.startColor = c1;
                wireLineRenderer.endColor = c1;
                //turnLED_On();
            }
            else
            {
                Debug.Log("Wire is Inactive");
                circuitState = CircuitState.inactive;
                wireLineRenderer.startColor = c2;
                wireLineRenderer.endColor = c2;
                //turnLED_Off();
            }

            getInstance().turnLEDOnOff();

        }
    }

    public void turnLEDOnOff()
    {
        Debug.Log("Turn the lights On or Off");
        //if the lamp is active ...
        if (electricalComponents[3].componentState == ElectricalComponent.ComponentState.active)
        {
            electricalComponents[3].gameObject.GetComponentInChildren<LightBulb>().turnOnOff();
        }

    }

    //public void turnLED_On()
    //{
    //    //check if light LED is active or not before you light up or not
    //}

    //public void turnLED_Off()
    //{
    //    //check if light LED is active or not before you light up or not
    //}

    LineRenderer wireLineRenderer;
    public void createWireLoop()
    {
        if (demonstration_level == 2)
        {
            if (electricalComponent1 == null)
            {
                return;
            }
        }

        Color c1 = Color.red;
        Color c2 = Color.red;

        wireLineRenderer = gameObject.AddComponent<LineRenderer>();
        wireLineRenderer.loop = true;
        wireLineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        wireLineRenderer.startColor = c1;
        wireLineRenderer.endColor = c2;
        wireLineRenderer.startWidth = 0.25f;
        wireLineRenderer.endWidth = 0.2f;

        wireLineRenderer.positionCount = 4;
        wireLineRenderer.SetPositions(this.getWirePoints());
        
    }

    public void callCircuitDone()
    {
        StartCoroutine(circuitDone());
    }

    IEnumerator circuitDone()
    {
        textInfo.text = "processing ..."; 
        yield return new WaitForSeconds(2);
        switch (demonstration_level)
        {
            case 1:

                textInfo.text = "Short Circuit! Battery Explodes!";
                yield return new WaitForSeconds(2);
                resetBoard1();
                demonstration_level = 2;
                textInfo.text = "Demonstration " + demonstration_level;
                yield return new WaitForSeconds(1);
                textInfo.text = "";
                demonstration2();

                break;

            case 2:
                textInfo.text = "Short Circuit! Battery Explodes!";
                yield return new WaitForSeconds(2);
                resetBoard2();
                demonstration_level = 3;
                textInfo.text = "Demonstration " + demonstration_level;
                yield return new WaitForSeconds(1);
                textInfo.text = "";
                demonstration3();

                break;

            case 3:
                textInfo.text = "Diode In Circuit! TBD";
                yield return new WaitForSeconds(2);
                resetBoard3();
                demonstration_level = 4;
                textInfo.text = "Demonstration " + demonstration_level;
                yield return new WaitForSeconds(1);
                textInfo.text = "";
                demonstration4();
                break;

            case 4:
                textInfo.text = "LED in Circuit and Lights Up";
                yield return new WaitForSeconds(2);
                resetBoard4();
                demonstration_level = 5;
                textInfo.text = "Demostration " + demonstration_level;
                yield return new WaitForSeconds(1);
                textInfo.text = "";
                demonstration5();
                break;

            case 5:
                textInfo.text = "Circuit in Series";
                yield return new WaitForSeconds(2);
                resetBoard4();
                demonstration_level = 5;
                textInfo.text = "Demostration " + demonstration_level;
                yield return new WaitForSeconds(1);
                textInfo.text = "";
                
                //demonstration6();

                break;

        }
   
    }

    void resetBoard4()
    {
        resetBoard2();
        Destroy(electricalComponent3.gameObject);
    }

    void resetBoard3()
    {
        resetBoard2();
        Destroy(electricalComponent2.gameObject);
    }

    void resetBoard2()
    {
        resetBoard1();
        Destroy(electricalComponent1.gameObject);
    }

    void resetBoard1()
    {
        Destroy(wireLineRenderer);
        Destroy(electricalComponent.gameObject);
    }
    
    ElectricalComponent electricalComponent1;
    void demonstration2()
    {
        demonstration_level = 2;
        electricalComponent = Instantiate(electricalComponents[0], inactivePosition[0].transform.position, Quaternion.identity);
        electricalComponent1 = Instantiate(electricalComponents[1], inactivePosition[1].transform.position, Quaternion.identity);

        electricalComponent.activeTransform = activePositions[0];
        electricalComponent1.activeTransform = activePositions[1];

        electricalComponent.gameObject.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);

        electricalComponent.componentState = ElectricalComponent.ComponentState.inactive;
        electricalComponent1.componentState = ElectricalComponent.ComponentState.inactive;

    }

    ElectricalComponent electricalComponent2;
    void demonstration3()
    {
        demonstration2();

        electricalComponent2 = Instantiate(electricalComponents[2], inactivePosition[2].transform.position, Quaternion.identity);
        electricalComponent2.activeTransform = activePositions[2];

        electricalComponent2.componentState = ElectricalComponent.ComponentState.inactive;
        demonstration_level = 3;
    }

    ElectricalComponent electricalComponent3;
    void demonstration4()
    {
        demonstration2();
        electricalComponent3 = Instantiate(electricalComponents[3], inactivePosition[3].transform.position, Quaternion.identity);
        electricalComponent3.activeTransform = activePositions[3];

        electricalComponent3.componentState = ElectricalComponent.ComponentState.inactive;
        demonstration_level = 4;

    }

    ElectricalComponent electricalComponent4;
    void demonstration5()
    {
        //this involves using 2 batteries ...
        demonstration4();
        electricalComponent4 = Instantiate(electricalComponents[4], inactivePosition[4].transform.position, Quaternion.identity);
        electricalComponent4.activeTransform = activePositions[4];

        electricalComponent4.componentState = ElectricalComponent.ComponentState.inactive;
        demonstration_level = 5;
        
    }

    public static ElectricalCircuitBuildingModule getInstance()
    {
        if (instance == null)
        {
            return new ElectricalCircuitBuildingModule();
        }
        else
        {
            return instance;
        }
    }

    public Transform getCircuitPath()
    {
        return circuitPath;
    }

    public Vector3[] getWirePoints()
    {
        ElectricalCircuitBuildingModule electricModule = ElectricalCircuitBuildingModule.getInstance();
        
        Vector3[] wirePoints = new Vector3[4];
        int i = 0;
        foreach (Transform wirePoint in electricModule.circuitPath)
        {
            wirePoints[i++] = wirePoint.position;
        }

        return wirePoints;
    }
}
