using UnityEngine;
using System.Collections;
using System.Net;
using Facebook.MiniJSON;
using UnityEngine.UI;

public class storeAndRetrieveData : MonoBehaviour {
	string scoreURL = "http://localhost:8081/facemaze/facebook/login/"+ globalVariables.userFbId;
	string scoreTableURL = "http://localhost:8081/facemaze/scoretable/";
	public GameObject scrollView;
	public GameObject content;


	public void showScoreTable(){
		if (!scrollView.activeInHierarchy) {
			scrollView.SetActive (true);
			content.GetComponentInChildren<Text> ().text = "";

		} else {
			content.GetComponentInChildren<Text> ().text = "";
			scrollView.SetActive (false);
		}
		StartCoroutine (getScoreTable ());

	}

	public void showScore(){
		StartCoroutine (getScore ());
	}


	IEnumerator getScoreTable(){
		WWW www = new WWW (scoreTableURL);
		yield return www;
		if (www.error == null) {
			var result = Json.Deserialize (www.text) as IDictionary;
			var players = result ["players"] as IList;

			for (int i = 0; i < players.Count; i++) {
				var player = players [i] as IDictionary;
				content.GetComponentInChildren<Text> ().text = content.GetComponentInChildren<Text> ().text + "\n" + (i + 1) + ". " + player ["name"].ToString () + "  ->  " + player ["highscore"].ToString (); ;
			}
		} else {
			Debug.Log (www.error);
		}
	}

	public IEnumerator getScore () {
		WWW www = new WWW (scoreURL);
		yield return www;

		if (www.error == null) {
			var result = Json.Deserialize (www.text) as IDictionary;
			Debug.Log(result["score"]);
			Text highscore = GameObject.Find ("highscore_value").GetComponent<Text> ();
			highscore.text = result ["score"].ToString ();
		} else {
			Debug.Log (www.error);
		}
	}
		
}
