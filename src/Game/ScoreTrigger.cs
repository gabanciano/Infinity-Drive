using UnityEngine;
using System.Collections;

public class ScoreTrigger : MonoBehaviour {

	public GameUIManager guim;
	public AudioManager am;

	//Temp score storage
	int scoreTemp;

	void OnTriggerEnter2D(Collider2D collide){
		if (collide.gameObject.tag == "enemycar") {
			ScoringSystem ();
			am.carScore.Play ();
		}

		if (collide.gameObject.tag == "police") {
			ScoringSystem ();
			PoliceIn ();
			am.carScore.Play ();
		}

		if (collide.gameObject.tag == "ambulance") {
			ScoringSystem ();
			AmbulanceIn ();
			am.carScore.Play ();
		}
	}

	void ScoringSystem(){
		if (guim.pickup2XActive) {
			scoreTemp += 2 - 1;
		}
		if (guim.pickup3XActive) {
			scoreTemp += 3 - 1;
		}
		if (guim.pickup3XActive && guim.pickup2XActive) {
			PlayerPrefs.SetInt ("stats_x5_get", PlayerPrefs.GetInt ("stats_x5_get") + 1);//STATSDATA
			scoreTemp += 5 - 3;
		} else {
			scoreTemp += 1;
		}
		PlayerPrefs.SetInt ("ingamescore", scoreTemp);
	}

	void PoliceIn(){
		PlayerPrefs.SetInt ("stats_police_in", PlayerPrefs.GetInt ("stats_police_in") + 1);
	}

	void AmbulanceIn(){
		PlayerPrefs.SetInt ("stats_ambulance_in", PlayerPrefs.GetInt ("stats_ambulance_in") + 1);
	}	
}

//CLEAN 1/23/16
