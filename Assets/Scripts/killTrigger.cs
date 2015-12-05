using UnityEngine;
using System.Collections;

public class killTrigger : MonoBehaviour {

	private GameObject healthBar;

	void Awake(){
		healthBar = GameObject.Find ("health");
	}
	// Use this for initialization
	void Start () {

	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			Camera.main.GetComponent<cameraFollow> ().enabled = false;
			if(healthBar.activeSelf){
				healthBar.SetActive(false);
			}
			Destroy (col.transform.root.gameObject);
			StartCoroutine ("ReloadGame");
		} else {
			Destroy (col.transform.root.gameObject);
		}

	}

	IEnumerator ReloadGame(){
		yield return new WaitForSeconds(2f);
		Application.LoadLevel ("2dPlatform");
//		Application.LoadLevel ("CompleteMainScene");
	}
}
