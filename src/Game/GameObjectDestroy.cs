using UnityEngine;
using System.Collections;

public class GameObjectDestroy : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "enemycar" || col.transform.tag == "police" || col.transform.tag == "ambulance") {Destroy(col.gameObject);}
		if (col.transform.tag == "pick2x") {Destroy (col.gameObject);}
		if (col.transform.tag == "pick3x") {Destroy(col.gameObject);}
		if (col.transform.tag == "playercar") {Destroy(col.gameObject);}
		if (col.transform.tag == "pickshield") {Destroy (col.gameObject);}
		if (col.transform.tag == "pickrocket") {Destroy (col.gameObject);}
		if (col.transform.tag == "rocket") {Destroy (col.gameObject);}
	}
}

//CLEAN 1/23/16
