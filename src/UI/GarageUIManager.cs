using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GarageUIManager : MonoBehaviour {

	//THE GARAGE SYSTEM LIES HERE

	//SCROLLVIEW
	public GameObject scrollRect;
	RectTransform adjustScroll;

	//STOCK CAR
	public Text stockButtonText;
	public Button stockEquipButton;

	//BLUE CAR
	public Text blueCarProgressText;
	public Text blueCarButtonText;
	public Button blueEquipButton;
	public Slider blueCarSlider;

	//lUCKY CAR
	public Text luckyCarProgressText;
	public Text luckyCarButtonText;
	public Button luckyEquipButton;
	public Slider luckyCarSlider;

	//PUNK CAR
	public Text punkCarProgressText;
	public Text punkCarButtonText;
	public Button punkEquipButton;
	public Slider punkCarSlider;

	//GOLDEN CAR
	public Text goldenCarProgressText;
	public Text goldenCarButtonText;
	public Button goldenEquipButton;
	public Slider goldenCarSlider;

	//ARMORED CAR
	public Text armoredCarProgressText;
	public Text armoredCarButtonText;
	public Button armoredEquipButton;
	public Slider armoredCarSlider;

	//PHANTOM CAR
	public Text phantomCarProgressText;
	public Text phantomCarButtonText;
	public Button phantomEquipButton;
	public Slider phantomCarSlider;

	//CHALKY CAR
	public Text chalkyCarProgressText;
	public Text chalkyCarButtonText;
	public Button chalkyEquipButton;
	public Slider chalkyCarSlider;

	//NEON CAR
	public Text neonCarProgressText;
	public Text neonCarButtonText;
	public Button neonEquipButton;
	public Slider neonCarSlider;

	//CROSS CAR
	public Text crossCarProgressText;
	public Text crossCarButtonText;
	public Button crossEquipButton;
	public Slider crossCarSlider;

	//TRI CAR
	public Text triCarProgressText;
	public Text triCarButtonText;
	public Button triEquipButton;
	public Slider triCarSlider;

	//CINCO CAR
	public Text cincoCarProgressText;
	public Text cincoCarButtonText;
	public Button cincoEquipButton;
	public Slider cincoCarSlider;

	//NAVY CAR
	public Text navyCarProgressText;
	public Text navyCarButtonText;
	public Button navyEquipButton;
	public Slider navyCarSlider;

	//MIDNIGHT CAR
	public Text midnightCarProgressText;
	public Text midnightCarButtonText;
	public Button midnightEquipButton;
	public Slider midnightCarSlider;

	//RAINBOW CAR
	public Text rainbowCarProgressText;
	public Text rainbowCarButtonText;
	public Button rainbowEquipButton;
	public Slider rainbowCarSlider;

	//BLAZE CAR
	public Text blazeCarProgressText;
	public Text blazeCarButtonText;
	public Button blazeEquipButton;
	public Slider blazeCarSlider;

	//INVI CAR
	public Text inviCarProgressText;
	public Text inviCarButtonText;
	public Button inviEquipButton;
	public Slider inviCarSlider;

	//CAMO CAR
	public Text camoCarProgressText;
	public Text camoCarButtonText;
	public Button camoEquipButton;
	public Slider camoCarSlider;


	// Use this for initialization
	void Awake(){
		adjustScroll = scrollRect.GetComponent<RectTransform> ();

		//SETS SCROLL'S SIZE BASED ON SCREEN RESOLUTION
		if (Screen.width == 320 && Screen.height == 480){
			adjustScroll.localPosition = new Vector3 (0.6f, -5.25f);
			adjustScroll.sizeDelta = new Vector2 (320f, 389.4f);
		} else if (Screen.width == 480 && Screen.height == 800){
			adjustScroll.localPosition = new Vector3 (0.6f, -5.25f);
			adjustScroll.sizeDelta = new Vector2 (320f, 442.73f);
		} else if ((Screen.width == 720 && Screen.height == 1280) || (Screen.width == 480 && Screen.height == 854)){ 
			adjustScroll.localPosition = new Vector3 (0.6f, -5.25f);
			adjustScroll.sizeDelta = new Vector2 (320f, 478.58f);
		} else if (Screen.width == 1080 && Screen.height == 1980){
			adjustScroll.localPosition = new Vector3 (0.6f, -5.25f);
			adjustScroll.sizeDelta = new Vector2 (320f, 478.58f);
		}
			
		//CAR CHOOSED WILL BE HERE ON THIS PLAYERPREF VALUE
		// 1 = STOCK CAR
		// 2 = BLUE CAR
		// 3 = LUCKY CAR
		// 4 = PUNK CAR
		// 5 = GOLDEN CAR
		// 6 = ARMORED CAR
		// 7 = PHANTOM CAR
		// 8 = CHALKY CAR
		// 9 = NEON CAR
		// 10 = CROSS CAR
		// 11 = TRI CAR
		// 12 = CINCO CAR
		// 13 = NAVY CAR
		// 14 = MIDNIGHT CAR
		// 15 = RAINBOW CAR
		// 16 = BLAZE CAR
		// 17 = INVI CAR
		// 18 = CAMO CAR

		//CAR PROGRESS
		if (PlayerPrefs.GetInt ("playercarpref") == 1 || PlayerPrefs.GetInt ("playercarpref") == 0) { //STOCK
			StockCarPicked();

		} else if (PlayerPrefs.GetInt ("playercarpref") == 2) { //BLUECAR
			BlueCarPicked();

		} else if (PlayerPrefs.GetInt ("playercarpref") == 3) { //LUCKYCAR
			LuckyCarPicked();

		} else if (PlayerPrefs.GetInt ("playercarpref") == 4) { //PUNKCAR
			PunkCarPicked();

		} else if (PlayerPrefs.GetInt ("playercarpref") == 5) { //GOLDENCAR
			GoldenCarPicked();

		} else if (PlayerPrefs.GetInt ("playercarpref") == 6) { //ARMOREDCAR
			ArmoredCarPicked();

		} else if (PlayerPrefs.GetInt ("playercarpref") == 7) { //PHANTOMCAR
			PhantomCarPicked();
		
		} else if (PlayerPrefs.GetInt ("playercarpref") == 8) { //CHALKYCAR
			ChalkyCarPicked();
		
		} else if (PlayerPrefs.GetInt ("playercarpref") == 9) { //NEONCAR
			NeonCarPicked();

		}  else if (PlayerPrefs.GetInt ("playercarpref") == 10) { //CROSSCAR
			CrossCarPicked();

		}  else if (PlayerPrefs.GetInt ("playercarpref") == 11) { //TRICAR
			TriCarPicked();

		}  else if (PlayerPrefs.GetInt ("playercarpref") == 12) { //CINCOCAR
			CincoCarPicked();

		}  else if (PlayerPrefs.GetInt ("playercarpref") == 13) { //NAVYCAR
			NavyCarPicked();

		}  else if (PlayerPrefs.GetInt ("playercarpref") == 14) { //MIDNIGHTCAR
			MidnightCarPicked();

		}  else if (PlayerPrefs.GetInt ("playercarpref") == 15) { //RAINBOWCAR
			RainbowCarPicked();

		}  else if (PlayerPrefs.GetInt ("playercarpref") == 16) { //BLAZECAR
			BlazeCarPicked();

		}  else if (PlayerPrefs.GetInt ("playercarpref") == 17) { //INVICAR
			InviCarPicked();

		}  else if (PlayerPrefs.GetInt ("playercarpref") == 18) { //CAMOCAR
			CamoCarPicked();
		}   



			
		//SLIDERS
		blueCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //BLUECAR
		luckyCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //LUCKYCAR
		punkCarSlider.value = PlayerPrefs.GetInt("alltotality"); //PUNKCAR
		goldenCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //GOLDCAR
		armoredCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //ARMOREDCAR
		phantomCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //PHANTOMCAR
		chalkyCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //CHALKYCAR
		neonCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //NEONCAR
		crossCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //CROSSCAR
		triCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //TRICAR
		cincoCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //CINCOCAR
		navyCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //NAVYCAR
		midnightCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //MIDNIGHTCAR
		rainbowCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //RAINBOWCAR
		blazeCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //BLAZECAR
		inviCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //INVICAR
		camoCarSlider.value = PlayerPrefs.GetInt ("alltotality"); //CAMOCAR


		if (blueCarSlider.value == 2500) {
			blueCarProgressText.gameObject.SetActive (false);
			blueCarSlider.gameObject.SetActive (false);
			blueEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 1);
		}

		if (luckyCarSlider.value == 5000) {
			luckyCarProgressText.gameObject.SetActive (false);
			luckyCarSlider.gameObject.SetActive (false);
			luckyEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 2);
		}

		if (punkCarSlider.value == 7500) {
			punkCarProgressText.gameObject.SetActive (false);
			punkCarSlider.gameObject.SetActive (false);
			punkEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 3);
		}

		if (goldenCarSlider.value == 10000) {
			goldenCarProgressText.gameObject.SetActive (false);
			goldenCarSlider.gameObject.SetActive (false);
			goldenEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 4);
		}

		if (armoredCarSlider.value == 12500) {
			armoredCarProgressText.gameObject.SetActive (false);
			armoredCarSlider.gameObject.SetActive (false);
			armoredEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 5);
		}

		if (phantomCarSlider.value == 15000) {
			phantomCarProgressText.gameObject.SetActive (false);
			phantomCarSlider.gameObject.SetActive (false);
			phantomEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 6);
		}

		if (chalkyCarSlider.value == 17500) {
			chalkyCarProgressText.gameObject.SetActive (false);
			chalkyCarSlider.gameObject.SetActive (false);
			chalkyEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 7);
		}

		if (neonCarSlider.value == 20000) {
			neonCarProgressText.gameObject.SetActive (false);
			neonCarSlider.gameObject.SetActive (false);
			neonEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 8);
		}

		if (crossCarSlider.value == 22500) {
			crossCarProgressText.gameObject.SetActive (false);
			crossCarSlider.gameObject.SetActive (false);
			crossEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 9);
		}

		if (triCarSlider.value == 25000) {
			triCarProgressText.gameObject.SetActive (false);
			triCarSlider.gameObject.SetActive (false);
			triEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 10);
		}

		if (cincoCarSlider.value == 27500) {
			cincoCarProgressText.gameObject.SetActive (false);
			cincoCarSlider.gameObject.SetActive (false);
			cincoEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 11);
		}

		if (navyCarSlider.value == 30000) {
			navyCarProgressText.gameObject.SetActive (false);
			navyCarSlider.gameObject.SetActive (false);
			navyEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 12);
		}

		if (midnightCarSlider.value == 32500) {
			midnightCarProgressText.gameObject.SetActive (false);
			midnightCarSlider.gameObject.SetActive (false);
			midnightEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 13);
		}

		if (rainbowCarSlider.value == 35000) {
			rainbowCarProgressText.gameObject.SetActive (false);
			rainbowCarSlider.gameObject.SetActive (false);
			rainbowEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 14);
		}

		if (blazeCarSlider.value == 37500) {
			blazeCarProgressText.gameObject.SetActive (false);
			blazeCarSlider.gameObject.SetActive (false);
			blazeEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 15);
		}

		if (inviCarSlider.value == 40000) {
			inviCarProgressText.gameObject.SetActive (false);
			inviCarSlider.gameObject.SetActive (false);
			inviEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 16);
		}

		if (camoCarSlider.value == 42500) {
			camoCarProgressText.gameObject.SetActive (false);
			camoCarSlider.gameObject.SetActive (false);
			camoEquipButton.gameObject.SetActive (true);

			PlayerPrefs.SetInt ("cars_unlocked", 17);
		}
	}

	void Update(){
		//ANDROID BACK HARDWARE BUTTON
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Back ();
		}

		//CAR SLIDERS COUNT
		blueCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/2500";
		luckyCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/5000";
		punkCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/7500";
		goldenCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/10000";
		armoredCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/12500";
		phantomCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/15000";
		chalkyCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/17500";
		neonCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/20000";
		crossCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/22500";
		triCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/25000";
		cincoCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/27500";
		navyCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/30000";
		midnightCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/32500";
		rainbowCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/35000";
		blazeCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/37500";
		inviCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/40000";
		camoCarProgressText.text = "" + PlayerPrefs.GetInt ("alltotality") + "/42500";
	}

	//STOCK CAR
	public void StockCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.green;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;


		stockButtonText.text = "IN USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 1);
	}
	//BLUE CAR
	public void BlueCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.green;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;

		stockButtonText.text = "USE";
		blueCarButtonText.text = "IN USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 2);
	}
	//LUCKY CAR
	public void LuckyCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.green;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;

		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "IN USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 3);
	}
	//PUNK CAR
	public void PunkCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.green;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;

		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "IN USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 4);
	}
	//GOLDEN CAR
	public void GoldenCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.green;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;

		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "IN USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 5);
	}
	//ARMORED CAR
	public void ArmoredCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.green;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;

		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "IN USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 6);
	}
	//PHANTOM CAR
	public void PhantomCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.green;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;

		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "IN USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 7);
	}
	//CHALKY CAR
	public void ChalkyCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.green;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;

		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "IN USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 8);
	}
	//NEON CAR
	public void NeonCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.green;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;

		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "IN USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 9);
	}

	//CROSS CAR
	public void CrossCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.green;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;

		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "IN USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 10);
	}

	//TRI CAR
	public void TriCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.green;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;

		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "IN USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 11);
	}

	//CINCO CAR
	public void CincoCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.green;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;

		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "IN USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 12);
	}

	//NAVY CAR
	public void NavyCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.green;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;

		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "IN USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 13);
	}

	public void MidnightCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.green;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;


		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "IN USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 14);
	}

	public void RainbowCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.green;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;


		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "IN USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 15);
	}

	public void BlazeCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.green;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.white;


		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "IN USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 16);
	}

	public void InviCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.green;
		camoEquipButton.GetComponent<Image> ().color = Color.white;


		stockButtonText.text = "IN USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "IN USE";
		camoCarButtonText.text = "USE";

		PlayerPrefs.SetInt ("playercarpref", 17);
	}

	public void CamoCarPicked(){
		stockEquipButton.GetComponent<Image> ().color = Color.white;
		blueEquipButton.GetComponent<Image> ().color = Color.white;
		luckyEquipButton.GetComponent<Image> ().color = Color.white;
		punkEquipButton.GetComponent<Image> ().color = Color.white;
		goldenEquipButton.GetComponent<Image> ().color = Color.white;
		armoredEquipButton.GetComponent<Image> ().color = Color.white;
		phantomEquipButton.GetComponent<Image> ().color = Color.white;
		chalkyEquipButton.GetComponent<Image> ().color = Color.white;
		neonEquipButton.GetComponent<Image> ().color = Color.white;
		crossEquipButton.GetComponent<Image> ().color = Color.white;
		triEquipButton.GetComponent<Image> ().color = Color.white;
		cincoEquipButton.GetComponent<Image> ().color = Color.white;
		navyEquipButton.GetComponent<Image> ().color = Color.white;
		midnightEquipButton.GetComponent<Image> ().color = Color.white;
		rainbowEquipButton.GetComponent<Image> ().color = Color.white;
		blazeEquipButton.GetComponent<Image> ().color = Color.white;
		inviEquipButton.GetComponent<Image> ().color = Color.white;
		camoEquipButton.GetComponent<Image> ().color = Color.green;


		stockButtonText.text = "USE";
		blueCarButtonText.text = "USE";
		luckyCarButtonText.text = "USE";
		punkCarButtonText.text = "USE";
		goldenCarButtonText.text = "USE";
		armoredCarButtonText.text = "USE";
		phantomCarButtonText.text = "USE";
		chalkyCarButtonText.text = "USE";
		neonCarButtonText.text = "USE";
		crossCarButtonText.text = "USE";
		triCarButtonText.text = "USE";
		cincoCarButtonText.text = "USE";
		navyCarButtonText.text = "USE";
		midnightCarButtonText.text = "USE";
		rainbowCarButtonText.text = "USE";
		blazeCarButtonText.text = "USE";
		inviCarButtonText.text = "USE";
		camoCarButtonText.text = "IN USE";

		PlayerPrefs.SetInt ("playercarpref", 18);
	}

	public void Back(){
		SceneManager.LoadScene ("mainmenu");
	}
}
