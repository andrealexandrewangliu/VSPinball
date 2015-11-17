using UnityEngine;
using System.Collections;

public class LifeCounter : RoundUpdateable {
	public bool player1 = true;

	// Use this for initialization
	void Start () {
		UpdateCounter ();
	}

	public void UpdateCounter (){
		int lives;
		if (player1) {
			lives = Globals.player1Lives;
		} else {
			lives = Globals.player2Lives;
		}

		if (lives >= 0) {
			GetComponent<UnityEngine.UI.Text> ().text = lives.ToString ();
		} else {
			//GetComponent<UnityEngine.UI.Text> ().text = "∞";
			GetComponent<UnityEngine.UI.Text> ().text = (lives + 1).ToString ();
		}
	}

	#region implemented abstract members of RoundUpdateable

	public override void RoundUpdate ()
	{
		UpdateCounter ();
	}

	#endregion
}
