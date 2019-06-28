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
        Debug.Log("flip this ...");
        if (gameObject.GetComponent<ElectricalComponent>().componentState == ElectricalComponent.ComponentState.active)
        {
            transform.localRotation = Quaternion.Euler(-transform.localRotation.x,
                                                       transform.localRotation.y,
                                                       transform.localRotation.z
                                                       );

        }



    }
}
