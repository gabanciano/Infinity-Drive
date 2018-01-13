using UnityEngine;
using System.Collections;

public class PUpSpawner : MonoBehaviour {

	public GameUIManager ui;
	public GameObject[] pickups;
	int pickupid;

	public float maxPos = 2.2f;
	public float delayTimer = 0.5f;
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("gamestarted") == 1){
		if (!ui.pickup2XActive || !ui.pickup3XActive || !ui.pickupShieldActive) { //IF PICKUPS ARE ACTIVE THEN PICKUPS WONT SPAWN
				if (Time.timeScale == 1) {
					int chance = Random.Range (1, 275);
					if (chance == 1) {
						Vector3 pickupPos = new Vector3 (Random.Range (-2.0f, 2.0f), transform.position.y, transform.position.z);
						pickupid = Random.Range (0, 4); 
						Instantiate (pickups [pickupid], pickupPos, transform.rotation);
					}
				}
			}
		}
	}
}

//CLEAN 1/23/16
