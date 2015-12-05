using UnityEngine;
using System.Collections;

public class appController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
			AppControl.isPause = !AppControl.isPause;
		}
		if (AppControl.isPause) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
}

public class AppControl{
	public static bool isPause = false;
}
