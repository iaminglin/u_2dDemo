using UnityEngine;
using System.Collections;

public class setSortingLayer : MonoBehaviour {


	public string sortingLayerName;

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem> ().GetComponent<Renderer> ().sortingLayerName = sortingLayerName;
	}

}
