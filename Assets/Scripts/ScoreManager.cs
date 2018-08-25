using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text ScoreText;
	public Text HighScoreText;
	public float scoreCount,highScoreCount,pointsPerSecond;
	public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
		scoreIncreasing = true;

        if (PlayerPrefs.HasKey("highscore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("highscore");
        }
	}
	
	// Update is called once per frame
	void Update () {

		if(scoreIncreasing)
			scoreCount += pointsPerSecond * Time.deltaTime;

		if (scoreCount > highScoreCount) {
			highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("highscore", highScoreCount);
		}

		ScoreText.text = "Score : " + Mathf.Round(scoreCount);
		HighScoreText.text = "High Score : " +  Mathf.Round(highScoreCount);

	}

	public void AddScore(int pointsToAdd)
	{
		scoreCount += pointsToAdd;
	}
}
