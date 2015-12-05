using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	public float HP = 2f;
	public float moveSpeed = 2f;
	public Sprite deadSprite;
	public Sprite hurtSprite;
	public GameObject score;
	public AudioClip[] deathClips;
	public float onceHurt = 10f;
	public float getScore = 100f;

	private bool isDead;
	private Transform frontCheck;
	private SpriteRenderer render;
	private scoreManager scoreM;
//	private GameObject scoreManager;

	void Awake(){
		render = transform.Find("body").GetComponent<SpriteRenderer> ();
		frontCheck = transform.Find ("frontCheck").transform;
		scoreM = GameObject.Find ("score").GetComponent<scoreManager> ();;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Collider2D[] cols = Physics2D.OverlapPointAll (frontCheck.position,1);
		foreach(Collider2D col in cols){
			if(col.tag == "obstacle"){
				Flip();
				break;
			}
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(transform.localScale.x)*moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		if (HP == 1 && hurtSprite != null) {
			render.sprite = hurtSprite;
		}
		if (HP <= 0 && !isDead) {
			Death();
			isDead = true;
		}
	}

	public void Hurt(){
		HP--;
	}

	void Death(){
		SpriteRenderer[] renders = GetComponentsInChildren<SpriteRenderer> ();
		foreach (SpriteRenderer ren in renders) {
			ren.enabled = false;
		}
		render.enabled = true;
		render.sprite = deadSprite;
		Collider2D[] cols = GetComponents<Collider2D> ();
		foreach (Collider2D col in cols) {
			col.isTrigger = true;
		}
		Vector3 scorePos = transform.position + new Vector3 (0,1,0);
		Instantiate (score,scorePos,Quaternion.identity);
		scoreM.score += getScore;
		AudioSource.PlayClipAtPoint (deathClips[Random.Range(0,deathClips.Length)],transform.position);
	}

	public void Flip(){
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
		if (transform.name == "smallEnemy") {
			Debug.Log(transform.localScale);
		}
	}
}
