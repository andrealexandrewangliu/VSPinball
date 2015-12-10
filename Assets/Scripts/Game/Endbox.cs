using UnityEngine;
using System.Collections;

public class Endbox : MonoBehaviour {
	public int playerId;
	public GameObject respawnPoint;

	public Game gameMainObject;

	public void ballEnter(GameObject ball){
		ball.transform.position = respawnPoint.transform.position;
		if (playerId == 1) {
			Globals.data.takePlayer1Life ();
			if (!gameMainObject.CheckWinCondition()){
				ball.SetActive(false);
			}
		} else if (playerId == 2) {
			Globals.data.takePlayer2Life ();
			if (!gameMainObject.CheckWinCondition()){
				ball.SetActive(false);
			}
		}
	}
}
