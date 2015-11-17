using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {
	public GameObject gateObject;


	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag.Equals("Ball")) {
			gateObject.SetActive(false);
		}
	}
	
	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.tag.Equals("Ball")) {
			gateObject.SetActive(true);
		}
	}
}
