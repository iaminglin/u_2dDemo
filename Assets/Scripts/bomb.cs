using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {

	public float fuseTime = 1.5f;
	public float bombForce = 100f;
	public AudioClip bombClip;
	public AudioClip fuseClip;
	public GameObject explosion;

	private ParticleSystem explosionSpark;

	void Awake(){
		explosionSpark = GameObject.Find ("explosionSpark").GetComponent<ParticleSystem>();
	}

	// Use this for initialization
	void Start () {
		if (transform.root == transform) {
			StartCoroutine(BombDetonation());
		}
	}
	
	IEnumerator BombDetonation(){
		AudioSource.PlayClipAtPoint (fuseClip,transform.position);

		yield return new WaitForSeconds(fuseTime);
		Explode ();

	}

	public void Explode(){
		Instantiate (explosion, transform.position, Quaternion.identity);
		explosionSpark.transform.position = transform.position;
		explosionSpark.Play ();
		AudioSource.PlayClipAtPoint (bombClip,transform.position);
		Collider2D[] enemise = Physics2D.OverlapCircleAll(transform.position,10,1<<LayerMask.NameToLayer("Enemy"));
		foreach (Collider2D enemy in enemise) {
			Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
			if(rb!=null){
				Vector3 force = (rb.transform.position - transform.position).normalized * bombForce;
				rb.AddForce(force);
				rb.GetComponent<enemy>().HP=0;
			}
		}
		Destroy (gameObject);
	}
}
