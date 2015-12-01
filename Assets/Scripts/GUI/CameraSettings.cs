using UnityEngine;
using System.Collections;

public class CameraSettings : MonoBehaviour {
	public GameObject horizontalCheckmark;
	public UnityEngine.UI.Image horizontalHighlight; 
	public GameObject verticalCheckmark;
	public UnityEngine.UI.Image verticalHighlight; 
	public GameObject zoomCheckmark;
	public GameObject trackCheckmark;


	// Use this for initialization
	void Start () {
		UpdateToggles ();
	}

	public void UpdateToggles(){
		bool vertical = Globals.data.vertical;
		bool track = Globals.data.trackBall;

		horizontalCheckmark.SetActive (!vertical);
		horizontalHighlight.enabled = !vertical;
		verticalCheckmark.SetActive (vertical);
		verticalHighlight.enabled = vertical;
		
		zoomCheckmark.SetActive (!track);
		trackCheckmark.SetActive (track);
	}
}
