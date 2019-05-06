using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAndUnload : MonoBehaviour
{
    public GameObject[] LoadGameObject;

    public GameObject[] UnloadGameObject;

    void OnTriggerEnter(Collider thing)
    {

        if(thing.gameObject.tag == "Player")
        {
        ForLoop(true, LoadGameObject);
        ForLoop(false, UnloadGameObject);
        }

    }

    void ForLoop(bool Enable, GameObject[] Array)
    {
        for(int i = 0; i <= Array.Length - 1; i++)
        {
            Debug.Log(i + "," + Enable + "," + Array);
            if(Array[i] != null)
            {
                Array[i].SetActive(Enable);
            }
        }
    }


}
