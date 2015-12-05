using UnityEngine;
using System.Collections;

public class healthPickup : MonoBehaviour {

	public float addHealthNum = 30;
	public AudioClip pickupClip;
	
	private bool isLand = false;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = transform.root.GetComponent<Animator> ();
	}
	
	void OnTriggerEnter2D(Collider2D col){
		
		// use trigger because when player jump no force
		if (col.tag == "Player") {
			AudioSource.PlayClipAtPoint(pickupClip,col.transform.position);
			col.GetComponent<healthController>().Health+=addHealthNum;
			Destroy(transform.root.gameObject);
		}else if(col.tag == "ground" && !isLand){
			animator.SetTrigger("isLand");
			transform.parent = null;
			gameObject.AddComponent<Rigidbody2D>();
			isLand = true;
		}
	}
}
