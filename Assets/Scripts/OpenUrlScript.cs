using UnityEngine;
using System.Collections;

public class OpenUrlScript : MonoBehaviour {

	public void OpenUrl(string URL){
		Application.OpenURL(URL);
	}
}
