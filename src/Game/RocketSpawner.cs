using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RocketSpawner : MonoBehaviour {

	public GameObject[] bullets;
	public GameUIManager ui;
	public PlayerControl pc;
	public AudioManager am;

	public Text rocketCountText;
	public Image rocketImage;

	public float rocketCount;

	float launcherPosX;
	float launcherPosY;

	int bulNum;

	float fireSpeed = 0.1f; // TIME BETWEEN FIRING ROCKETS

	bool enemyInbound = false;
	bool playOnce = true;

	void Start () {
		rocketCount = 5f;
	}

	// Update is called once per frame
	void Update () {
		launcherPosX = pc.transform.position.x;
		launcherPosY = pc.transform.position.y; //SPAWNER POSITION
		transform.position = new Vector3 (launcherPosX, launcherPosY);

		//ROCKET COUNT
		rocketCountText.text = "" + rocketCount;

		if (PlayerPrefs.GetInt ("playeralive") == 1) {
			if (ui.pickupRocketActive) { // IF ROCKET PICKUP IS PICKED!
				rocketImage.gameObject.SetActive(true);
				if (Time.timeScale == 1) { // IF GAME IS NOT PAUSED!
					if (rocketCount != 0 && enemyInbound) {
						if (playOnce) {
							am.missleLaunch.Play (); //ROCKET SOUND
							playOnce = false;
						}
						fireSpeed += Time.deltaTime;
						if (fireSpeed >= 0.1f && rocketCount != 0) {
							Vector3 bulPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
							bulNum = Random.Range (0, 0); 
							rocketCount -= 1;

							Instantiate (bullets [bulNum], bulPos, transform.rotation); //FIRED
							PlayerPrefs.SetInt("stats_rockets_fired", PlayerPrefs.GetInt("stats_rockets_fired")+1);//STATS

							fireSpeed = 0f;
							enemyInbound = false;
							playOnce = true;
						}
					}
					if (rocketCount == 0) {
						ui.pickupRocketActive = false;
						rocketImage.gameObject.SetActive (false);
						am.missleEmpty.Play ();
						rocketCount = 0f;
						gameObject.SetActive (false);
					}
				}
			}
		}
	} //METHODS SEMI COLON JIC

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "enemycar" || col.gameObject.tag == "police" || col.gameObject.tag == "ambulance"){
			enemyInbound =true;
		}
	}
}

//CLEAN 1/23/16