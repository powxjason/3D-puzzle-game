using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyControll : MonoBehaviour
{
    public GameObject Camera;

    float Xinput;
    float Yinput;

    public float ForwardSpeed;
    public float StrafeSpeed;
    public float BackPedalSpeed;
    public float RunSpeedMutiply;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        YrotationCopy();
        Movement();
    }

    void YrotationCopy()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    void Movement()
    {
        Xinput = Input.GetAxisRaw("Horizontal");
        Yinput = Input.GetAxisRaw("Vertical");

        Vector3 YinputVector;
        Vector3 XinputVector;

        if(Yinput != 0)
        {

            if(Yinput > 0)
            {
                YinputVector = transform.forward * ForwardSpeed;
            }
            else
            {
                YinputVector = -transform.forward * BackPedalSpeed;
            }

        }
        else
        {
            YinputVector = new Vector3(0, 0, 0);
        }

        if (Xinput != 0)
        {

            if (Xinput > 0)
            {
                XinputVector = transform.right * StrafeSpeed;
            }
            else
            {
                XinputVector = -transform.right * StrafeSpeed;
            }

        }
        else
        {
            XinputVector = new Vector3(0, 0, 0);
        }

        

        Vector3 inputVector = XinputVector +YinputVector;

        if (Input.GetButton("Run"))
        {
            inputVector = inputVector * 2;
        }
            

        GetComponent<Rigidbody>().velocity = new Vector3 (inputVector.x, GetComponent<Rigidbody>().velocity.y, inputVector.z);


    }
}
