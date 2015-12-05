using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class gunShoot : MonoBehaviour {

	public Rigidbody2D rocketInst;
	public float rocketSpeed = 5f;
	
	private Animator animator;
	private playerController player;
	private Transform trans;
	void Awake(){

	}
	// Use this for initialization
	void Start () {
		animator = transform.root.GetComponent<Animator> ();
		player = transform.root.GetComponent<playerController>();

	}
	
	// Update is called once per frame
	void Update () {
		if (AppControl.isPause) {
			return;
		}
		if (Input.GetButtonDown ("Fire1")) {
			animator.SetTrigger("Shoot");
			GetComponent<AudioSource>().Play();
			if(player.faceRight){
				Rigidbody2D obj = Instantiate(rocketInst,transform.position,Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				obj.velocity = new Vector2(rocketSpeed,0);
			}else{
				Rigidbody2D obj = Instantiate(rocketInst,transform.position,Quaternion.Euler(new Vector3(0,0,180))) as Rigidbody2D;
				obj.velocity = new Vector2(-rocketSpeed,0);
			}
		}
	}

	
	void FixedUpdate(){


	}
}
