using UnityEngine;
using System.Collections;

public class bgPropSpawner : MonoBehaviour {

	public Rigidbody2D objProp;
	public float leftAppearPosX;
	public float rightAppearPosX;
	public float minY;
	public float maxY;
	public float minAppearCycleTime;
	public float maxAppearCycleTime;
	public float minSpeed;
	public float maxSpeed;
	// Use this for initialization
	void Start () {
		Random.seed = System.DateTime.Today.Millisecond;
		StartCoroutine (Spawner ());
	}
	// Update is called once per frame
	void Update () {
	}

	IEnumerator Spawner(){
		float waitTime = Random.Range (minAppearCycleTime,maxAppearCycleTime);
		yield return new WaitForSeconds(waitTime);

		bool isFaceRight = Random.Range (0, 2) == 0;
		float x = isFaceRight?leftAppearPosX:rightAppearPosX;
		float y = Random.Range (minY,maxY);
		Rigidbody2D rb = Instantiate (objProp,new Vector3(x,y,transform.position.y),Quaternion.identity) as Rigidbody2D;
		if (isFaceRight) {
			Vector3 scale = rb.transform.localScale;
			scale.x*=-1;
			rb.transform.localScale = scale;
		}
		float speed = Random.Range (minSpeed,maxSpeed);
		rb.velocity = new Vector2(isFaceRight?speed:-1*speed,0);
		StartCoroutine (Spawner());
		while (rb!=null) {
			float currentX = rb.transform.position.x;
			if(isFaceRight && currentX>rightAppearPosX+1){
				Destroy(rb.gameObject);
			}else if(!isFaceRight && currentX<leftAppearPosX-1){
				Destroy(rb.gameObject);
			}
			yield return null;
		}

	}
	
}
