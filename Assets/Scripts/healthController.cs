using UnityEngine;
using System.Collections;

public class healthController : MonoBehaviour {

	public float health = 100f;

	public float hurtFore = 100f;
	public AudioClip[] hurtClips;

	public float Health{
		get{return health;}
		set{
			health = value;
			updateHealth();
		}
	}
	private Vector3 healthScale;
	private SpriteRenderer healthBar;
	private Animator anim;
	private float lastHurtTime;
	private float lastStayTime;
	private float repeatDamagePeriod = 1f;
	void Awake(){
		anim = GetComponent<Animator> ();
		healthBar = GameObject.Find ("blood").GetComponent<SpriteRenderer>();
		healthScale = healthBar.transform.localScale;
	}

	// Use this for initialization
	void Start () {
		lastHurtTime = Time.time;
		lastStayTime = Time.time;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.collider.tag == "enemy") {

			if(Time.time>lastHurtTime+repeatDamagePeriod){
				if(health>0){
					Damage(col.collider.GetComponent<enemy>().onceHurt,col.transform);
					lastHurtTime = Time.time;
				}else{
					Death();
				}
			}
		}
	}
	void OnCollisionStay2D(Collision2D col){
		if (col.collider.tag == "enemy") {
			if(Time.time>lastStayTime+repeatDamagePeriod)
			{
				col.transform.GetComponent<enemy>().Flip();
				lastStayTime = Time.time;
			}
		}
	}
	
	void Damage(float hurtNum,Transform enemy){
		Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 5f;
		GetComponent<Rigidbody2D> ().AddForce (hurtVector*hurtFore);
		Health = Mathf.Clamp(Health -hurtNum,0,100);
		AudioSource.PlayClipAtPoint (hurtClips[Random.Range(0,hurtClips.Length)],transform.position);
	}

	void Death(){
		anim.SetTrigger ("Die");
		Collider2D[] cols = GetComponentsInChildren<Collider2D> ();
		foreach (Collider2D col in cols) {
			col.isTrigger = true;
		}
		GetComponent<playerController> ().enabled = false;
		GetComponentInChildren<gunShoot> ().enabled = false;

	}

	void updateHealth(){
		healthBar.color = Color.Lerp (Color.green,Color.red,1-(Mathf.Clamp(health,0,100) * 0.01f));
		healthBar.transform.localScale = new Vector3 (healthScale.x* Mathf.Clamp(health,0,100) * 0.01f,1,1);
	}
}
