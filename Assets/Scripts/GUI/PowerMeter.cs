using UnityEngine;
using System.Collections;

public class PowerMeter : MonoBehaviour {
	public ObserveableMeter observeable;
	public UnityEngine.UI.Image meter;
	
	// Update is called once per frame
	void Update () {
		if (meter != null && observeable != null) {
			meter.fillAmount = observeable.FillAmmount ();
		}
	}
}
