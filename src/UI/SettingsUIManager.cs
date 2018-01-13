using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SettingsUIManager : MonoBehaviour {

	public Toggle introControlsToggle;
    public Button soundToggleButton;
	public Image soundImage;

	public Sprite soundOn;
	public Sprite soundOff;

    bool enableTutorialSequence = false;

    void InitTutorialToggle()
    {
        if (PlayerPrefs.GetInt("enableintroi") == 0)
        {
            introControlsToggle.isOn = true;
        }
        else if (PlayerPrefs.GetInt("enableintroi") == 1)
        {
            introControlsToggle.isOn = false;
        }
    }

    void InitSoundToggle()
    {
        if (!AudioListener.pause)
        {
            soundImage.sprite = soundOn;
            soundToggleButton.GetComponent<Image>().color = Color.green;
        }
        else if (AudioListener.pause)
        {
            soundImage.sprite = soundOff;
            soundToggleButton.GetComponent<Image>().color = Color.white;
        }
    }

    void Start(){
        InitTutorialToggle();
        InitSoundToggle();
	}

	void Update(){
        HardwareBackPressed();
	}

    public void EnableTutorialSequence()
    {
        if (enableTutorialSequence)
        {
            enableTutorialSequence = false;
            PlayerPrefs.SetInt("enableintroi", 1);
        } else if (!enableTutorialSequence)
        {
            enableTutorialSequence = true;
            PlayerPrefs.SetInt("enableintroi", 0);
        }
    }

	public void SoundToggle(){
        //0 IS ON! 1 IS OFF
		if (!AudioListener.pause) {
			AudioListener.pause = true;
            PlayerPrefs.SetInt("soundenabled", 0);
            soundToggleButton.GetComponent<Image>().color = Color.white;
			soundImage.sprite = soundOff;
		} else if (AudioListener.pause) {
			AudioListener.pause = false;
            PlayerPrefs.SetInt("soundenabled", 1);
            soundToggleButton.GetComponent<Image>().color = Color.green;
			soundImage.sprite = soundOn;
		}
	}

	void HardwareBackPressed(){
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            HardwareBackPressed();
        }
	}

    public void BackPressed()
    {
        SceneManager.LoadScene("mainmenu");
    }

	public void Credits(){SceneManager.LoadScene ("credits");}
}

//CLEAN 1/23/16
