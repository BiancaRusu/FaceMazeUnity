using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinController : MonoBehaviour {
	// Use this for initialization
	GameObject text;

	void Start () {

		text = GameObject.Find ("score_value");
		this.transform.Rotate (Vector3.up * Random.Range (0f, 180f), Space.World);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (Vector3.up * 1f, Space.World);
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "pacman") {
			globalVariables.score++;
			globalVariables.totalScore++;
			text.GetComponentInChildren<Text> ().text = globalVariables.totalScore.ToString();
			this.gameObject.SetActive (false);
			Destroy (this);
		}
			

	}
}
