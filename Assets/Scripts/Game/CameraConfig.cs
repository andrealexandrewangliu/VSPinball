using UnityEngine;
using System.Collections;

public class CameraConfig : MonoBehaviour {
	public enum CameraOrientation{
		Vertical,
		Horizontal
	}
	public enum CameraPositioning{
		Center,
		Ball
	}
	public CameraOrientation orientation;
	public CameraPositioning positioning;
	public GameObject ball;
	public float verticalBorder = 17.0f;
	public float horizontalBorder = 14.5f;

	void Start() {
		SetCamera ();
	}

	public void LoadGlobals(){
		if (Globals.data.vertical) {
			orientation = CameraOrientation.Vertical;
		} else {
			orientation = CameraOrientation.Horizontal;
		}
		if (Globals.data.trackBall) {
			positioning = CameraPositioning.Ball;
		} else {
			positioning = CameraPositioning.Center;
		}
	}

	public void SetCamera() {
		if (positioning == CameraPositioning.Center){
			if (orientation == CameraOrientation.Vertical) {
				transform.position = new Vector3 (0,0,-10);
				transform.rotation = Quaternion.identity;
				Camera config = GetComponent<Camera>();
				config.orthographicSize = 25;
			}
			else{
				transform.position = new Vector3 (0,0,-10);
				transform.rotation = Quaternion.identity;
				transform.Rotate(new Vector3(0,0,90));
				Camera config = GetComponent<Camera>();
				config.orthographicSize = 20.2f;
			}
		}
		else{
			if (orientation == CameraOrientation.Vertical) {
				transform.position = new Vector3 (0,ball.transform.position.y,-10);
				transform.rotation = Quaternion.identity;
				Camera config = GetComponent<Camera>();
				config.orthographicSize = 9;
			}
			else{
				transform.position = new Vector3 (0,ball.transform.position.y,-10);
				transform.rotation = Quaternion.identity;
				transform.Rotate(new Vector3(0,0,90));
				Camera config = GetComponent<Camera>();
				config.orthographicSize = 9;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (positioning == CameraPositioning.Ball) {
			float newPosition = ball.transform.position.y;
			if (orientation == CameraOrientation.Vertical){
				if (newPosition < -verticalBorder)
					newPosition = -verticalBorder;
				else if (newPosition > verticalBorder)
					newPosition = verticalBorder;
			}
			else {
				if (newPosition < -horizontalBorder)
					newPosition = -horizontalBorder;
				else if (newPosition > horizontalBorder)
					newPosition = horizontalBorder;
			}
			transform.position = new Vector3 (0,newPosition,-10);
		}
	}
}
