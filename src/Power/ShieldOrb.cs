using UnityEngine;
using System.Collections;

public class ShieldOrb : MonoBehaviour {

	public GameObject explosion;
	Rigidbody2D rb;

	public AudioManager am;
	public PlayerControl pc;
	public GameUIManager ui;

	float orbPosX;
	float orbPosY;

	public float shieldTime = 0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("playeralive") == 1){
			if (ui.pickupShieldActive) {
				shieldTime += 1f * Time.deltaTime;
				ui.shieldTimerImage.gameObject.SetActive (true);
				ui.shieldTimerBar.rectTransform.sizeDelta = new Vector2 (250 - (shieldTime * 5) * 10, 75); // SHIELD PROGRESS BAR
				if (shieldTime > 5f) {
					gameObject.SetActive (false);
					shieldTime = 0f;
					ui.shieldTimerImage.gameObject.SetActive (false);
					ui.pickupShieldActive = false;
					am.shielddown.Play ();
				}
			}
		}

		//ORB GETS PLAYER POS
		orbPosX = pc.transform.position.x;
		orbPosY = pc.transform.position.y;
		transform.position = new Vector3 (orbPosX - 0.01f, orbPosY + 0.01f);

	}

	public void OnCollisionEnter2D(Collision2D orb){

		if (orb.gameObject.tag == "enemycar" || orb.gameObject.tag == "ambulance" || orb.gameObject.tag == "police") {
			if (PlayerPrefs.GetInt ("playeralive") == 1) {
				am.shieldCarHit.Play ();
				MultiplierWhileOnShield ();
				//orb.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(-100,0));
				rb = orb.gameObject.GetComponent<Rigidbody2D>();
				Instantiate (explosion, new Vector3 (rb.position.x, rb.position.y), transform.rotation);
				Destroy (orb.gameObject);
			}
		}
	}

	void MultiplierWhileOnShield(){
		if (ui.pickup2XActive) {
			PlayerPrefs.SetInt ("shieldscore", PlayerPrefs.GetInt ("shieldscore") + 6);
		} else if (ui.pickup3XActive) {
			PlayerPrefs.SetInt ("shieldscore", PlayerPrefs.GetInt ("shieldscore") + 9);
		} else if (ui.pickup2XActive && ui.pickup3XActive) {
			PlayerPrefs.SetInt ("shieldscore", PlayerPrefs.GetInt ("shieldscore") + 15);
		} else {
			PlayerPrefs.SetInt ("shieldscore", PlayerPrefs.GetInt("shieldscore") + 3);
		}
	}
	void OnDestroy(){
		PlayerPrefs.SetInt ("shieldscore", 0);
	}
}
