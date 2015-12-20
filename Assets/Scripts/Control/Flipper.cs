using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {
	public string key;
	public string altKey;
	public float baseRotation = 0;
	public float flipperRotation = 90;
	public float rotationSpeed = 1440;
	public float aiDelayTime = 0.3f;
	public bool aiActive = true;
	public TriggerZone aiRadar;
	public AudioClip clipFlipUp;
	public AudioClip clipFlipDown;
	public AudioSource audioSource;
	private bool wasKeyDown = false;
	private float targetRotation = 0;
	private float aiDelay = 0;

	void Start(){
		targetRotation = baseRotation;
	}
	
	void LateUpdate () 
	{
		if (aiActive) {
			AiFlip();
		} else {
			ManualFlip();
		}
	}
	
	private void AiFlip(){
		bool isKeyDown = aiRadar.isTriggerActive();
		if (aiDelay == 0 && isKeyDown) {
			aiDelay = aiDelayTime;
		} else {
			if (aiDelay > 0) {
				isKeyDown = true;
				aiDelay -= Time.deltaTime;
				if (aiDelay <= 0)
					aiDelay = -aiDelayTime;
			} else if (aiDelay < 0) {
				isKeyDown = false;
				aiDelay += Time.deltaTime;
				if (aiDelay >= 0)
					aiDelay = 0;
			}
		}

		float currentRotation = GetComponent<Rigidbody2D>().rotation;
		if (isKeyDown) {
			if (!wasKeyDown) {
				wasKeyDown = true;
				audioSource.PlayOneShot(clipFlipUp);
				targetRotation = flipperRotation;
			}
		} else {
			if (wasKeyDown) {
				wasKeyDown = false;
				audioSource.PlayOneShot(clipFlipDown);
				targetRotation = baseRotation;
			}
		}
		
		
		if (currentRotation > targetRotation) {
			currentRotation -= rotationSpeed * Time.deltaTime;
			if (currentRotation < targetRotation)
				currentRotation = targetRotation;
			GetComponent<Rigidbody2D>().MoveRotation(currentRotation);
			
		}
		else if (currentRotation < targetRotation) {
			currentRotation += rotationSpeed * Time.deltaTime;
			if (currentRotation > targetRotation)
				currentRotation = targetRotation;
			GetComponent<Rigidbody2D>().MoveRotation(currentRotation);
		}
	}

	private void ManualFlip(){
		float isKeyDown;
		if (Globals.data.vertical)
			isKeyDown = Input.GetAxis (key);
		else
			isKeyDown = Input.GetAxis (altKey);
		float currentRotation = GetComponent<Rigidbody2D>().rotation;
		if (isKeyDown > 0) {
			if (!wasKeyDown) {
				wasKeyDown = true;
				audioSource.PlayOneShot(clipFlipUp);
				targetRotation = flipperRotation;
			}
		} else {
			if (wasKeyDown) {
				wasKeyDown = false;
				audioSource.PlayOneShot(clipFlipDown);
				targetRotation = baseRotation;
			}
		}
		
		
		if (currentRotation > targetRotation) {
			currentRotation -= rotationSpeed * Time.deltaTime;
			if (currentRotation < targetRotation)
				currentRotation = targetRotation;
			GetComponent<Rigidbody2D>().MoveRotation(currentRotation);
			
		}
		else if (currentRotation < targetRotation) {
			currentRotation += rotationSpeed * Time.deltaTime;
			if (currentRotation > targetRotation)
				currentRotation = targetRotation;
			GetComponent<Rigidbody2D>().MoveRotation(currentRotation);
		}
	}
}
