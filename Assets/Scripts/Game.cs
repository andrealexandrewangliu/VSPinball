using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public GameObject ball;
	[System.Serializable]
	public class PlayerSpecific
	{
		public Cannon cannon;
		public Flipper left;
		public Flipper right;
		public TableTilt tilt;
	}
	public PlayerSpecific player1;
	public PlayerSpecific player2;
	// Use this for initialization
	void Start () {
		Demo ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetAI(){
		player1.cannon.aiActive = Globals.data.player1AI;
		player1.left.aiActive = Globals.data.player1AI;
		player1.right.aiActive = Globals.data.player1AI;
		player1.tilt.aiActive = Globals.data.player1AI;
		
		player2.cannon.aiActive = Globals.data.player1AI;
		player2.left.aiActive = Globals.data.player1AI;
		player2.right.aiActive = Globals.data.player1AI;
		player2.tilt.aiActive = Globals.data.player1AI;
	}

	public void NewGame(){
		int randomInt = Random.Range (0, 2);
		if (randomInt < 1) {
			ball.transform.position = player1.cannon.gameObject.transform.position;
		} else {
			ball.transform.position = player2.cannon.gameObject.transform.position;
		}
		SetAI ();
		Globals.player1Lives = Globals.data.initialLives;
		Globals.player2Lives = Globals.data.initialLives;
		Globals.RoundUpdate ();
	}
	
	
	public void Demo(){
		int randomInt = Random.Range (0, 2);
		if (randomInt < 1) {
			ball.transform.position = player1.cannon.gameObject.transform.position;
		} else {
			ball.transform.position = player2.cannon.gameObject.transform.position;
		}
		player1.cannon.aiActive = true;
		player1.left.aiActive = true;
		player1.right.aiActive = true;
		player1.tilt.aiActive = true;
		
		player2.cannon.aiActive = true;
		player2.left.aiActive = true;
		player2.right.aiActive = true;
		player2.tilt.aiActive = true;
		Globals.player1Lives = -1;
		Globals.player2Lives = -1;
		Globals.RoundUpdate ();
	}
	
	public void DataWritePlayer1AI(bool value){
		Globals.data.player1AI = value;
	}
	
	public void DataWritePlayer2AI(bool value){
		Globals.data.player2AI = value;
	}
	
	public void DataWriteCameraTrackBall(bool value){
		Globals.data.trackBall = value;
	}
	
	public void DataWriteCameraVertical(bool value){
		Globals.data.vertical = value;
	}

	public void DataWritePlayerLives(float value){
		Globals.data.initialLives = Mathf.RoundToInt(value);
	}

	public void DataWritePlayerLivesField(UnityEngine.UI.InputField field){
		if (field.text.Length > 0) {
			Globals.data.initialLives = int.Parse (field.text);
		} else {
			Globals.data.initialLives = 1;
		}
	}
}
