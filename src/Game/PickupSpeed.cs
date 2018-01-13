using UnityEngine;
using System.Collections;

public class PickupSpeed : MonoBehaviour {

	public float speed = 4f;
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(0,1,0) * speed * Time.deltaTime);
	}
}

//CLEAN 1/23/16
