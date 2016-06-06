using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManagement : MonoBehaviour {
	public GameObject text;
	public GameObject ghostOne;
	public GameObject ghostTwo;
	public GameObject ghostThree;

	public GameObject ghostOnePhoto;
	public GameObject ghostTwoPhoto;
	public GameObject ghostThreePhoto;

	public GameObject button;

	bool generated;
	// Use this for initialization
	int[,] map = globalVariables.map;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (globalVariables.score == 20) {
			StartCoroutine (nextLevel ());
		}
	}

	public void startGame(){
		if (button.GetComponentInChildren<Text> ().text == "Restart") {
			GameObject youLose = GameObject.FindGameObjectWithTag ("youLose");
			Destroy (youLose);
			StartCoroutine (nextLevel ());
		}else
			if (button.GetComponentInChildren<Text> ().text == "Pause") {
				Time.timeScale = 0;
				AudioListener.pause = true;
			} else {
				Time.timeScale = 1;
				AudioListener.pause = false;
			}
		globalVariables.gameStarted = !globalVariables.gameStarted;
		button.GetComponentInChildren<Text> ().text = globalVariables.gameStarted == true ? "Pause" : "Start";

	}


	IEnumerator wait(){
		yield return new WaitForSeconds(1.5f);
		ghostOne.SetActive (true);
		ghostTwo.SetActive (true);
		ghostThree.SetActive(true);
		if (globalVariables.FBLogged) {
			ghostOnePhoto.SetActive (true);
			ghostTwoPhoto.SetActive (true);
			ghostThreePhoto.SetActive (true);
		}
		ghostOne.transform.position = new Vector3 (-15f, 0.75f, -11f);
		ghostTwo.transform.position = new Vector3 (-15f, 0.75f, 10f);
		ghostThree.transform.position = new Vector3 (15f, 0.75f, -11f);

	}

	IEnumerator nextLevel(){

		ghostOne.SetActive (false);
		ghostTwo.SetActive (false);
		ghostThree.SetActive(false);

		if (globalVariables.FBLogged) {
			ghostOnePhoto.SetActive (false);
			ghostTwoPhoto.SetActive (false);
			ghostThreePhoto.SetActive (false);
		}


		generated = false;

		foreach (GameObject o in GameObject.FindGameObjectsWithTag("coin")) {
			Destroy (o);
		}

		foreach (GameObject o in GameObject.FindGameObjectsWithTag("toDestroy")) {
			yield return new WaitForSeconds (0.035f);
			Destroy (o);
		}

		//text.GetComponentInChildren<Text> ().text = 0.ToString ();
		globalVariables.score = 0;
		if (!generated) {
			this.gameObject.AddComponent<mapGen2> ();
			generated = true;
		}

		StartCoroutine (wait ());
	}

		
}
