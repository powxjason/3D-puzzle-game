using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerClose : MonoBehaviour
{
    public GameObject Door;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Door.GetComponent<DoorLift>().TriggerEntered();
            Debug.Log("TriggerEntered");
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Door.GetComponent<DoorLift>().TriggerEntered();
            Debug.Log("TriggerEntered");
        }
    }




}
