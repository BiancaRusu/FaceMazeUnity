using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GhostTrigger : MonoBehaviour {

	public GameObject ghostOne;
	public GameObject ghostTwo;
	public GameObject ghostThree;

	public GameObject ghostOnePhoto;
	public GameObject ghostTwoPhoto;
	public GameObject ghostThreePhoto;



	void OnTriggerEnter(Collider other){
		if (other.name == "pacman") {
			Debug.Log ("helloo, ghost right here");
			GameObject button = GameObject.Find("Start");
			GameObject highscore = GameObject.Find ("highscore_value");

			button.GetComponentInChildren<Text> ().text = "Restart";

			if (globalVariables.bestScore < globalVariables.totalScore) {
				highscore.GetComponentInChildren<Text> ().text = globalVariables.totalScore.ToString ();


			}

			StartCoroutine (youLost ());

		}
	}

	IEnumerator youLost(){
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("coin")) {
			Destroy (go);
		}
			
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("toDestroy")) {
			yield return new WaitForSeconds (0.035f);
			Destroy (go);
		}

		ghostOne.SetActive (false);
		ghostTwo.SetActive (false);
		ghostThree.SetActive(false);


		if (globalVariables.FBLogged) {
			ghostOnePhoto.SetActive (false);
			ghostTwoPhoto.SetActive (false);
			ghostThreePhoto.SetActive (false);
		}

		GameObject youLose = (GameObject)Instantiate (Resources.Load ("You lose"));
		youLose.transform.position = new Vector3(0f, 0.75f, 0f);
			
	}


}
