// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;

public class Globals {
	public static Globals data = new Globals ();
	public static int player1Lives = -1;
	public static int player2Lives = -1;
	public int initialLives = 3;
	public bool vertical = true;
	public bool trackBall = true;
	public bool player1AI = false;
	public bool player2AI = true;

	public Globals(){
		SetLives();
	}

	public void SetLives(){
		player1Lives = player2Lives = initialLives;
	}

	public void takePlayer1Life(){
		Globals.player1Lives--;
		Globals.RoundUpdate ();
	}
	
	public void takePlayer2Life(){
		Globals.player2Lives--;
		Globals.RoundUpdate ();
	}
	
	public bool isPlayer1Alive(){
		return player1Lives != 0;
	}
	
	public bool isPlayer2Alive(){
		return player2Lives != 0;
	}

	public static void RoundUpdate(){
		UnityEngine.GameObject[] refreshList = UnityEngine.GameObject.FindGameObjectsWithTag ("RoundRefresh");
		foreach (UnityEngine.GameObject refreshObject in refreshList) {
			refreshObject.GetComponent<RoundUpdateable>().RoundUpdate();
		}
	}
}

