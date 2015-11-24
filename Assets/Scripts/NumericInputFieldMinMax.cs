using UnityEngine;
using System.Collections;

public class NumericInputFieldMinMax : MonoBehaviour {
	public UnityEngine.UI.InputField field;
	public int min;
	public int max;

	public void OnValueChange(){
		string txtValue = field.text;
		if (txtValue.Length > 0) {
			int intValue = int.Parse(txtValue);
			if (intValue > max)
				field.text = max.ToString();
			else if (intValue < min)
				field.text = min.ToString();
		} else {
			field.text = min.ToString();
		}
	}
}
