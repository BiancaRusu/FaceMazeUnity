using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Vector3 position = this.transform.position;
			position.x-=0.1f;
			this.transform.position = position;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			Vector3 position = this.transform.position;
			position.x+=0.1f;
			this.transform.position = position;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			Vector3 position = this.transform.position;
			position.z+=0.1f;
			this.transform.position = position;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			Vector3 position = this.transform.position;
			position.z-=0.1f;
			this.transform.position = position;
		}
			
	}
}
