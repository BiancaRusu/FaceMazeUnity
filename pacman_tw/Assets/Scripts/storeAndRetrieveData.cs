using UnityEngine;
using System.Collections;
using System.Net;
using Facebook.MiniJSON;
using UnityEngine.UI;

public class storeAndRetrieveData : MonoBehaviour {

	// Use this for initialization
	public void start () {
		string url = "http://localhost:8081/facemaze/facebook/login/"+ globalVariables.userFbId;
		Debug.Log (url);
		WWW www = new WWW (url);

		while (!www.isDone);/*..wait..*/

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
