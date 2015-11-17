using UnityEngine;
using System.Collections;

public class Endbox : MonoBehaviour {
	public int playerId;
	public GameObject respawnPoint;

	public void ballEnter(GameObject ball){
		ball.transform.position = respawnPoint.transform.position;
		if (playerId == 1) {
			Globals.data.takePlayer1Life ();
			if (!Globals.data.isPlayer1Alive()){
				ball.SetActive(false);
			}
		} else if (playerId == 2) {
			Globals.data.takePlayer2Life ();
			if (!Globals.data.isPlayer2Alive()){
				ball.SetActive(false);
			}
		}
	}
}
