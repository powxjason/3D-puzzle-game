using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLift : MonoBehaviour
{
    public bool Opening;
    public bool Closing;

    public bool open = false;

    public float RaiseDistance;
    public float RaiseSpeed;
    public float DistanceRaised;

    // Start is called before the first frame update
    void Start()
    {
        if (RaiseSpeed < 0)
        {
            RaiseSpeed = RaiseSpeed * -1;
        }
        RaiseSpeed = RaiseSpeed / 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Opening == true)
        {
            StartCoroutine("RaisingDoor");
            Opening = false;
        }

        if(Closing == true)
        {
            StartCoroutine("LoweringDoor");
            Closing = false;
        }
    }

    public void RaiseDoor()
    {
        StopCoroutine("RaisingDoor");
        StopCoroutine("LoweringDoor");
        StartCoroutine("RaisingDoor");
    }

    public void LowerDoor()
    {
        StopCoroutine("RaisingDoor");
        StopCoroutine("LoweringDoor");
        StartCoroutine("LoweringDoor");
    }

    public void TriggerEntered()
    {
        if (open == true)
        {
            Debug.Log("Closing");

            open = false;

            LowerDoor();
            Closing = true;
        }
        else if (open == false)
        {

            Debug.Log("Opening");
            open = true;

            RaiseDoor();
            Opening = true;
        }
    }

    IEnumerator RaisingDoor()
    {
        while (DistanceRaised < RaiseDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + RaiseSpeed, transform.position.z);

            DistanceRaised = DistanceRaised + RaiseSpeed;

            yield return null;
            
        }
        

    }

    IEnumerator LoweringDoor()
    {
        while (DistanceRaised > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - RaiseSpeed, transform.position.z);

            DistanceRaised = DistanceRaised - RaiseSpeed;

            yield return null;


        }
    }    
}
