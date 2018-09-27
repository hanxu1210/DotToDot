using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	Dots player;
	public float smoothFollow = 0.1f;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Dots> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z), smoothFollow);

	}
}
