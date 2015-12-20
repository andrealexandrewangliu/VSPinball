using UnityEngine;
using System.Collections;

public class ToggleActiveScript : MonoBehaviour {
	public void ToggleActive(GameObject gameObj){
		gameObj.SetActive (!gameObj.activeSelf);
	}
	
	public void ToggleSelectableInteractable(UnityEngine.UI.Selectable gameObj){
		gameObj.interactable = !gameObj.interactable;
	}
}
