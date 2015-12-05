using UnityEngine;
using System.Collections;

public class goodsCreateManager : MonoBehaviour {

	public float minX;
	public float maxX;
	public float y;
	public GameObject[] pickupGoods;
	public float startTime;
	public float repeatDelay;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", startTime, repeatDelay);
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}

	void Spawn(){
		int index = Random.Range (0,pickupGoods.Length);
		Vector3 pos = new Vector3 (Random.Range(minX,maxX),y,transform.position.z);
		Instantiate (pickupGoods [index], pos, Quaternion.identity);
	}
}
