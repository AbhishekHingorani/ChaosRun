using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {
    public GameObject thePlatform;
    public GameObject theSky;
    public Transform generationPoint;
    public float distanceBetween, maxDistanceBetween,minDistanceBetween;
    private float platformWidth;
	private float minHeight,maxHeight, heightChange,maxDist;
	public float maxHeightChange;
	public static float skyGenPoint;

	public Transform MaxHeightPoint;
	private Transform t;
    //public ObjectPooled theObjectPool;   //Creating a obj of the script 'ObjectPooled'


    public GameObject[] thePlatforms;
    private int platformSelector;
	public float[] platformWidths;
	public Transform Player;
	private coinGenerator theCoinGenerator;

	
	void Start () {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x; //To get the size of 'Platform 6x1'.
        
		skyGenPoint = Mathf.Round(generationPoint.position.x + 12.8f);            //To create a sky at 
        Instantiate(theSky, generationPoint.position, generationPoint.rotation); //the start of program.

        platformWidths = new float[thePlatforms.Length];

        for (int i = 0; i < thePlatforms.Length; i++)
        {
            platformWidths[i] = thePlatforms[i].GetComponent<BoxCollider2D>().size.x; //To get the size of platforms added to 'thePlatforms' array
        }

		minHeight = transform.position.y;
		maxHeight = MaxHeightPoint.position.y;
		theCoinGenerator = FindObjectOfType<coinGenerator> ();
	}


    void Update()
    {
        if (transform.position.x < generationPoint.position.x)    //To generate till generationPoint(camera's Child) is out of range of last platform.(current obj on which script is written) is moved forward as new platforms are created. 
        {
			/*if (Player.position.x < 200 && maxDistanceBetween > 3)
				maxDist = 2;
			else*/
				maxDist = maxDistanceBetween;
			
			distanceBetween = Random.Range(minDistanceBetween,maxDist);
            int RandomPlatformSelected = Random.Range(0, thePlatforms.Length);
			//print (RandomPlatformSelected);

			heightChange = transform.position.y + Random.Range(maxHeightChange,-maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			}else if( heightChange < minHeight){
				heightChange = minHeight;
			}
				
			Instantiate(thePlatforms[RandomPlatformSelected], transform.position, transform.rotation);

			theCoinGenerator.generateRandomCoins (new Vector3 (transform.position.x,transform.position.y+1,transform.position.z));

			this.transform.position = new Vector3((transform.position.x + (platformWidths[RandomPlatformSelected]) + distanceBetween), heightChange, transform.position.z);

        }

        if (Mathf.Round(generationPoint.position.x) == skyGenPoint)
        {
            t = new GameObject().transform;             //To keep generating sky.
            t.position = new Vector3(generationPoint.position.x + 12.8f, generationPoint.position.y, generationPoint.position.z);
            
            Instantiate(theSky, t.position, generationPoint.rotation);
            
			skyGenPoint = Mathf.Round (generationPoint.position.x + 25f);
        }
        
	}
}
