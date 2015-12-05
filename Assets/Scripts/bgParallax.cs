using UnityEngine;
using System.Collections;

public class bgParallax : MonoBehaviour {

	public Transform[] trans;
	public float parallaxScale = 0.5f;
	public float parallaxReductionFactor = 0.4f;
	public float smoothing = 8f;

	private Transform cam;
	private Vector3 previousCamPos;
	void Awake(){
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		previousCamPos = cam.position;
	}
	
	// Update is called once per frame
	void Update () {
		float parallax = (previousCamPos.x - cam.position.x) * parallaxScale;

		for (int i = 0; i < trans.Length; i++) {
			float targetX = trans[i].position.x+parallax*(parallaxReductionFactor*i+1);
			Vector3 targetPos = new Vector3(targetX,trans[i].position.y,trans[i].position.z);
			trans[i].position = Vector3.Lerp(trans[i].position, targetPos,smoothing*Time.deltaTime);
		}
		previousCamPos = cam.position;
	}
}
