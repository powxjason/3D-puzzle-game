using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLift : MonoBehaviour
{
    public bool Opening;

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
    }

    IEnumerator RaisingDoor()
    {

        while (DistanceRaised < RaiseDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + RaiseSpeed, transform.position.z);

            DistanceRaised = DistanceRaised + RaiseSpeed;

            yield return null;
        }

        Destroy(gameObject);
    }
    

    
}
