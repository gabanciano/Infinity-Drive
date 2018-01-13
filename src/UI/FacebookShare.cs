using UnityEngine;
using Facebook.Unity;
using System;
using System.Collections;
using System.Collections.Generic;

public class FacebookShare : MonoBehaviour {

	int finalScore;

	void Awake(){
		FB.Init (SetInit, OnHideUnity);
	}

	void SetInit(){
		if (FB.IsLoggedIn) {
			Debug.Log ("FB is Logged In");
		} else {
			Debug.Log ("FB is NOT Logged In");
		}
	}

	void OnHideUnity(bool isGameShown){
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	void ShareScore(){
		finalScore = PlayerPrefs.GetInt ("ingamescore") + PlayerPrefs.GetInt ("shieldscore") + PlayerPrefs.GetInt ("rocketscore");
		FB.ShareLink (
			new Uri ("https://www.facebook.com/InfinityDriveGame"),
			"I got " + finalScore + " points! Can you beat it?",
			"Download Infinity Drive on Google Play!",
			new Uri ("http://s31.postimg.org/b0asvkg1n/appbanner.png"),
			ShareCallBack);
	}

	void ShareCallBack(IResult result){
		if (result.Cancelled) {
			Debug.Log ("Share Cancelled");
		} else if (!string.IsNullOrEmpty (result.Error)) {
			Debug.Log ("Error on share!");
		} else if (!string.IsNullOrEmpty (result.RawResult)) {
			Debug.Log ("Share Success");
		}
	}

	public void FBLogin(){
		if (FB.IsLoggedIn) {
			Time.timeScale = 1;
			ShareScore ();
		} else {
			List<string> permissions = new List<string> ();
			permissions.Add ("public_profile");
			FB.LogInWithReadPermissions (permissions, AuthCallBack);
			ShareScore ();
		}
	}

	void AuthCallBack(IResult result){
		if (result.Error != null) {
			Debug.Log (result.Error);
		} else {
			isFacebookLoggedIn ();
		}
	}

	void isFacebookLoggedIn(){
		if (FB.IsLoggedIn) {
			Debug.Log ("FB is Logged In");
		} else {
			Debug.Log ("FB is NOT Logged In");
		}
	}
}
