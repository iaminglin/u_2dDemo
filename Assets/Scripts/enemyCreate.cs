using UnityEngine;
using System.Collections;

public class enemyCreate : MonoBehaviour {


	public float spawnTime = 5f;
	public float spawnDelay = 5f;
	public GameObject[] enemies;

	private ParticleSystem p;
	// Use this for initialization
	void Start () {
		p = GetComponentInChildren<ParticleSystem> ();
		InvokeRepeating ("Spawner",5,4);
	}
	
	void Spawner(){
		int enemyIndex = Random.Range (0,enemies.Length);
		bool isFaceRight = Random.Range (0,2)==0;
		GameObject obj = Instantiate (enemies[enemyIndex],transform.position,Quaternion.identity) as GameObject;
		if (!isFaceRight) {
			Vector3 scale = obj.transform.localScale;
			scale.x*=-1;
			obj.transform.localScale = scale;
		}
		if (p != null)
			p.Play ();
	}
}
