using UnityEngine;
using System.Collections;

public class Dots : MonoBehaviour {
	[HideInInspector]
	public Transform rotateAroundThis;
	public Transform DotID1;
	public Transform DotID2;

	public float radius = 0.3f;
	public LayerMask targetLayer;

	public float PerfectDistance = 0.1f;

	[Header("Hard")]
	public float speed1 = 150;
	public int nextSpeed2Points = 75;
	public float speed2 = 180;
	public int nextSpeed3Points = 150;
	public float speed3 = 230;
	public int nextSpeed4Points = 250;
	public float speed4 = 260;
	public int nextSpeed5Points = 400;
	public float speed5 = 300;

	float speed;

	[Header("Sound")]
	public AudioClip soundCatched;
	[Range(0,1)]
	public float soundCatchedVolume = 1;
	public AudioClip soundFail;
	[Range(0,1)]
	public float soundFailVolume = 1;
	public AudioClip soundPerfect;
	[Range(0,1)]
	public float soundPerfectVolume = 1;

	int usingDotID;
	bool isGameOver = false;

//	public float currentRotateAngle = 0;

	// Use this for initialization
	void Awake () {
		rotateAroundThis = DotID1;
		usingDotID = 1;
		speed = speed1;
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameOver)
			return;

		if (GameManager.Instance.Point > nextSpeed5Points)
			speed = speed5;
		else if(GameManager.Instance.Point > nextSpeed4Points)
			speed = speed4;
		else if(GameManager.Instance.Point > nextSpeed3Points)
			speed = speed3;
		else if(GameManager.Instance.Point > nextSpeed2Points)
			speed = speed2;
		
		
		transform.RotateAround (rotateAroundThis.position, Vector3.forward, speed * Time.deltaTime);



//		if (GameManager.Instance.State == GameManager.GameState.Playing) {
//			currentRotateAngle += speed * Time.deltaTime;
//			if (currentRotateAngle > 400)
//				GameOver ();
//		}

#if UNITY_EDITOR
	if (Input.anyKeyDown && GameManager.Instance.State == GameManager.GameState.Playing) {
#else
	if (KeyboardHandler.IsOkButtonDown() && GameManager.Instance.State == GameManager.GameState.Playing) {
#endif
			var Dot = usingDotID == 1 ? DotID2 : DotID1;

			var hit = Physics2D.CircleCast (Dot.position, radius, Vector2.zero, 0, targetLayer);
			if (hit)
				CatchedTarget (hit, usingDotID == 1 ? 2 : 1);
			else
				GameOver(); // Gameover

//			currentRotateAngle = 0;

		}
	}

	void CatchedTarget(RaycastHit2D hit, int catchedID){
		
		float distanceDotToTarget;

		if (catchedID == 1) {
			rotateAroundThis = DotID1;
			distanceDotToTarget = Vector2.Distance (DotID1.position, hit.collider.transform.position);
		} else {
			rotateAroundThis = DotID2;
			distanceDotToTarget = Vector2.Distance (DotID2.position, hit.collider.transform.position);
		}

		usingDotID = catchedID;

		//check and Spawn perfect fx
		var isPerfect = distanceDotToTarget <= PerfectDistance;
		if (isPerfect) {
			SoundManager.PlaySfx (soundPerfect, soundPerfectVolume);
		} else
			SoundManager.PlaySfx (soundCatched, soundCatchedVolume);
		
		DotSpawner.Instance.Spawn (isPerfect);

	}

	void GameOver(){
		SoundManager.PlaySfx (soundFail,soundFailVolume);
		isGameOver = true;

		GameManager.Instance.GameOver ();
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (DotID1.position, radius);
		Gizmos.DrawWireSphere (DotID2.position, radius);
	}
}
