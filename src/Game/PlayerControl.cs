using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class PlayerControl : MonoBehaviour {
	
	public float carSpeed;

	public GameObject explosion;

	public GameUIManager ui;
	public AudioManager am;

	public RoadMove mainRoad;
	public RoadMove sideRRoad;
	public RoadMove sideLRoad;

	public GameObject shieldOrb;
	public GameObject rocketSpawner;

	public ShieldOrb so;
	public RocketSpawner rs;

	Vector3 position;
	Rigidbody2D rb;
	SpriteRenderer sr;

	//CAR SPRITES! THE SPRITE OF THE CAR WILL DEPEND ON THE CHOSEN CAR IN THE GARAGE!
	public Sprite stockCarSprite;
	public Sprite blueCarSprite;
	public Sprite luckyCarSprite;
	public Sprite punkCarSprite;
	public Sprite goldenCarSprite;
	public Sprite armoredCarSprite;
	public Sprite phantomCarSprite;
	public Sprite chalkyCarSprite;
	public Sprite neonCarSprite;
	public Sprite crossCarSprite;
	public Sprite triCarSprite;
	public Sprite cincoCarSprite;
	public Sprite navyCarSprite;
	public Sprite midnightCarSprite;
	public Sprite rainbowCarSprite;
	public Sprite blazeCarSprite;
	public Sprite inviCarSprite;
	public Sprite camoCarSprite;

	//TIMER WHEN GAME STARTING
	float carIntroTime = 2.5f; 

	//IF PLAYER IS ALIVE
	int playerAlive = 1;

	//So the car engine sound wont repeat
	bool doOnce;

	//How many times the player car got hit!
	int carHits = 0;

	//For Controls
	int controlPreset;

	void Awake(){
		PlayerPrefs.SetInt ("gamestarted", 0);
		rb = gameObject.GetComponent<Rigidbody2D> ();
		sr = gameObject.GetComponent<SpriteRenderer> ();

		CheckCarActiveSprite ();
	}

	void CheckCarActiveSprite(){
		//CAR SPRITE DETERMINING
		if (PlayerPrefs.GetInt ("playercarpref") == 1 || PlayerPrefs.GetInt ("playercarpref") == 0) {
			sr.sprite = stockCarSprite;
		} else if (PlayerPrefs.GetInt ("playercarpref") == 2) {
			sr.sprite = blueCarSprite;
		} else if (PlayerPrefs.GetInt ("playercarpref") == 3) {
			sr.sprite = luckyCarSprite;
		} else if (PlayerPrefs.GetInt ("playercarpref") == 4) {
			sr.sprite = punkCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 5) {
			sr.sprite = goldenCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 6) {
			sr.sprite = armoredCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 7) {
			sr.sprite = phantomCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 8) {
			sr.sprite = chalkyCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 9) {
			sr.sprite = neonCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 10) {
			sr.sprite = crossCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 11) {
			sr.sprite = triCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 12) {
			sr.sprite = cincoCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 13) {
			sr.sprite = navyCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 14) {
			sr.sprite = midnightCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 15) {
			sr.sprite = rainbowCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 16) {
			sr.sprite = blazeCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 17) {
			sr.sprite = inviCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 18) {
			sr.sprite = camoCarSprite;
		}  
	}
	// Use this for initialization
	void Start () {
		doOnce = true;
		sr.receiveShadows = true;

		controlPreset = PlayerPrefs.GetInt ("controlpreset"); //USER CONTROL CHOICE

		PlayerPrefs.SetInt ("playeralive", 1);
		am.carSound.Play ();
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	//GAME INTRO
		if(carIntroTime >= 0f){
			carIntroTime -= Time.deltaTime;
			transform.position = new Vector3(position.x, position.y + 1f * Time.deltaTime);
		}
	//CAR ENGINE SOUND
		if (Time.timeScale == 1) {
			if(doOnce){
				am.carSound.Play();
				doOnce = false;
			}
		} else {
			am.carSound.Stop();
			doOnce = true;

		}

	//CONTROLPRESET!
		if(controlPreset == 1 && playerAlive == 1){
			Screen.sleepTimeout = SleepTimeout.NeverSleep; //SCREEN WONT TURN OFF
			ui.ShowTouchControls();
		} else {
			ui.HideTouchControls();
			AccelerometerMove();
		}

		if (PlayerPrefs.GetInt ("playeralive") == 0) {
			if (Advertisement.isShowing) {
				Time.timeScale = 0;
			} else { 
				Time.timeScale = 1;
			}
		}
		position = transform.position;
		position.x = Mathf.Clamp (position.x, -2.15f, 2.2f);
		transform.position = position;
	
	//LOCK CONTRAINTS
		if(PlayerPrefs.GetInt("playeralive") == 0){
			rb.constraints = RigidbodyConstraints2D.None;
		}
	}

	void AccelerometerMove (){
		float x = Input.acceleration.x / 3.0f; 

		if (playerAlive == 1) {
			if(Time.timeScale == 1){
				transform.Translate (x, 0, 0);
			}
		}
	}


	//LOSE 
	void OnCollisionEnter2D(Collision2D col){
		//ENEMY COLLISION
		if (col.gameObject.tag == "enemycar" || col.gameObject.tag == "police" || col.gameObject.tag == "ambulance") {
			if(!ui.pickupShieldActive){
				ui.GameOverActivated();

				carHits += 1;
				if (carHits == 1) {
					am.deathBoom.Play();
				}
				if (carHits == 2) {
					//EXPLODE!
					Instantiate (explosion, new Vector3 (rb.position.x, rb.position.y), transform.rotation);
					Destroy (rocketSpawner);
					Destroy (gameObject);
				}
		
				playerAlive = 0;
				am.carSound.Stop();
				carSpeed = 0;


				mainRoad.scrollingSpeed = 0;
				sideLRoad.scrollingSpeed = 0;
				sideRRoad.scrollingSpeed = 0;

				PlayerPrefs.SetInt("controlpreset", controlPreset);
				PlayerPrefs.SetInt("playeralive", playerAlive);
				PlayerPrefs.SetInt ("shieldcore", 0);

				PlayerPrefs.SetInt ("stats_car_crashes", PlayerPrefs.GetInt ("stats_car_crashes") + 1);//STATSDATA
			}
		}
	//POWER UPS COLLITION
		//2x PICKUP
		if (col.gameObject.tag == "pick2x") {
			pickupSounds ();
			ui.pickup2XActive = true;
			GameData.pickup2XActive = true;
			Destroy(col.gameObject);
			PlayerPrefs.SetInt ("stats_x2_get", PlayerPrefs.GetInt ("stats_x2_get") + 1);//STATSDATA
		}
		if (col.gameObject.tag == "pick2x" && ui.pickup2XActive) {
			pickupSounds ();
			ui.pickupTimer = 0f;
			Destroy(col.gameObject);
			PlayerPrefs.SetInt ("stats_x2_get", PlayerPrefs.GetInt ("stats_x2_get") + 1);//STATSDATA
		}

		//3x PICKUP
		if (col.gameObject.tag == "pick3x") {
			pickupSounds ();
			ui.pickup3XActive = true;
			GameData.pickup3XActive = true;
			Destroy(col.gameObject);
			PlayerPrefs.SetInt ("stats_x3_get", PlayerPrefs.GetInt ("stats_x3_get") + 1);//STATSDATA
		}
		if (col.gameObject.tag == "pick3x" && ui.pickup3XActive) {
			pickupSounds ();
			ui.pickupTimer = 0f;
			Destroy(col.gameObject);
			PlayerPrefs.SetInt ("stats_x3_get", PlayerPrefs.GetInt ("stats_x3_get") + 1);//STATSDATA
		}

		//SHIELD PICKUP
		if (col.gameObject.tag == "pickshield") {
			am.shieldup.Play ();
			ui.pickupShieldActive = true;
			Destroy (col.gameObject);
			if (PlayerPrefs.GetInt ("playeralive") == 1) {
				shieldOrb.SetActive (true);
			}
			PlayerPrefs.SetInt ("stats_shield_get", PlayerPrefs.GetInt ("stats_shield_get") + 1);//STATS
		}
		if (col.gameObject.tag == "pickshield" && ui.pickupShieldActive) {
			am.shieldup.Play ();
			so.shieldTime = 0f;
			Destroy (col.gameObject);
			if (PlayerPrefs.GetInt ("playeralive") == 1) {
				shieldOrb.SetActive (true);
			}
			PlayerPrefs.SetInt ("stats_shield_get", PlayerPrefs.GetInt ("stats_shield_get") + 1);//STATS
		}


		if (col.gameObject.tag == "pickrocket") {
			am.misslePick.Play ();
			rocketSpawner.SetActive(true);
			ui.pickupRocketActive = true;
			PlayerPrefs.SetInt ("stats_rocket_get", PlayerPrefs.GetInt ("stats_rocket_get") + 1); //STATS
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "pickrocket" && ui.pickupRocketActive) {
			am.misslePick.Play ();
			rs.rocketCount = rs.rocketCount + 5f;
			PlayerPrefs.SetInt ("stats_rocket_get", PlayerPrefs.GetInt ("stats_rocket_get") + 1); //STATS
			Destroy (col.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D exit){
		if (exit.gameObject.tag == "enemycar" || exit.gameObject.tag == "ambulance" || exit.gameObject.tag == "police") {
			PlayerPrefs.SetInt ("ingamescore", PlayerPrefs.GetInt ("ingamescore") + 1);
		}
	}

	//FOR TOUCH CONTROLS
	public void MoveLeft(){
		rb.velocity = new Vector2 (-carSpeed, 0);
	}

	public void MoveRight(){
		rb.velocity = new Vector2 (carSpeed, 0);
	}

	public void SetVelocityZero(){
		rb.velocity = Vector2.zero;
	}

	void pickupSounds(){
		if (ui.pickup2XActive) {
			am.x2pickSound.Play ();
		} else if (ui.pickup3XActive) {
			am.x3pickSound.Play ();
		} else if (ui.pickup2XActive && ui.pickup3XActive) {
			am.x5pickSound.Play ();
		}
	}

	//ADS
	IEnumerator PrepareAd(){
		while (!Advertisement.IsReady())
			yield return null;
		Advertisement.Show ();
	}
}

//CLEAN 1/23/16
