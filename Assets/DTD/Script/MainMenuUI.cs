using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

	public Text pointTxt;
	public Animator pointAnim;

	int prePoint;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		pointTxt.text = GameManager.Instance.Point + "";
		if (prePoint != GameManager.Instance.Point) {
			pointAnim.SetTrigger ("add");
		}

		prePoint = GameManager.Instance.Point;
	}
}
