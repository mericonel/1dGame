using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

	public Canvas RulesMenu;
	public Button startText;
	public Button rulesText;


	// Use this for initialization
	void Start () {

		RulesMenu = RulesMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		rulesText = rulesText.GetComponent<Button> ();
		RulesMenu.enabled = false;

	
	}

	public void RulesPress(){

		RulesMenu.enabled = true;
		startText.enabled = false;
		rulesText.enabled = false;

	}

	public void BackPress(){

		RulesMenu.enabled = false;
		startText.enabled = true;
		rulesText.enabled = true;

	}

	public void StartLevel(){

		SceneManager.LoadScene (1);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
