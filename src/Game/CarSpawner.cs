using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarSpawner : MonoBehaviour {

	//UI
	public Text controlTutorialText;

	public GameObject[] cars;
	int carNum;
	public float maxPos = 2.2f;
	public float delayTimer = 0.5f;
	float timer;
	float gameStarted = 6f; 

	void Start () {
		timer = delayTimer;
		ShowIntroMessage ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameStarted > 0) {
			gameStarted -= Time.deltaTime;
		}
		if (gameStarted <= 0) {
			PlayerPrefs.SetInt ("gamestarted", 1);
			if (Time.timeScale == 1) {
				timer -= Time.deltaTime;
				if (timer <= 0) {
					Vector3 carPos = new Vector3 (Random.Range (-2.0f, 2.0f), transform.position.y, transform.position.z);
					carNum = Random.Range (1, 22); 
					Instantiate (cars [carNum], carPos, transform.rotation);

					timer = delayTimer;
				}
			}
		}
	}

	void ShowIntroMessage(){
		if (PlayerPrefs.GetInt ("enableintroi") == 0) {
			if (PlayerPrefs.GetInt ("controlpreset") == 0) {
				controlTutorialText.text = "TILT YOUR DEVICE TO CONTROL YOUR CAR";
			} else if (PlayerPrefs.GetInt ("controlpreset") == 1) {
				controlTutorialText.text = "TOUCH THE LEFT AND RIGHT SIDE OF THE SCREEN TO CONTROL YOUR CAR";
			}
		} else {
			controlTutorialText.gameObject.SetActive (false);
		}
	}
}

//CLEAN 1/23/16