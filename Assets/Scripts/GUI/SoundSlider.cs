using UnityEngine;
using System.Collections;

public class SoundSlider : MonoBehaviour {
	public Game gameGameObject;
	public GameObject soundMuteStroke;
	public UnityEngine.UI.Slider soundSlider;

	// Use this for initialization
	void Start () {
		loadSoundSettings ();
	}

	public void loadSoundSettings(){
		soundMuteStroke.SetActive (Globals.data.muteSound);
		soundSlider.value = Globals.data.sound;
	}

	public void setSoundSettings(){
		Globals.data.muteSound = soundMuteStroke.activeSelf;
		Globals.data.sound = soundSlider.value;
		gameGameObject.SetSound ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
