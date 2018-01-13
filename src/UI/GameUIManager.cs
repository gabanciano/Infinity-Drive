using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameUIManager : MonoBehaviour {
	
	string appId = "98558"; //FOR UNITYADS

	//GAME MUSIC
	public GameObject gameMusic;

	//FOR STATS PURPOSES
	int gplayed;
	int hscore;
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
	int totalityAll;

    [Header("Notification Box")]
	public Image notificationBox;
    [Space]
    [Header("Game UI Buttons")]
	public Button[] gameOverButtons;
	public Button[] touchButtons;
	public Button resumeButton;
	public Button shareButton;
    [Space]
	public Image rocketImage;

    [Header("Pickup Timers Progress Bars")]
	public Image pickupTimerBar;
	public Image shieldTimerBar;
	public Image shieldTimerImage;
    [Space]

    [Header("Pause Menu")]
	public Button pauseButton;
	public Button pauseBG;
    [Space]

    [Header("Game UI Texts")]
	public Text scoreText;
	public Text pickupText;
	public Text controlTutorialText;
	public Text pausedText;
	public Text gameOverText;
	public Text adCounterText;

	//ANIMS
	public Animation carUnlockedNotifAnim;

	public AudioManager am;
	public PlayerControl pc;

	public GameObject scoreDetector;

	bool gameOver;

	int score = 0;

	public float pickupTimer;

	//AD FREQUENCY
	int replayCount;

	//SOUND NONREPEATER
	bool doOnce = true;
	bool doOnceHighScore = true;

	//PICKUPS
	public bool pickup2XActive = false;
	public bool pickup3XActive = false;
	public bool pickupShieldActive = false;
	public bool pickupRocketActive = false;

    void InitData()
    {
        Advertisement.Initialize(appId, false);

        replayCount = PlayerPrefs.GetInt("adsreplaycount", 0);
        PlayerPrefs.GetInt("adsreplaycount", 4);
        PlayerPrefs.SetInt("ingamescore", 0);
        PlayerPrefs.SetInt("shieldscore", 0);
        PlayerPrefs.SetInt("rocketscore", 0);

        Time.timeScale = 1;
        gameOver = false;
        score = 0;
    }
    void StopMusic()
    {
        gameMusic = GameObject.Find("BGMusic");
        if (gameMusic)
        {
            Destroy(gameMusic);
        }
    }

	void Start()
    {
        InitData();
        StopMusic();
	}
	
	void Update () {
	//COMPUTES STATS REALTIME
		ComputeTotality ();		//REALTIME COMPUTATION OF STATS
		ScoringSystem ();		//SCORING SYSTEM
		PickupTimerDetect ();	//PICKUPS
		CarSoundPlay ();		//CAR SOUND
		BackButtonHardware ();	//BACK BUTTON PAUSE

		NotificationBoxMove();	//NOTIFICATION BOX LOGIC

		AdsConditions ();		//UNITY ADS
	}

	void PickupTimerDetect(){
		//PICKUP TIMERS
		if (pickup2XActive || pickup3XActive) {
			pickupTimer += 1 * Time.deltaTime;
			pickupTimerBar.rectTransform.sizeDelta = new Vector2 (250 - (pickupTimer * 5) * 10, 75);
			if (PlayerPrefs.GetInt ("playeralive") == 1) {
				if (Time.timeScale == 1) {
					pickupTimerBar.gameObject.SetActive (true);
				} else {
					pickupTimerBar.gameObject.SetActive (false);
				}
			} else {
				pickupTimerBar.gameObject.SetActive (false);
			}
		}
	}

	void ScoringSystem(){
		//START
		score = PlayerPrefs.GetInt ("ingamescore") + PlayerPrefs.GetInt ("shieldscore") + PlayerPrefs.GetInt("rocketscore");
		PickupPicked (); // POWER UPS
		//SCORE CONDITIONS
		if (score > PlayerPrefs.GetInt ("highscore")) {
			scoreText.color = Color.green;
		}
		scoreText.text = "" + score;
	}

	void CarSoundPlay(){
		//CAR SOUND
		if (PlayerPrefs.GetInt("playeralive") == 1) {
			if(doOnce){
				am.carSound.Play ();
				doOnce = false;
			}
		} else {
			am.carSound.Stop();
			doOnce = true;
		}
	}

	void NotificationBoxMove(){ //NOTIFICATION IF A NEW CAR IS UNLOCKED
		if ((PlayerPrefs.GetInt ("alltotality") >= 2500 && PlayerPrefs.GetInt ("alltotality") <= 2530) ||
		    (PlayerPrefs.GetInt ("alltotality") >= 5000 && PlayerPrefs.GetInt ("alltotality") <= 5030) ||
		    (PlayerPrefs.GetInt ("alltotality") >= 7500 && PlayerPrefs.GetInt ("alltotality") <= 7530) ||
		    (PlayerPrefs.GetInt ("alltotality") >= 10000 && PlayerPrefs.GetInt ("alltotality") <= 10030) ||
		    (PlayerPrefs.GetInt ("alltotality") >= 12000 && PlayerPrefs.GetInt ("alltotality") <= 12030) ||
		    (PlayerPrefs.GetInt ("alltotality") >= 20000 && PlayerPrefs.GetInt ("alltotality") <= 20030) ||
		    (PlayerPrefs.GetInt ("alltotality") >= 30000 && PlayerPrefs.GetInt ("alltotality") <= 30030) ||
		    (PlayerPrefs.GetInt ("alltotality") >= 35000 && PlayerPrefs.GetInt ("alltotality") <= 35030) ||
		    (PlayerPrefs.GetInt ("alltotality") >= 40000 && PlayerPrefs.GetInt ("alltotality") <= 40030)) 
		{
			notificationBox.gameObject.SetActive (true);
		}
	}

	void BackButtonHardware (){
		//PAUSE
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Pause ();
		}
	}

	void AdsConditions(){
		//ADS
		if (PlayerPrefs.GetInt ("playeralive") == 0) {
			if (Advertisement.isShowing) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}
		}
	}

	//SCORING 
	void PickupPicked(){
		//IF GAMEOVER IS FALSE
		if (!gameOver) {
			//PICKUP x1 - normal
			if (!pickup2XActive && !pickup3XActive) {
				scoreText.color = Color.white;
				pickupText.text = "";
			}
			//PICKUP x2
			if (pickup2XActive) {
				pickupText.text = "x2";
				scoreText.color = Color.yellow;
				pickupTimerBar.color = Color.yellow;
				if (pickupTimer > 5) {
					pickup2XActive = false;
					GameData.pickup2XActive = false;
					pickupTimer = 0;
				}
			}
			//PICKUP x3
			if (pickup3XActive) {
				pickupText.text = "x3";
				scoreText.color = Color.red;
				pickupTimerBar.color = Color.red;
				if (pickupTimer > 5) {
					pickup3XActive = false;
					GameData.pickup3XActive = false;
					pickupTimer = 0;
				}
			}

			//PICKUP x5
			if (pickup2XActive && pickup3XActive) {
				scoreText.color = Color.magenta;
				pickupTimerBar.color = Color.magenta;
				pickupText.text = "x5";
				if (pickupTimer > 5) {
					pickup3XActive = false;
					pickup2XActive = false;
					GameData.pickup2XActive = false;
					GameData.pickup3XActive = false;
					pickupTimer = 0;
				}
			}

			//SHIELD PICKUP
			if (pickupShieldActive) {//See ShieldOrb script
			}
			//ROCKET PICKUP
			if (pickupRocketActive) {//See RocketSpawner script for other commands
			}

			if (score == PlayerPrefs.GetInt ("highscore") + 1 || score == PlayerPrefs.GetInt ("highscore") + 2) {
				if (doOnceHighScore) {
					am.highScoreSound.Play ();
					doOnceHighScore = false;
				}
			}
		}
		//IF GAMEOVER = TRUE
		else if(gameOver){
			if(score > PlayerPrefs.GetInt("highscore")){
				PlayerPrefs.SetInt("highscore",score);
			}
		}
	}

	//PAUSE GAME
	public void Pause(){
		if (Time.timeScale == 1) {
			if (PlayerPrefs.GetInt ("playeralive") == 1) {
				Time.timeScale = 0;
				scoreText.gameObject.SetActive (false);
				pickupText.gameObject.SetActive (false);
				pickupTimerBar.gameObject.SetActive (false);
				resumeButton.gameObject.SetActive (true);

				pauseBG.gameObject.SetActive (true); // PAUSE BG

				pausedText.text = "PAUSED";

				if (PlayerPrefs.GetInt ("controlpreset") == 1) {
					HideTouchControls ();
				}

				foreach (Button button in gameOverButtons) {
					button.gameObject.SetActive (true);
				}
			}
		}
	}

	public void Unpause(){
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
			scoreText.gameObject.SetActive (true);
			pickupText.gameObject.SetActive (true);
			pickupTimerBar.gameObject.SetActive (true);
			resumeButton.gameObject.SetActive (false);
			pauseBG.gameObject.SetActive (false); // PAUSE BG

			pausedText.text = "";

			if(PlayerPrefs.GetInt("controlpreset") == 1){
				ShowTouchControls();
			}

			foreach (Button button in gameOverButtons) {
				button.gameObject.SetActive(false);
			}
		}
	}
	public void Replay(){
		//ADS
		replayCount -= 1;
		PlayerPrefs.SetInt ("adsreplaycount", replayCount);
		if (replayCount <= 0) {
            replayCount = 4;
			StartCoroutine(PrepareAd());
			PlayerPrefs.SetInt ("adsreplaycount", replayCount);
		}
	
	//CONTROLS
		if (PlayerPrefs.GetInt("controlpreset") == 1) {
			ShowTouchControls ();
		} else {
			HideTouchControls();
		}
	//SCENES
		SceneManager.LoadScene ("game");
		PlayerPrefs.SetInt ("stats_games_played", PlayerPrefs.GetInt ("stats_games_played") + 1);//STATSDATA
		Time.timeScale = 1;
	}

	//Touch control stuff DEPENDS ON THE MAIN MENU CONTROLS
	public void ShowTouchControls(){
		foreach (Button button in touchButtons) {
			button.gameObject.SetActive(true);
		}
	}
	public void HideTouchControls(){
		foreach (Button button in touchButtons) {
			button.gameObject.SetActive(false);
		}
	}

	//Game over
	public void GameOverActivated(){
		gameOver = true;

		if (score > PlayerPrefs.GetInt ("highscore")) {
			scoreText.color = Color.green;
			pickupText.color = Color.green;
			pickupText.text = "NEW HIGH SCORE";
			pickupText.fontSize = 40;
		} else if (score < PlayerPrefs.GetInt ("highscore")) {
			scoreText.color = Color.white;
			pickupText.color = Color.white;
			pickupText.text = "FINAL SCORE";
			pickupText.fontSize = 40;
		}

		rocketImage.gameObject.SetActive (false);
		pickupTimerBar.gameObject.SetActive (false);
		shieldTimerBar.gameObject.SetActive (false);
		gameOverText.gameObject.SetActive (true);
		shareButton.gameObject.SetActive (true);

        if (replayCount == 1){
            adCounterText.text = "AN AD WILL BE SHOWN ON THE NEXT RETRY";
        }
        else {
            adCounterText.text = "AN AD WILL BE SHOWN AFTER " + replayCount + " RETRIES";
        }
        adCounterText.gameObject.SetActive(true);

		scoreDetector.SetActive (false);


		foreach (Button button in touchButtons) {
			button.gameObject.SetActive(false);
		}
		foreach (Button button in gameOverButtons) {
			button.gameObject.SetActive(true);
		}
		pauseButton.gameObject.SetActive (false);
		PlayerPrefs.SetInt ("stats_all_scores", PlayerPrefs.GetInt("stats_all_scores") + PlayerPrefs.GetInt ("ingamescore"));//STATS
	}

	public void ComputeTotality(){
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

	public void Quit(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("mainmenu");
	}

	//ADS UNITYADS
	IEnumerator PrepareAd(){
		while (!Advertisement.IsReady())
			yield return null;
		Advertisement.Show ();
	}
}

//CLEAN 1/23/16