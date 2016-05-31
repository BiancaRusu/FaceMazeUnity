using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {



	// Use this for initialization
	void Start () {
		this.transform.Rotate (Vector3.up * Random.Range (0f, 180f), Space.World);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (Vector3.up * 1f, Space.World);
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "pacman") {
			
			globalVariables.score += 1;
			Debug.Log (globalVariables.score);
			this.gameObject.SetActive (false);
			Destroy (this);

		}
	}
}
