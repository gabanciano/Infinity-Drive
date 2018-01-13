using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StatsUIManager : MonoBehaviour {

	//FAQ
	public GameObject dismissCloudButton;

	//SCROLLVIEW
	public GameObject statsScrollPanel;
	RectTransform adjustPanel;

	int inGameTotalScore;

	int gplayed;			//Games played
	int hscore;				// High score
	int tscore;
	int carsunlocked;
	int ccrash;
	int tpol;
	int tamb;
	int trfired;
	int tcdestroyed;
	int tx2;
	int tx3;
	int tx5;
	int tshield;
	int trocket;

	public Text gamesPlayed;
	public Text highScore;
	public Text totalScore;
	public Text carsUnlocked;
	public Text carCrashes;
	public Text ttlPolice;
	public Text ttlAmblnc;
	public Text ttlrFired;
	public Text ttlcDestroyed;
	public Text ttlX2;
	public Text ttlX3;
	public Text ttlX5;
	public Text ttlshield;
	public Text ttlrocket;

	public Text totalityText;

	int totalityAll;

	void Awake(){
		adjustPanel = statsScrollPanel.GetComponent<RectTransform> ();

		//SETS SCROLL'S SIZE BASED ON SCREEN RESOLUTION
		if (Screen.width == 320 && Screen.height == 480) {
			adjustPanel.sizeDelta = new Vector2 (800f, 764.56f);
		} else if (Screen.width == 480 && Screen.height == 800) {
			adjustPanel.sizeDelta = new Vector2 (800f, 897.89f);
		} else if ((Screen.width == 720 && Screen.height == 1280) || (Screen.width == 480 && Screen.height == 854)) { 
			adjustPanel.sizeDelta = new Vector2 (800f, 987.5f);
		} else if (Screen.width == 800 && Screen.height == 1280){
			adjustPanel.sizeDelta = new Vector2 (800f, 844.23f);
		} else if (Screen.width == 1080 && Screen.height == 1980){
			adjustPanel.sizeDelta = new Vector2 (800f, 987.5f);
		}

		computeTotality ();

		gamesPlayed.text = "" + gplayed;
		highScore.text = "" + hscore;
		totalScore.text = "" + tscore;
		carCrashes.text = "" + ccrash;
		carsUnlocked.text = "" + carsunlocked + "/17";
		ttlPolice.text = "" + tpol;
		ttlAmblnc.text = "" + tamb;
		ttlrFired.text = "" + trfired;
		ttlcDestroyed.text = "" + tcdestroyed;
		ttlX2.text = "" + tx2;
		ttlX3.text = "" + tx3;
		ttlX5.text = "" + tx5;
		ttlshield.text = "" + tshield;
		ttlrocket.text = "" + trocket;

		totalityText.text = "" + totalityAll;
		PlayerPrefs.SetInt ("alltotality", totalityAll);
	}

	public void computeTotality(){
		//STATS DATA BEING ENCODED ON AWAKE! :D
		gplayed = PlayerPrefs.GetInt ("stats_games_played");
		hscore = PlayerPrefs.GetInt ("highscore");
		tscore = PlayerPrefs.GetInt ("stats_all_scores");
		carsunlocked = PlayerPrefs.GetInt ("cars_unlocked");
		ccrash = PlayerPrefs.GetInt ("stats_car_crashes");
		trfired = PlayerPrefs.GetInt ("stats_rockets_fired");
		tcdestroyed = PlayerPrefs.GetInt ("cars_destroyed");
		tpol = PlayerPrefs.GetInt ("stats_police_in");
		tamb = PlayerPrefs.GetInt ("stats_ambulance_in");
		tx2 = PlayerPrefs.GetInt ("stats_x2_get");
		tx3 = PlayerPrefs.GetInt ("stats_x3_get");
		tx5 = PlayerPrefs.GetInt ("stats_x5_get");
		tshield = PlayerPrefs.GetInt ("stats_shield_get");
		trocket = PlayerPrefs.GetInt ("stats_rocket_get");

		totalityAll = gplayed + hscore + tscore + carsunlocked + ccrash + tpol + tamb + tx2 + tx3 + tx5 + tcdestroyed + trfired + tshield + trocket; //Totality points for totality
		PlayerPrefs.SetInt ("alltotality", totalityAll);
	}
	void Update(){
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Back ();
		}
	}

	public void AboutTotalityPoints(){
		dismissCloudButton.gameObject.SetActive (true);	
	}
	public void DismissAboutCloud(){
		dismissCloudButton.gameObject.SetActive (false);
	}

	public void Back(){
		SceneManager.LoadScene ("mainmenu");
	}
		
	public void Credits(){SceneManager.LoadScene ("credits");}
}

//CLEAN 1/23/16

