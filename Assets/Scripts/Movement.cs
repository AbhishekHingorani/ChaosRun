 using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float playerSpeed = 10f, jumpForce = 10f, speedMultiplier,speedIncreaseMilestone;
    public float maxSpeed=0.5f;
    public bool isOnGround;
	//private bool stoppedJumping;// canDoubleJump;
	public float jumpTime;
	private float jumpTimeCounter, speedMilestoneCount;
	private float playerSpeedStore,speedMilestoneCountStore, speedIncreaseMilestoneStore;

	public Transform groundCheck;
	public float groundCheckRadius;
    public LayerMask whatIsGround;
    private Rigidbody2D rbd;
    private Animator anim;

	public AudioSource jumpSound, DeathSound;

	public GameManager theGameManager;
    //private Collider2D myCollider;

    // Use this for initialization
    void Start () {
        //myCollider = GetComponent<Collider2D>();
        rbd = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;

		playerSpeedStore = playerSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }
	
	// Update is called once per frame
	void Update () {
        //isOnGround = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
		isOnGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);
		anim.SetFloat("speed", Mathf.Abs(rbd.velocity.x));
        anim.SetBool("Grounded", isOnGround);
	}

    void FixedUpdate()
    {
		if (transform.position.x > speedMilestoneCount) {
			speedMilestoneCount += speedIncreaseMilestone;    //taking milestone position further
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;  //As the player speeds up he can get to milestone quicker than before, therefore increasing milestone value.
			playerSpeed *= speedMultiplier;   //increasing player speed.	
		}
		
        rbd.velocity = new Vector2(playerSpeed, rbd.velocity.y); //player running

        if (rbd.velocity.x >= maxSpeed)
            rbd.velocity = new Vector2(maxSpeed, rbd.velocity.y);   //Limiting player's speed to maxSpeed

		if (Input.GetKeyDown(KeyCode.Space) || (Input.GetTouch(0).phase == TouchPhase.Began))
        {
			if (isOnGround) {
				rbd.velocity = new Vector2 (rbd.velocity.x, jumpForce);   //Normal jump when user presses space bar
				jumpSound.Play();
			}
        }

		if (Input.GetKey (KeyCode.Space) || ((Input.GetTouch(0).phase == TouchPhase.Moved) || (Input.GetTouch(0).phase == TouchPhase.Stationary)))
		{
			if (jumpTimeCounter > 0) {
				rbd.velocity = new Vector2 (rbd.velocity.x, jumpForce); //Long jump if user holds space bar
				jumpTimeCounter -= Time.deltaTime;
			}
		}

        if (Input.GetKeyUp(KeyCode.Space) || (Input.GetTouch(0).phase == TouchPhase.Ended))
        {
			jumpTimeCounter = 0;
		}
		if (isOnGround) {
			jumpTimeCounter = jumpTime;
		}    
	}

    void OnCollisionEnter2D(Collision2D hit)
    {
		if (hit.gameObject.tag == "Killer") {
			theGameManager.RestartGame ();
			playerSpeed = playerSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			DeathSound.Play ();
		}
    }



}
