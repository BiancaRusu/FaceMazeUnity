using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
using Facebook.MiniJSON;

public class FBholder : MonoBehaviour {


	// Use this for initialization
	void Awake ()
	{
		FB.Init (SetInit, OnHideUnity);
	}

	private void SetInit(){
		if (FB.IsLoggedIn) {
			Debug.Log ("FB Logged in");
		} else {
			Debug.Log ("FB not logged in");

		}

	}

	private void OnHideUnity(bool isGameShown){
		if (isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void FBLogin(){
		List<string> permissions = new List<string> ();
		permissions.Add ("public_profile");
		permissions.Add ("user_friends");

		FB.LogInWithReadPermissions (permissions, AuthCallBack);
	}

	void AuthCallBack(IResult result){
		if (result.Error != null) {
			Debug.Log (result.Error);
		} else {
			if (FB.IsLoggedIn) {
				Debug.Log ("FB logged in");
				FB.API ("/me?fields=id,name", HttpMethod.GET, userId);
				FB.API ("/me/invitable_friends?limit=500&fields=id,name,picture.width(100).height(100)", HttpMethod.GET, friendsPhotos);
                FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, userId);
			} else {
				Debug.Log ("FB not logged in");
			}
		}
	}

	void userId(IResult result){
		if (result.Error == null) {
			string id = result.ResultDictionary ["id"].ToString();
			globalVariables.userFbId = id;
			string name = result.ResultDictionary ["name"].ToString ();
			globalVariables.fbName = name;
            globalVariables.profilePictureUrl = string.Format("https://graph.facebook.com/{0}/picture", id);
		}
	}


	void friendsPhotos(IResult result){
		if (result.Error == null) {
			var dict = Json.Deserialize (result.RawResult) as Dictionary<string,object>;
			List<object> friends = dict ["data"] as List<object>;
			Debug.Log (friends.Count);
			for (int i = 0; i < 3; i++) {
				int random = Random.Range (0, friends.Count-1);
				var friendObject = friends [random] as Dictionary<string,object>;

				//nume fantoma
				string friendName = friendObject ["name"] as string;
				globalVariables.ghostsNames.Add (friendName);

				var pictureObject = friendObject ["picture"] as Dictionary<string,object>;
				var pictureObjectData = pictureObject ["data"] as Dictionary<string,object>;

				//url poza fantoma
				string url = pictureObjectData ["url"] as string;

				Debug.Log (url);
				globalVariables.ghostsUrls.Add(url);

			}

			ghostAvatars ga = new ghostAvatars ();
			ga.ShowGhosts ();
		}
	}
}


	