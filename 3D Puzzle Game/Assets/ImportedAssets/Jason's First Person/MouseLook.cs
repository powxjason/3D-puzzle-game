﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseX;
    public float mouseY;
    public float HorizontalSensitivity;
    public float VerticalSensitivity;
    public bool Locked = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Locked = false;

    }

    // Update is called once per frame
    void Update()
    {
        MouseInput();
        CameraSpin();
        //CameraMoveForward();
    }

    public void MouseLock()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Locked = true;
    }

    public void MouseUnlock()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Locked = false;
    }

    void MouseInput()
    {

        if (!Locked)
        {
            mouseX = Input.GetAxisRaw("Mouse X");
            mouseY = Input.GetAxisRaw("Mouse Y");

        }
        else
        {
            mouseX = 0f;
            mouseY = 0f;
        }

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
