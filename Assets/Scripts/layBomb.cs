using UnityEngine;
using System.Collections;

public class layBomb : MonoBehaviour {

	public float bombNum = 5; 
	public GameObject bomb;
	public AudioClip bombAway;

	private GUITexture bombGui;
	private 
	void Awake(){

	}

	// Use this for initialization
	void Start () {
		bombGui = GameObject.Find ("bombGUI").GetComponent<GUITexture>();
	}
	
	// Update is called once per frame
	void Update () {
		if (AppControl.isPause) {
			return;
		}
		if (Input.GetButtonDown ("Fire2") && bombNum>0) {
			bombNum--;
			AudioSource.PlayClipAtPoint(bombAway,transform.position);
			Instantiate(bomb,transform.position,Quaternion.identity);

		}
		bombGui.enabled = bombNum>0;
	}
}
