using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GhostTriggerController : GhostTriggerElement {


	public void coliziune(Collider other,GameObject g1, GameObject g2, GameObject g3,GameObject g1P,GameObject g2P,GameObject g3P,string name){
		if (other.name == "pacman") {
			GameObject button = GameObject.Find("Start");
			GameObject highscore = GameObject.Find ("highscore_value");
			button.GetComponentInChildren<Text> ().text = "Restart";
			if (globalVariables.bestScore < globalVariables.totalScore &&globalVariables.FBLogged) {
				highscore.GetComponentInChildren<Text> ().text = globalVariables.totalScore.ToString ();
				//Debug.Log (globalVariables.FBLogged);

					StartCoroutine (updateScore ());
					StartCoroutine (updateScoreTable ());
			}
			if (globalVariables.FBLogged &&globalVariables.hit==false) {
				Debug.Log ("asda");
				switch (name) {
				case "ghostOneBall":
					{
						globalVariables.theGhostThatAteMe = globalVariables.ghostsNames [0];
						globalVariables.hit = true;
						break;
					}
				case "ghostTwoBall":
					{
						globalVariables.theGhostThatAteMe = globalVariables.ghostsNames [1];
						globalVariables.hit = true;
						break;
					}
				case "ghostThreeBall":
					{
						globalVariables.theGhostThatAteMe = globalVariables.ghostsNames [2];
						globalVariables.hit = true;
						break;
					}
				default:
					{
						break;
					}

				}
				this.gameObject.AddComponent<ShareOnTwitterController> ();
				ShareOnTwitterController sot = this.gameObject.GetComponent<ShareOnTwitterController> ();
				sot.Share ();
			}

			StartCoroutine (youLost (g1,g2,g3,g1P,g2P,g3P));

		}
	}

	IEnumerator youLost(GameObject g1,GameObject g2, GameObject g3,GameObject g1P,GameObject g2P, GameObject g3P){
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("coin")) {
			Destroy (go);
		}

		foreach (GameObject go in GameObject.FindGameObjectsWithTag("toDestroy")) {
			yield return new WaitForSeconds (0.035f);
			Destroy (go);
		}



		g1.SetActive (false);
		g2.SetActive (false);
		g3.SetActive(false);


		if (globalVariables.FBLogged) {
			g1P.SetActive (false);
			g2P.SetActive (false);
			g3P.SetActive (false);
		}

		GameObject youLose = (GameObject)Instantiate (Resources.Load ("You lose"));
		youLose.transform.position = new Vector3(0f, 0.75f, 0f);

	}

	IEnumerator updateScore(){
		string url = "http://localhost:8081/facemaze/facebook/" + globalVariables.userFbId.ToString() + "/" + globalVariables.totalScore.ToString ();
		WWW www = new WWW (url);
		yield return www;
	}

	IEnumerator updateScoreTable(){
		string url = "http://localhost:8081/facemaze/scoretable/" + globalVariables.fbName.ToString ().Replace(" ","%20") + "/" + globalVariables.totalScore.ToString ();
		WWW www = new WWW (url);	
		yield return www;

	}


}
