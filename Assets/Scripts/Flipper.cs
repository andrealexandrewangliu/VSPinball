using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {
	public string key;
	public string altKey;
	public float baseRotation = 0;
	public float flipperRotation = 90;
	public float rotationSpeed = 1440;
	private bool wasKeyDown = false;
	private float targetRotation = 0;

	void Start(){
		targetRotation = baseRotation;
	}
	
	void LateUpdate () 
	{
		float isKeyDown;
		if (Globals.data.vertical)
			isKeyDown = Input.GetAxis (key);
		else
			isKeyDown = Input.GetAxis (altKey);
		float currentRotation = GetComponent<Rigidbody2D>().rotation;
		if (isKeyDown > 0) {
			if (!wasKeyDown) {
				wasKeyDown = true;
				targetRotation = flipperRotation;
			}
		} else {
			if (wasKeyDown) {
				wasKeyDown = false;
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
