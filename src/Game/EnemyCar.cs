using UnityEngine;
using System.Collections;

public class EnemyCar : MonoBehaviour {

	public GameObject explosion;

	public float speed = 8f;

	Rigidbody2D rb;
	//Enemy car hits
	int eCarHits = 0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (new Vector3(0,1,0) * speed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "enemycar" || col.gameObject.tag == "police" || col.gameObject.tag == "ambulance") {
			eCarHits += 1;
			if (eCarHits == 2) {
				PlayerPrefs.SetInt ("cars_destroyed", PlayerPrefs.GetInt ("cars_destroyed") + 1); //STATS
				Instantiate (explosion, new Vector3 (rb.position.x, rb.position.y), transform.rotation);
				Destroy (gameObject);
				eCarHits = 0;
			}
		}
	}
}
	
//CLEAN 1/23/16