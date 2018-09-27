using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {
	public Text floatingText;
	public float livingTime = 2f; 

	void Start(){
		Destroy (gameObject, livingTime);
	}

	public void SetText(string text, Color color){
		floatingText.color = color;
		floatingText.text = text;
	}
}
