using UnityEngine;
using System.Collections;

public class rocket : MonoBehaviour {

	public GameObject expolsion;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "enemy") {
			Expolde();
			col.GetComponent<enemy>().Hurt();
			Destroy (gameObject);
		} else if (col.tag == "bombPickup") {
			col.GetComponent<bomb> ().Explode ();
			Destroy (col.transform.root.gameObject);
			Destroy (gameObject);
		} else if (col.tag == "healthPickup") {
			Expolde();
			Destroy (col.transform.root.gameObject);
			Destroy (gameObject);
		} else if (col.tag != "Player") {
			Expolde();
			Destroy(gameObject);
		}
	}

	#region Method
	void Expolde(){
		Quaternion rotation = Quaternion.Euler (new Vector3(0f,0f,Random.Range(0,360f)));
		Instantiate(expolsion,transform.position,rotation);
	}
	#endregion

}
