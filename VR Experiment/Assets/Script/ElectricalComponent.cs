using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalComponent : MonoBehaviour
{
    public Transform activeTransform;

    public enum ComponentState
    {
        active,
        inactive
    }

    public ComponentState componentState = ComponentState.inactive;

    //you need to know where to go when you are clicked on ...
    public void actionPerformedOnClick()
    {
        
        Debug.Log("Electrical component clicked "+ this.gameObject.name);
        transform.position = activeTransform.position;
        transform.localRotation = activeTransform.localRotation;
        componentState = ComponentState.active;

        //if its a battery and its active, then flip it ...
        if (gameObject.name+"(Clone)" == ElectricalCircuitBuildingModule.BATTERY)
        {
            Debug.Log("Do you get clicked");
            GetComponent<Battery>().actionPerformedOnClick();
        }


    }

    public void actionPerformedOnHover()
    {
        //Debug.Log("Do you get Hovered on?");
    }

    public void actionPerformedOnHoverOff()
    {
        //Debug.Log("Do I get Hovered off");
    }




        /*
        public Transform[] workspacePositions;
        public enum ComponentActiveStates{
            inactive,
            active
        }
        public ComponentActiveStates componentActiveState = ComponentActiveStates.inactive;

        public enum Connection_Statuses{
            not_connected,
            is_connecting,
            connected
        }

        public Connection_Statuses connection_status;  


        private bool positiveConnected = false;
        private bool negativeConnected = false;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // if (Connection_Statuses.is_connecting == connection_status){

            // }
        }

        void OnGUI(){

        }


        public void actionPerformedOnClick(){

            //if the object is inactive, send the object to the board ...
            if (componentActiveState == ComponentActiveStates.inactive){
                Debug.Log("Send to the Board");

                transform.position = this.workspacePositions[0].position;
                this.componentActiveState = ComponentActiveStates.active;

            }

        }

        public void actionPerformedOnHover(){
            //Debug.Log("I am hovering on an Electrical Component called "+gameObject.name);



            if (this.componentActiveState == ComponentActiveStates.inactive){



                // GameObject textInfoObject = GameObject.Find("TextInfo");
                // TextMesh tmInfo = textInfoObject.GetComponent<TextMesh>();
                // tmInfo.text = this.gameObject.name + "\nClick to Place on Table";

            }

        }

        public void actionPerformedOnHoverOff(){

            //Debug.Log("I am hovering on an Electrical Component called "+gameObject.name);

            if (this.componentActiveState == ComponentActiveStates.inactive){

                // GameObject textInfoObject = GameObject.Find("TextInfo");
                // TextMesh tmInfo = textInfoObject.GetComponent<TextMesh>();
                // tmInfo.text = "";

            }

        }
    */
    }
