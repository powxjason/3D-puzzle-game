using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCellLights : MonoBehaviour
{
    public GameObject Light;

    public void Placed()
    {
        Light.GetComponent<Light>().enabled = true;
    }

    public void Grabed()
    {
        Light.GetComponent<Light>().enabled = false;
    }
}
