using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float maxSpeed = 10f;
	public float moveForce = 365f;
	public float jumpForce = 1000;
	public AudioClip[] jumpAudioClips;
	public AudioClip[] tauntClips;

	[HideInInspector]
	public bool faceRight = true;
	private Animator animator;
	private bool isJump = false;
	private bool isGround = false;
	private Transform ground;
	void Awake(){

	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		ground = transform.Find ("groundCheck");
	}
	
	// Update is called once per frame
	void Update () {
		isGround = Physics2D.Linecast(transform.position,ground.position,1<<LayerMask.NameToLayer("Ground"));
		if (isGround && Input.GetButtonDown ("Jump"))
			isJump = true;
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		animator.SetFloat ("Speed",Mathf.Abs(h)*10);
		if (h > 0 && !faceRight) {
			Flip();
		}
		if (h < 0 && faceRight) {
			Flip();
		}
		if (Mathf.Abs (h *GetComponent<Rigidbody2D> ().velocity.x) < maxSpeed) {
			GetComponent<Rigidbody2D> ().AddForce(Vector2.right*h*moveForce);

		}
		if (Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x) > maxSpeed) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2( Mathf.Sign(GetComponent<Rigidbody2D> ().velocity.x)*maxSpeed,GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (isJump) {
			isJump = false;
			animator.SetTrigger("Jump");
			int index = Random.Range(0,jumpAudioClips.Length);
			AudioSource.PlayClipAtPoint(jumpAudioClips[index],transform.position);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpForce));
		}

	}


	#region Mathod
	void Flip(){
		faceRight = !faceRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public IEnumerator Taunt(){
		yield return new WaitForSeconds (0.5f);
		int index = Random.Range (0,tauntClips.Length);
		if (!GetComponent<AudioSource> ().isPlaying && tauntClips.Length>0) {
			GetComponent<AudioSource>().clip = tauntClips[index];
			GetComponent<AudioSource>().Play ();
		}
	}
	#endregion
}
