using UnityEngine;
using System.Collections;

public class PlatformDestroyes : MonoBehaviour {
    public GameObject DestructionPoint;
	
	void Start () {
        DestructionPoint = GameObject.Find("DestructionPoint");
	}
	
	void Update () {
        if (transform.position.x < DestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
	}
}
