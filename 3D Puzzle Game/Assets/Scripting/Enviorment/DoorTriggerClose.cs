using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerClose : MonoBehaviour
{
    public GameObject Door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Raising Door");

             Door.GetComponent<DoorLift>().RaiseDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Lowering Door");

            Door.GetComponent<DoorLift>().LowerDoor();
        }
    }


}
