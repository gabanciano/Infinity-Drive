using UnityEngine;
using System.Collections;

public class ExplosionBehavior : MonoBehaviour {

	public Animator boomAnimator;

	float explosionSpeed = 0.5f;
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("playeralive") == 1) {
			transform.Translate(new Vector3(0,-3.5f,0) * explosionSpeed * Time.deltaTime);
		}

		if(this.boomAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
			Destroy(gameObject);
		}
	}
}
