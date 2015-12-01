using UnityEngine;
using System.Collections;

public class TableTilt : ObserveableMeter {
	
	[System.Serializable]
	public class TableTiltKeys 
	{
		public string left;
		public string middle;
		public string right;
	}
	[System.Serializable]
	public class TableTiltAIAreas
	{
		public TriggerZone[] left;
		public TriggerZone[] middle;
		public TriggerZone[] right;
	}
	private enum TiltDirection{
		None,
		Left,
		Middle,
		Right
	}

	public float reloadTime = 10;
	public TableTiltKeys keys;
	public TableTiltKeys altKeys;
	public TableTiltAIAreas aiTiltAreas;
	public bool opposite = false;
	public Animator animations;
	public GameObject ball;
	public float strength;
	public bool aiActive = true;

	private float reloadRemain = 0;

	void LateUpdate () 
	{
		if (reloadRemain > 0) {
			reloadRemain -= Time.deltaTime;
			if (reloadRemain < 0)
				reloadRemain = 0;
		} else {
			TiltDirection direction = TiltDirection.None;

			if (aiActive){
				direction = getAIDirection();
			}
			else{
				direction = getManualDirection();
			}

			if (direction == TiltDirection.Middle) {
				if (opposite){
					ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -strength));
					animations.Play("DownTilt");
				}
				else{
					ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, strength));
					animations.Play("UpTilt");
				}
				reloadRemain = reloadTime;
			}
			else if (direction == TiltDirection.Left) {
				ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-strength, 0));
				animations.Play("LeftTilt");
				reloadRemain = reloadTime;
			}
			else if (direction == TiltDirection.Right) {
				ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(strength, 0));
				animations.Play("RightTilt");
				reloadRemain = reloadTime;
			}
		}
	}

	private TiltDirection getManualDirection(){
		TiltDirection direction = TiltDirection.None;
		float isKeyDown;
		if (Globals.data.vertical) {
			isKeyDown = Input.GetAxis (keys.middle);
			if (isKeyDown > 0){
				direction = TiltDirection.Middle;
			}
			else{
				isKeyDown = Input.GetAxis (keys.right);
				if (isKeyDown > 0){
					direction = TiltDirection.Right;
				}
				else{
					isKeyDown = Input.GetAxis (keys.left);
					if (isKeyDown > 0){
						direction = TiltDirection.Left;
					}
				}
			}
		} else {
			isKeyDown = Input.GetAxis (altKeys.middle);
			if (isKeyDown > 0){
				direction = TiltDirection.Middle;
			}
			else{
				isKeyDown = Input.GetAxis (altKeys.right);
				if (isKeyDown > 0){
					direction = TiltDirection.Right;
				}
				else{
					isKeyDown = Input.GetAxis (altKeys.left);
					if (isKeyDown > 0){
						direction = TiltDirection.Left;
					}
				}
			}
		}
		return direction;
	}

	private TiltDirection getAIDirection(){
		foreach (TriggerZone zone in aiTiltAreas.middle)
			if (zone.isTriggerActive ())
				return TiltDirection.Middle;
		foreach (TriggerZone zone in aiTiltAreas.right)
			if (zone.isTriggerActive ())
				return TiltDirection.Right;
		foreach (TriggerZone zone in aiTiltAreas.left)
			if (zone.isTriggerActive ())
				return TiltDirection.Left;


		return TiltDirection.None;
	}

	#region implemented abstract members of ObserveableMeter
	public override float FillAmmount ()
	{
		return (reloadTime - reloadRemain) / reloadTime;
	}
	#endregion
}
