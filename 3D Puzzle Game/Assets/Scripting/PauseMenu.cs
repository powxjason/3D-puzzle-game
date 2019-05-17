using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    Camera camera;

	// Use this for initialization
	void Start () {
        camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape) && Time.timeScale == 1) {
			Time.timeScale = 0;
			GetComponent<Canvas> ().enabled = true;
            camera.GetComponent<MouseLook>().MouseLock();
		}else if(Input.GetKeyDown (KeyCode.Escape) && Time.timeScale == 0){
			Resume();
        }

	}

	public void Resume(){
		Time.timeScale = 1;
		GetComponent<Canvas> ().enabled = false;
        camera.GetComponent<MouseLook>().MouseUnlock();
    }

	public void ExitGame(){
		Application.Quit ();
	}

	public void LoadMainMenu(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("MainMenu");
	}
}
