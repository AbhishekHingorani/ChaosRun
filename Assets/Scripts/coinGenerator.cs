using UnityEngine;
using System.Collections;

public class coinGenerator : MonoBehaviour {

	public GameObject coin;
	public float randomCoinThreshold;

	public void generateRandomCoins(Vector3 startPosition)
	{
		if (Random.Range (0, 100) > randomCoinThreshold) {
			Instantiate (coin, startPosition, coin.transform.rotation);
			Instantiate (coin, (new Vector3 (startPosition.x - 1.5f, startPosition.y, startPosition.z)), coin.transform.rotation);
			Instantiate (coin, (new Vector3 (startPosition.x + 1.5f, startPosition.y, startPosition.z)), coin.transform.rotation);
		}
	}
}
