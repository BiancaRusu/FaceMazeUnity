using UnityEngine;
using System.Collections;

public class CharactersPositionController : CharactersPositionElement {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		app.view.pacmanPhoto.transform.position = new Vector3 (app.view.pacman.transform.position.x, app.model.yPosition, app.view.pacman.transform.position.z);
		app.view.ghostOnePhoto.transform.position = new Vector3 (app.view.ghostOne.transform.position.x, app.model.yPosition, app.view.ghostOne.transform.position.z);
		app.view.ghostTwoPhoto.transform.position = new Vector3 (app.view.ghostTwo.transform.position.x, app.model.yPosition, app.view.ghostTwo.transform.position.z);
		app.view.ghostThreePhoto.transform.position = new Vector3 (app.view.ghostThree.transform.position.x, app.model.yPosition, app.view.ghostThree.transform.position.z);



	}
}
