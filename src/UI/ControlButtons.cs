
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlButtons : MonoBehaviour {

	// 0 is Accelerometer
	// 1 is Touch Controls

	//Main Menu
	public Button controlTouchButton;
	public Button controlSensorButton;

	int controlPreset;

	void Start () {
        InitControlColor();
	}

    void InitControlColor()
    {
        controlPreset = PlayerPrefs.GetInt("controlpreset");
        if (controlPreset == 0)
        {
            controlSensorButton.GetComponent<Image>().color = Color.green;
            controlTouchButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            controlSensorButton.GetComponent<Image>().color = Color.white;
            controlTouchButton.GetComponent<Image>().color = Color.green;
        }
    }

	public void ControlSensorTap(){
		controlPreset = 0;
		PlayerPrefs.SetInt ("controlpreset", controlPreset);
		controlSensorButton.GetComponent<Image> ().color = Color.green;
		controlTouchButton.GetComponent<Image> ().color = Color.white;
	}

	public void ControlTouchTap(){
		controlPreset = 1;
		PlayerPrefs.SetInt ("controlpreset", controlPreset);
		controlSensorButton.GetComponent<Image> ().color = Color.white;
		controlTouchButton.GetComponent<Image> ().color = Color.green;
	}
}

//CLEAN 1/23/16
