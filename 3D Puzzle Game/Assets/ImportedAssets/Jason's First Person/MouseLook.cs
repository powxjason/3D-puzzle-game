using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseX;
    public float mouseY;
    public float HorizontalSensitivity;
    public float VerticalSensitivity;
    public bool Locked;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MouseLock();
        MouseInput();
        CameraSpin();
        //CameraMoveForward();
    }

    void MouseLock()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void MouseInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        //Debug.Log(mouseX + " + " + mouseY);

    }

    void CameraSpin()
    {

        if (!Locked)
        {
            transform.Rotate(mouseY * -VerticalSensitivity, 0, 0, Space.Self);
            transform.Rotate(0, mouseX * HorizontalSensitivity, 0, Space.Self);

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }

    }

    void CameraMoveForward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward);
        }

    }

    public void CameraLock()
        {
        if (Locked)
        {
            Locked = false;
        }else
        {
            Locked = true;
        }

         
            

        }
}
