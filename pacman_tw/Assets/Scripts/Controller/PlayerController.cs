using UnityEngine;
using System.Collections;

public class PlayerController : PlayerElement {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (globalVariables.gameStarted) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				Vector3 ballPos = app.view.pacman.transform.position;
				ballPos.x -= 0.2f;
				app.view.pacman.transform.position = ballPos;
			
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				Vector3 ballPos = app.view.pacman.transform.position;
				ballPos.x += 0.2f;
				app.view.pacman.transform.position = ballPos;
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				Vector3 ballPos = app.view.pacman.transform.position;
				ballPos.z += 0.2f;
				app.view.pacman.transform.position = ballPos;
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				Vector3 ballPos = app.view.pacman.transform.position;
				ballPos.z -= 0.2f;
				app.view.pacman.transform.position = ballPos;
			}
		
		}
	}
}
