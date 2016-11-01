using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene (0);
		}
	}
}
