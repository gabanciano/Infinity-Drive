using UnityEngine;
using System.Collections;

public class RoadMove : MonoBehaviour {

	public float scrollingSpeed;
	Vector2 offset;

	void Update () {
		offset = new Vector2 (0, Time.time * scrollingSpeed);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	} 
}
