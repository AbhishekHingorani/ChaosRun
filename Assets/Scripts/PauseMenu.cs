using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;
	public GameObject pauseMenu;

	void Start ()
	{
		pauseMenu.SetActive (false);
	}
		
	void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.Escape)){
			PauseGame ();
		}
	}

	public void RestartGame()
	{
		Time.timeScale = 1f;
		FindObjectOfType<GameManager> ().Reset ();
		pauseMenu.SetActive (false);
	}

	public void QuitToMain()
	{
		Time.timeScale = 1f;
		Application.LoadLevel (mainMenuLevel);
	}

	public void PauseGame()
	{
		pauseMenu.SetActive (true);
		Time.timeScale = 0f;

	}

	public void ResumeGame()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
	}

}
