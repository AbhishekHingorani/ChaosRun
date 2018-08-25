using UnityEngine;
using System.Collections;

public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;

	void Start ()
	{
		this.gameObject.SetActive (false);
	}

	public void RestartGame()
	{
		FindObjectOfType<GameManager> ().Reset ();
	}

	public void QuitToMain()
	{
		Application.LoadLevel (mainMenuLevel);
	}
		
}
