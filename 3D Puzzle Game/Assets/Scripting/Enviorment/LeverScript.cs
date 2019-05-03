using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{

    public GameObject PowerCell;
    public GameObject Door;

    public void Interact()
    {
        AlwaysDo();
    }

    void AlwaysDo()
    {
        //Lever Animation
        //Check if PowerCell is in the socket, if so run OnlyWithPower()
        if(PowerCell.GetComponent<MeshRenderer>().enabled == true)
        {
            OnlyWithPower();
        }
    }

    void OnlyWithPower()
    {
        if(Door.GetComponent<DoorLift>().open == false)
        {
            Door.GetComponent<DoorLift>().RaiseDoor();
        //Play Door Jingle
        }
    }
}
