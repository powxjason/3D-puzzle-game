using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    public GameObject InteractSymbol;
    public GameObject PointingAt;
    Camera camera;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTarget();
        OpenDoors();
    }

    void CheckTarget()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {

            PointingAt = hit.transform.gameObject;

        }
    }

    void OpenDoors()
    {

        if (((PointingAt.gameObject.GetComponent("DoorLift") as DoorLift) != null))
        {
            InteractSymbol.SetActive(true);

            if (Input.GetButtonDown("Fire1")){

                PointingAt.GetComponent<DoorLift>().RaiseDoor();

            }                    
        }else
        {
            InteractSymbol.SetActive(false);
        }
    }
}
