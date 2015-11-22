using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {
	private GameObject ball = null;

	public bool isTriggerActive(){
		return ball != null;
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag.Equals("Ball")) {
			ball = coll.gameObject;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject == ball) {
			ball = null;
		}
	}
}
