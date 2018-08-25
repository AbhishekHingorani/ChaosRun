using UnityEngine;
using System.Collections;

public class pickupCoins : MonoBehaviour {

	public int scorePerCoin;

	private ScoreManager theScoreManager;

	private AudioSource coinSound;

	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
		coinSound = GameObject.Find ("CoinPickupSound").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.gameObject.name == "Player")
		{
			theScoreManager.AddScore (scorePerCoin);
			Destroy (gameObject);

			if (coinSound.isPlaying) {
				coinSound.Stop ();
				coinSound.Play ();
			} else {
				coinSound.Play ();
			}
		}
	}
}
