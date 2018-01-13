using UnityEngine;
using System.Collections;

public class RocketBehavior : MonoBehaviour {

	public GameObject explosion;

	Rigidbody2D rocketRb;

	float rocketSpeed = 20f;

	// Use this for initialization
	void Start () {
		rocketRb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (new Vector3 (0, 1f, 0) * rocketSpeed * Time.deltaTime);
	}


	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "enemycar" || col.gameObject.tag == "police" || col.gameObject.tag == "ambulance") {
			Instantiate (explosion, new Vector3 (rocketRb.position.x, rocketRb.position.y), transform.rotation);
			MultiplierRocketScore ();
			PlayerPrefs.SetInt ("cars_destroyed", PlayerPrefs.GetInt ("cars_destroyed") + 1); //STATS
			Destroy (col.gameObject);
			Destroy (gameObject);
		}
	}

	void MultiplierRocketScore(){
		if (GameData.pickup2XActive) {
			PlayerPrefs.SetInt ("rocketscore", PlayerPrefs.GetInt ("rocketscore") + 10);
		} else if (GameData.pickup3XActive) {
			PlayerPrefs.SetInt ("rocketscore", PlayerPrefs.GetInt ("rocketscore") + 15);
		} else if (GameData.pickup2XActive && GameData.pickup3XActive) {
			PlayerPrefs.SetInt ("rocketscore", PlayerPrefs.GetInt ("rocketscore") + 25);
		} else {
			PlayerPrefs.SetInt ("rocketscore", PlayerPrefs.GetInt ("rocketscore") + 5);
		}
	}
}
