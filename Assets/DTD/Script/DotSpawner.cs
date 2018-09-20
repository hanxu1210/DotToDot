using UnityEngine;
using System.Collections;

public class DotSpawner : MonoBehaviour {

	public static DotSpawner Instance;

	public GameObject Dot;
	public Transform SpawnPoint;
	[Range(0,180)]
	public float maxAngle = 45;

	public GameObject PerfectFx;
	int perfectCombo = 0;

	GameObject OldDot;
	GameObject CurrentDot;
	GameObject TargetDot;

	Dots _Dots;

	// Use this for initialization
	void Start () {
		Instance = this;
		_Dots = FindObjectOfType<Dots> ();
		SpawnDot ();
	}


	public void Spawn(bool isPerfect){
		if (isPerfect) {
			perfectCombo++;
			var text = perfectCombo > 1 ? "Perfect X" + perfectCombo : "Perfect";
			GameManager.Instance.ShowFloatingText (text, CurrentDot.transform.position, Color.white);
			GameObject Fx = Instantiate (PerfectFx, CurrentDot.transform.position, Quaternion.identity) as GameObject;
			Fx.transform.SetParent (CurrentDot.transform);
		} else
			perfectCombo = 0;

		//add point
		GameManager.Instance.AddPoint (perfectCombo > 0 ? (perfectCombo + 1):1);

		SpawnDot ();

	}

	void SpawnDot(){
		//offset center
		transform.position = _Dots.rotateAroundThis.position;

		transform.Rotate (Vector3.forward, Random.Range (-maxAngle, maxAngle));
		transform.position = SpawnPoint.position;

		TargetDot = Instantiate (Dot, transform.position, Quaternion.identity) as GameObject;

		if (OldDot != null) {
			OldDot.GetComponent<Animator> ().SetTrigger ("hide");

			if (OldDot.transform.childCount > 0) {
				var Fx = OldDot.transform.GetChild (0);
				if (Fx != null) {
					Fx.GetComponent<Animator> ().SetTrigger ("hide");
					Destroy (Fx.gameObject, 1);
				}
			}

			Destroy (OldDot,1);
		}

		if (CurrentDot != null)
			OldDot = CurrentDot;

		CurrentDot = TargetDot;
	}
}
