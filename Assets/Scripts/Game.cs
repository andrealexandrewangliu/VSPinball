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
	
	public GameObject inGameMenuButton;
	public GameObject blueWinnerMessage;
	public GameObject redWinnerMessage;

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
		
		player2.cannon.aiActive = Globals.data.player2AI;
		player2.left.aiActive = Globals.data.player2AI;
		player2.right.aiActive = Globals.data.player2AI;
		player2.tilt.aiActive = Globals.data.player2AI;
	}

	public void NewGame(){
		int randomInt = Random.Range (0, 2);
		ball.SetActive (true);
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
		ball.SetActive (true);
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

	private void setPlayerSpecificPause(PlayerSpecific player, bool enabled){
		player.cannon.enabled = enabled;
		player.left.enabled = enabled;
		player.right.enabled = enabled;
		player.tilt.enabled = enabled;
		if (enabled) {
			player.left.GetComponent<Rigidbody2D> ().WakeUp ();
			player.right.GetComponent<Rigidbody2D> ().WakeUp ();
		} else {
			player.left.GetComponent<Rigidbody2D> ().Sleep ();
			player.right.GetComponent<Rigidbody2D> ().Sleep ();
		}
	}

	public void Pause(){
		setPlayerSpecificPause(player1,false);
		setPlayerSpecificPause(player2,false);
		ball.GetComponent<BallPhysics> ().Pause();
	}

	public void Resume(){
		setPlayerSpecificPause(player1,true);
		setPlayerSpecificPause(player2,true);
		ball.GetComponent<BallPhysics> ().Resume();
	}

	/** 
	 * Returns:
	 *  - False when the game ends
	 *  - True when the both players are active
	 **/
	public bool CheckWinCondition(){
		if (!Globals.data.isPlayer1Alive ()) {
			RedWin();
			return false;
		}else if (!Globals.data.isPlayer2Alive ()) {
			BlueWin();
			return false;
		}
		return true;
	}

	private void BlueWin(){
		inGameMenuButton.SetActive (false);
		blueWinnerMessage.SetActive (true);
	}
	
	private void RedWin(){
		inGameMenuButton.SetActive (false);
		redWinnerMessage.SetActive (true);
	}
}
