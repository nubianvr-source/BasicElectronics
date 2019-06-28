using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{

    public TextMesh ledState;
    public enum LightState
    {
        on,
        off
    }

    public LightState lightState = LightState.off;

    public void turnOnOff()
    {
        Debug.Log("do you get called");
        if (lightState == LightState.on)
        {
            lightState = LightState.off;
            turnOff();
        }
        else
        {
            lightState = LightState.on;
            turnOn();
        }
    }

    private void turnOn()
    {
        Debug.Log("Turn on Please");
        ledState.text = "ON";
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        Material m_BulbMat = GetComponent<MeshRenderer>().material;
        m_BulbMat.SetColor("_EmissionColor", Color.white);

    }

    private void turnOff()
    {
        Debug.Log("Turn OFF Please");
        ledState.text = "OFF";
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        Material m_BulbMat = GetComponent<MeshRenderer>().material;
        m_BulbMat.SetColor("_EmissionColor", Color.black);

    }

}
