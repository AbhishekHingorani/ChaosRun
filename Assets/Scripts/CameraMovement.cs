using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

    private Vector2 velocity;
    public float delayCameraX;
    public float delayCameraY;

    public bool setBounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    public GameObject player;

    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        //To make the camera follow the character with some delay
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, delayCameraX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, delayCameraY);

        transform.position = new Vector3(posX, posY, transform.position.z);
        //--------------------------------------------------------------------------------------------------------------

        //To limit where camera can go.
        if (setBounds == true)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, transform.position.x + 10f), Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y), Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
}