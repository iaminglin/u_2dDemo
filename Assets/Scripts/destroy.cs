using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {

	public bool isDestoryAwake = false;
	public float awakeDestoryDelay = 0.1f;
	public string childName;

	void Awake(){
		if (isDestoryAwake) {
			Destroy(gameObject,awakeDestoryDelay);
		}
	}

	// Use this for initialization
	void Start () {

	}

	void DestroyObject(){
		Destroy (gameObject);
	}

	void DestroyChildObject()
	{
		if (transform.Find (childName).gameObject != null) {
			Destroy(transform.Find (childName).gameObject);
		}

	}
	
}
