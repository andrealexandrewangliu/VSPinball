using UnityEngine;
using System.Collections;

public class Cannon : ObserveableMeter {
	public string key;
	public float maxPower = 350000;
	public float minPower = 250000;
	public float powerGrowth = 350000;
	public Vector2 direction = new Vector2 (0, 1);
	public bool aiActive = true;
	public AudioSource chargeAudioSource;
	public AudioSource shootAudioSource;
	private bool wasKeyDown = false;
	private float power = 0;
	private GameObject ball = null;
	private float targetPower = 0;

	// Use this for initialization
	void Start () {
		direction = direction.normalized;
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		if (aiActive) {
			AiShoot();
		} else {
			ManualShoot();
		}
	
	}
	
	private void AiShoot(){
		bool isBallIn = ball != null;
		if (isBallIn) {
			if (targetPower == 0) {
				targetPower = Random.Range (minPower, maxPower);
			}
			if (!chargeAudioSource.isPlaying){
				chargeAudioSource.Play ();
			}
			power += powerGrowth * Time.deltaTime;
			if (power > maxPower)
				power = maxPower;
			if (power >= targetPower) {
				targetPower = 0;
				ShootBall ();
			}
		} else {
			if (chargeAudioSource.isPlaying){
				chargeAudioSource.Stop();
			}
			power = 0;
		}
	}

	private void ManualShoot(){
		if (key.Length == 0)
			return;
		float isKeyDown = Input.GetAxis (key);
		if (isKeyDown > 0) {
			if (!wasKeyDown) {
				wasKeyDown = true;
			}
			if (!chargeAudioSource.isPlaying){
				chargeAudioSource.Play ();
			}
			power += powerGrowth * Time.deltaTime;
			if (power > maxPower)
				power = maxPower;
		} else {
			if (chargeAudioSource.isPlaying){
				chargeAudioSource.Stop();
			}
			if (wasKeyDown) {
				wasKeyDown = false;
				ShootBall();
			}
		}
	}

	void ShootBall(){
		if (ball != null) {
			Vector2 force = power * direction;
			ball.GetComponent<Rigidbody2D>().AddForce(force);

		}
		//chargeAudioSource.Stop();
		shootAudioSource.Play ();
		power = 0;
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

	#region implemented abstract members of ObserveableMeter
	public override float FillAmmount ()
	{
		return power / maxPower;
	}
	#endregion

}
