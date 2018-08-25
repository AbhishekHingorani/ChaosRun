using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public PlatformGenerator platformGen;
	public Transform MainCamera;
	public Transform genPoint;
	public Movement thePlayer;
	private Vector3 platformStartPoint;
	private Vector3 CameraStartPoint;
	private Vector3 playerStartPoint;
	private ScoreManager theScoreManager;
	public DeathMenu theDeathMenu;

	void Start () {
		platformStartPoint = platformGen.transform.position;
		playerStartPoint = thePlayer.transform.position;
		CameraStartPoint = MainCamera.position;
		theScoreManager = FindObjectOfType<ScoreManager> ();
	}

	public void RestartGame()
	{
		theDeathMenu.gameObject.SetActive (true);
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);

		//StartCoroutine ("RestartGameCo");
	}

	public void Reset()
	{
		theDeathMenu.gameObject.SetActive (false);
		PlatformDestroyes[] list;
		list = FindObjectsOfType<PlatformDestroyes>();

		foreach (PlatformDestroyes p in list)
			Destroy (p.gameObject);

		thePlayer.transform.position = playerStartPoint;
		platformGen.transform.position = platformStartPoint;
		PlatformGenerator.skyGenPoint = 0f;
		MainCamera.position = CameraStartPoint;
		thePlayer.gameObject.SetActive (true);
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}
		
	/*
	public IEnumerator RestartGameCo()
	{
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (1f);
		PlatformDestroyes[] list;
		list = FindObjectsOfType<PlatformDestroyes>();

		foreach (PlatformDestroyes p in list)
			Destroy (p.gameObject);

		thePlayer.transform.position = playerStartPoint;
		platformGen.transform.position = platformStartPoint;
		PlatformGenerator.skyGenPoint = 0f;
		MainCamera.position = CameraStartPoint;
		thePlayer.gameObject.SetActive (true);
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}
	*/
}