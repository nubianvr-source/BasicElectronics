using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Modules;

public class Main : MonoBehaviour
{

    UnitModule unit_module;
    void Awake()
    {
        unit_module  = new UnitModule();
        unit_module.init();
        
    }

    void Start()
    {
        
        //Get Users
        //authenticate with pin
        //
        //Get User's progress
        //UserModule user = UserModule.getUserInstance();




        //check the progress of the user and if there's none, start afresh.
        //sync user progress online





    }

    void Begin()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
