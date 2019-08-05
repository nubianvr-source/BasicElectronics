using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diode : MonoBehaviour
{
    public bool flipped = false;
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

    }

    public void flipDiode()
    {
        flipped = !flipped;
        //Color flippedColor = m_BulbMat.GetColor("_Color");
        if (flipped)
        {
            Material m_diodeMat= GetComponent<MeshRenderer>().material;
            m_diodeMat.SetColor("_Color", Color.red);
            
        }
        else
        {
            Material m_diodeMat = GetComponent<MeshRenderer>().material;
            m_diodeMat.SetColor("_Color", Color.blue);

        }

        ElectricalCircuitBuildingModule.getInstance().onDiodeFlipped();


    }
}
