using UnityEngine;
using System.Collections;

public  class GhostTriggerView : GhostTriggerElement {
	

	public GameObject ghostOne;
	public GameObject ghostTwo;
	public GameObject ghostThree;

	public GameObject ghostOnePhoto;
	public GameObject ghostTwoPhoto;
	public GameObject ghostThreePhoto;


	void OnTriggerEnter(Collider other){
		
		app.controller.coliziune (other,ghostOne,ghostTwo,ghostThree,ghostOnePhoto,ghostTwoPhoto,ghostThreePhoto,this.name);
	}

}
