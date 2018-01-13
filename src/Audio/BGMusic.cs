using UnityEngine;
using System.Collections;

public class BGMusic : MonoBehaviour {

	public static BGMusic instance;
	void Awake(){
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (transform.gameObject);
	}
}
