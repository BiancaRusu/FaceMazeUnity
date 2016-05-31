using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
	GameObject pacmanJPG;
	// Use this for initialization
	void Start () {
		pacmanJPG = GameObject.Find ("pacmanJPG");

	}
	// Update is called once per frame
	void Update () { 

		if (Input.GetKey (KeyCode.LeftArrow)) {
			Vector3 ballPos = this.transform.position;
			ballPos.x -= 0.1f;
			this.transform.position = ballPos;

			Vector3 photoPos = new Vector3 (ballPos.x, 3.5f, ballPos.z);
			pacmanJPG.transform.position = photoPos;
		
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			Vector3 ballPos = this.transform.position;
			ballPos.x += 0.1f;
			this.transform.position = ballPos;

			Vector3 photoPos = new Vector3 (ballPos.x, 3.5f, ballPos.z);
			pacmanJPG.transform.position = photoPos;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			Vector3 ballPos = this.transform.position;
			ballPos.z += 0.1f;
			this.transform.position = ballPos;

			Vector3 photoPos = new Vector3 (ballPos.x, 3.5f, ballPos.z);
			pacmanJPG.transform.position = photoPos;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			Vector3 ballPos = this.transform.position;
			ballPos.z -= 0.1f;
			this.transform.position = ballPos;

			Vector3 photoPos = new Vector3 (ballPos.x, 3.5f, ballPos.z);
			pacmanJPG.transform.position = photoPos;
		}
		Vector3 photoPosUnpressed = new Vector3 (this.transform.position.x, 3.5f, this.transform.position.z);
		pacmanJPG.transform.position = photoPosUnpressed;
	}
}
