using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class MainMenuGameOver : MonoBehaviour {
	public Text bestTxt;
	public string facebookLink = "Your link";

	// Use this for initialization
	void Start () {
		bestTxt.text = "BEST: " + GameManager.Instance.SavedBest;
	}

	public void Facebook(){
		Application.OpenURL (facebookLink);
	}
}
