using UnityEngine;
using System.Collections;

public class CameraOrientationLabels : MonoBehaviour {
	public GameObject[] VerticalLabels;
	public GameObject[] HorizontalLabels;
	// Use this for initialization
	void Start () {
		ToggleLabels ();
	}

	public void ToggleLabels(){
		bool toggle = Globals.data.vertical;
		foreach (GameObject label in VerticalLabels)
			label.SetActive (toggle);
		foreach (GameObject label in HorizontalLabels)
			label.SetActive (!toggle);
		
	}
}
