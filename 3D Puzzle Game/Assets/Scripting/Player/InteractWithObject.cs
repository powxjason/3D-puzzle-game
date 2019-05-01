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
        InteractWithObjects();
    }

    void CheckTarget()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {

            PointingAt = hit.transform.gameObject;

        }
    }

    void InteractWithObjects()
    {
        switch (PointingAt.tag)
        {
            case "PowerCell":

                if (PointingAt.GetComponent("Rigidbody") as Rigidbody != null)
                {

                    InteractSymbol.SetActive(true);

                    if (Input.GetButtonDown("Fire1"))
                    {
                        GetComponent<PowerCellInteraction>().GrabPowerCell(PointingAt);                       
                    }

                }

                break;

            case "PowerCellSlot":
                InteractSymbol.SetActive(true);

                if (Input.GetButtonDown("Fire1") && PointingAt.gameObject.GetComponent<MeshRenderer>().enabled == false)
                {
                    GetComponent<PowerCellInteraction>().PlacePowerCell(PointingAt);
                }
                else if (Input.GetButtonDown("Fire1"))
                {
                    GetComponent<PowerCellInteraction>().PullPowerCell(PointingAt);
                }

                break;

            default:
                InteractSymbol.SetActive(false);
                break;
        }
    }

}

