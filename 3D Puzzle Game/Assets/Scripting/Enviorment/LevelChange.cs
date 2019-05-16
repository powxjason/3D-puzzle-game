using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{

    public string LevelString;

    private void OnTriggerEnter(Collider other)
    {

        if(LevelString != null)
        {
            SceneManager.LoadScene(LevelString);
        }
        else
        {
            Debug.Log("No Level Selected");
        }
    }
}
