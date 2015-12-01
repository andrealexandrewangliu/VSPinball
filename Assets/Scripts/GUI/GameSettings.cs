using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {
	public GameObject player1PlayerCheckmark;
	public GameObject player1AICheckmark;
	public GameObject player2PlayerCheckmark;
	public GameObject player2AICheckmark;

	public GameObject unlimitedCheckmark;
	public GameObject livesCheckmark;
	public UnityEngine.UI.InputField livesInputField;

	// Use this for initialization
	void Start () {
		UpdateToggles ();
	}
	
	
	public void UpdateToggles(){
		bool p1AI = Globals.data.player1AI;
		bool p2AI = Globals.data.player2AI;
		int lives = Globals.data.initialLives;
		
		player1PlayerCheckmark.SetActive (!p1AI);
		player1AICheckmark.SetActive (p1AI);

		player2PlayerCheckmark.SetActive (!p2AI);
		player2AICheckmark.SetActive (p2AI);
		
		
		unlimitedCheckmark.SetActive (lives <= 0);
		livesCheckmark.SetActive (lives > 0);
		livesInputField.interactable = lives > 0;
		if (livesInputField.interactable) {
			livesInputField.text = lives.ToString ();
		} else {
			livesInputField.text = "3";
		}
	}
}
