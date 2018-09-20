using UnityEngine;
using System.Collections;

public class GameManager: MonoBehaviour {
	public static GameManager Instance{ get; private set;}

	public enum GameState{Menu,Playing, Dead, Finish};
	public GameState State{ get; set; }

	[Header("Floating Text")]
	public GameObject FloatingText;
	private MenuManager menuManager;

	public Dots Player{ get; private set;}
	SoundManager soundManager;

	void Awake(){
		Instance = this;
		State = GameState.Menu;
		Player = FindObjectOfType<Dots> ();
	}


	public int Point{ get; set; }

	public void AddPoint(int addpoint){
		Point += addpoint;
	}

	public int SavedBest { 
		get { return PlayerPrefs.GetInt (GlobalValue.Best, 0); } 
		set { PlayerPrefs.SetInt (GlobalValue.Best, value); } 
	}


	void Start(){
		menuManager = FindObjectOfType<MenuManager> ();

		soundManager = FindObjectOfType<SoundManager> ();

		if (GlobalValue.isRestart)
			MenuManager.Instance.StartGame ();
	}

	public void ShowFloatingText(string text, Vector2 positon, Color color){
		GameObject floatingText = Instantiate (FloatingText) as GameObject;
		var _position = Camera.main.WorldToScreenPoint (positon);

		floatingText.transform.SetParent (menuManager.transform,false);
		floatingText.transform.position = _position;
			
		var _FloatingText = floatingText.GetComponent<FloatingText> ();
		_FloatingText.SetText (text, color);
	}

	public void StartGame(){
		State = GameState.Playing;

//		AdsController.HideAds ();
	}

	public void GameOver(){
		State = GameState.Dead;
		MenuManager.Instance.GameOver ();
		SoundManager.PlaySfx (soundManager.soundGameover, 0.5f);

		if (Point > SavedBest)
			SavedBest = Point;

//		AdsController.ShowAds ();
	}
}
