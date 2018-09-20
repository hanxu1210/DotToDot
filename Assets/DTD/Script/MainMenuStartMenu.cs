using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuStartMenu : MonoBehaviour {

	public Text soundTxt;
	public string storeLink = "Your store link";

	// Use this for initialization
	void Start () {
		if (AudioListener.volume == 1) {
			soundTxt.text = "Sound: On";
		} else {
			soundTxt.text = "Sound: Off";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Sound(){
		if (AudioListener.volume == 1) {
			AudioListener.volume = 0;
			soundTxt.text = "Sound: Off";
		} else {
			AudioListener.volume = 1;
			soundTxt.text = "Sound: On";
		}
	}

	public void Store(){
		Application.OpenURL (storeLink);
	}
}
