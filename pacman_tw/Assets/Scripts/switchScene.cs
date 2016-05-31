using UnityEngine;
using System.Collections;

public class switchScene : MonoBehaviour {

	// Use this for initialization
	public void Button_Click () {
		Application.LoadLevel ("labyrinth");
		Destroy (this);
	}
		
}
