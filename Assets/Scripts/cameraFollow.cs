using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	public float minXMargin = 1f;
	public float minYMargin = 1f;

	public float xSmooth = 2f;
	public float ySmooth = 2f;

	public Vector2 minXAndY;
	public Vector2 maxXAndY;


	private Transform player;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float x = transform.position.x;
		float y = transform.position.y;
		if (isGreaterMinXMargin ()) {
			x = Mathf.Lerp(transform.position.x,player.position.x,xSmooth*Time.deltaTime);
		}
		if (isGreaterMinYMargin ()) {
			y = Mathf.Lerp(transform.position.y,player.position.y,ySmooth*Time.deltaTime);
		}
		x = Mathf.Clamp (x, minXAndY.x, maxXAndY.x);
		y = Mathf.Clamp (y, minXAndY.y, maxXAndY.y);
		transform.position = new Vector3 (x,y,transform.position.z);
	}


	#region Mathod
	bool isGreaterMinXMargin(){
		return (Mathf.Abs (transform.position.x - player.position.x) > minXMargin);
	}
	bool isGreaterMinYMargin(){
		return (Mathf.Abs (transform.position.y - player.position.y) > minYMargin);
	}
	#endregion

}
