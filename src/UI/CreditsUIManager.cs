using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CreditsUIManager : MonoBehaviour {

	void Update(){
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Back ();
		}
	}
	
	public void Back(){
		SceneManager.LoadScene ("settings");
	}
}

//CLEAN 1/23/16
