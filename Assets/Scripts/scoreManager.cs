using UnityEngine;
using System.Collections;

public class scoreManager : MonoBehaviour {
	[SerializeField]
	private  float _score = 0;
	public float score {
		get{return _score;}
		set{
			_score = value;
			if(scoreGUI==null){
				scoreGUI = GetComponent<GUIText> ();
			}
			scoreGUI.text = "Score:"+_score.ToString();
			if(scoreshadowGUI == null){
				scoreshadowGUI = GameObject.Find("scoreshadow").GetComponent<GUIText>();
			}
			scoreshadowGUI.text = scoreGUI.text;
			if(score>0){
				player.StartCoroutine(player.Taunt());
			}
		}
	}

	private GUIText scoreGUI;
	private GUIText scoreshadowGUI;
	private playerController player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<playerController> ();;
		scoreGUI = GetComponent<GUIText> ();
		scoreGUI.text = "Score:" + score.ToString ();
		scoreshadowGUI = GameObject.Find("scoreshadow").GetComponent<GUIText>();
		scoreshadowGUI.text = scoreGUI.text;
	}
	
	// Update is called once per frame
	void Update () {
//		scoreGUI.text = "Score:" + score.ToString ();
//		scoreGUI.text = "Score:"+score.ToString();
	}
}
