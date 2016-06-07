using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManagementController : LevelManagementElement {

	bool generated;
	// Use this for initialization
	int[,] map = globalVariables.map;
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (globalVariables.score == globalVariables.Coins) {
			globalVariables.Coins += 2;
			StartCoroutine (nextLevel ());
		}
	}

	public void startGame(){
		if (app.view.button.GetComponentInChildren<Text> ().text == "Restart") {
			globalVariables.totalScore = 0;
			GameObject score = GameObject.Find ("score_value");
			score.GetComponent<Text> ().text = 0.ToString();
			foreach (GameObject go in GameObject.FindGameObjectsWithTag ("youLose")) {
				Destroy (go);
			}
			StartCoroutine (nextLevel ());
			globalVariables.hit = false;
		}
		Debug.Log ("start");
		globalVariables.gameStarted = !globalVariables.gameStarted;
		app.view.button.GetComponentInChildren<Text> ().text = globalVariables.gameStarted == true ? "Pause" : "Start";
	}


	IEnumerator wait(){
		yield return new WaitForSeconds(1.5f);
		app.view.ghostOne.SetActive (true);
		app.view.ghostTwo.SetActive (true);
		app.view.ghostThree.SetActive(true);
		if (globalVariables.FBLogged) {
			app.view.ghostOnePhoto.SetActive (true);
			app.view.ghostTwoPhoto.SetActive (true);
			app.view.ghostThreePhoto.SetActive (true);
		}
		app.view.ghostOne.transform.position = new Vector3 (-15f, 0.75f, -11f);
		app.view.ghostTwo.transform.position = new Vector3 (-15f, 0.75f, 10f);
		app.view.ghostThree.transform.position = new Vector3 (15f, 0.75f, 0f);

	}

	IEnumerator nextLevel(){

		app.view.ghostOne.SetActive (false);
		app.view.ghostTwo.SetActive (false);
		app.view.ghostThree.SetActive(false);

		if (globalVariables.FBLogged) {
			app.view.ghostOnePhoto.SetActive (false);
			app.view.ghostTwoPhoto.SetActive (false);
			app.view.ghostThreePhoto.SetActive (false);
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
