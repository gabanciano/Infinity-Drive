using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuUIManager : MonoBehaviour {

	public Image activeCarImage;
	public Text totalityTotalText;
	public Text highScoreText;

	public GameObject quitDialog;

	//TOTALITY POINTS INFO
	public Button dismissCloudButton;

	public GameObject gameMusic;

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

	Image carImage;

    void SoundChecker() {
        if (PlayerPrefs.GetInt("soundenabled") == 0) {
            AudioListener.pause = true;
        }
        else if (PlayerPrefs.GetInt("soundenabled") == 1) {
            AudioListener.pause = false;
        }
    }

	void Awake(){
		carImage = activeCarImage.GetComponent<Image> ();
	}

	void Start(){
		totalityTotalText.text = "" + PlayerPrefs.GetInt ("alltotality");
		highScoreText.text = "" + PlayerPrefs.GetInt("highscore");
		SoundChecker ();
		GetCarSprite ();
	}
		
	void Update(){
		if (Input.GetKeyUp (KeyCode.Escape)) {
			quitDialog.gameObject.SetActive (true);
		}
	}

	void GetCarSprite(){
		if (PlayerPrefs.GetInt ("playercarpref") == 1 || PlayerPrefs.GetInt ("playercarpref") == 0) {
			carImage.sprite = stockCarSprite;
		} else if (PlayerPrefs.GetInt ("playercarpref") == 2) {
			carImage.sprite = blueCarSprite;
		} else if (PlayerPrefs.GetInt ("playercarpref") == 3) {
			carImage.sprite = luckyCarSprite;
		} else if (PlayerPrefs.GetInt ("playercarpref") == 4) {
			carImage.sprite = punkCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 5) {
			carImage.sprite = goldenCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 6) {
			carImage.sprite = armoredCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 7) {
			carImage.sprite = phantomCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 8) {
			carImage.sprite = chalkyCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 9) {
			carImage.sprite = neonCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 10) {
			carImage.sprite = crossCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 11) {
			carImage.sprite = triCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 12) {
			carImage.sprite = cincoCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 13) {
			carImage.sprite = navyCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 14) {
			carImage.sprite = midnightCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 15) {
			carImage.sprite = rainbowCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 16) {
			carImage.sprite = blazeCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 17) {
			carImage.sprite = inviCarSprite;
		}  else if (PlayerPrefs.GetInt ("playercarpref") == 18) {
			carImage.sprite = camoCarSprite;
		}  

	}

	public void Play(){
		PlayerPrefs.SetInt ("stats_games_played", PlayerPrefs.GetInt ("stats_games_played") + 1);//STATSDATA
		SceneManager.LoadScene("game");
	}

	public void AboutTotalityPoints(){
		dismissCloudButton.gameObject.SetActive (true);	
	}
	public void DismissAboutCloud(){
		dismissCloudButton.gameObject.SetActive (false);
	}

	public void Stats(){
		SceneManager.LoadScene ("stats");
	}

	public void Garage(){
		SceneManager.LoadScene ("garage");
	}

	public void Settings(){
		SceneManager.LoadScene ("settings");
	}

	public void ConfirmExit(){
		Application.Quit ();
	}

	public void HideQuitDialog(){
		quitDialog.gameObject.SetActive (false);
	}
}

//CLEAN 1/23/16
