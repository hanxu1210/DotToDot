using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	public static MenuManager Instance;

	public GameObject Startmenu;
	public GameObject GUI;
	public GameObject Gameover;

	void Awake(){
		Instance = this;
		Startmenu.SetActive (true);
		GUI.SetActive (false);
		Gameover.SetActive (false);
	}

	public void NextLevel(){
		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
//		LoadingSreen.Show ();
//		SceneManager.LoadSceneAsync (LevelManager.Instance.nextLevelName);
	}

	public void RestartGame(){
		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
//		LoadingSreen.Show ();
		GlobalValue.isRestart = true;
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);
	}

	public void HomeScene(){
		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
		Time.timeScale = 1;
		GlobalValue.isRestart = false;
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);
//		LoadingSreen.Show ();
//		SceneManager.LoadSceneAsync ("MainMenu");

	}

	public void GameOver(){
		Gameover.SetActive (true);
	}

	public void Pause(){
		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
		if (Time.timeScale == 0) {
			GUI.SetActive (true);
			Time.timeScale = 1;
		} else {
			GUI.SetActive (false);
			Time.timeScale = 0;
		}
	}

	public void StartGame(){
		Startmenu.SetActive (false);
		GUI.SetActive (true);

		GameManager.Instance.StartGame ();
	}

}
