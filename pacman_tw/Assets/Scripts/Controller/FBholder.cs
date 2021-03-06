﻿using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
using Facebook.MiniJSON;
using UnityEngine.UI;

public class FBholder : MonoBehaviour {
	public GameObject ghost1;
	public GameObject ghost2;
	public GameObject ghost3;
	public GameObject pacmanJPG;

	// Use this for initialization
	void Awake ()
	{
		FB.Init (SetInit, OnHideUnity);
	}

	private void SetInit(){
		if (FB.IsLoggedIn) {
			globalVariables.FBLogged = true;
			Debug.Log ("FB Logged in");
			FB.API ("/me?fields=id,name,picture.width(500).height(500)", HttpMethod.GET, userId);
			FB.API ("/me/invitable_friends?limit=500&fields=id,name,picture.width(500).height(500)", HttpMethod.GET, friendsPhotos);
		} else {
			Debug.Log ("FB not logged in");
		}
		dealWithThings (FB.IsLoggedIn);

	}

	private void OnHideUnity(bool isGameShown){
		if (isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void FBLogin(){
		if (!FB.IsLoggedIn) {
			List<string> permissions = new List<string> ();
			permissions.Add ("public_profile");
			permissions.Add ("user_friends");
			globalVariables.FBLogged = true;
			FB.LogInWithReadPermissions (permissions, AuthCallBack);
		} else {
			FB.LogOut ();
			dealWithThings (false);
			globalVariables.FBLogged = false;

		}
	}

	void AuthCallBack(IResult result){
		if (result.Error != null) {
			Debug.Log (result.Error);
		} else {
			if (FB.IsLoggedIn) {
				globalVariables.FBLogged = true;
				Debug.Log ("FB logged in");
				FB.API ("/me?fields=id,name,picture.width(500).height(500)", HttpMethod.GET, userId);
				FB.API ("/me/invitable_friends?limit=500&fields=id,name,picture.width(500).height(500)", HttpMethod.GET, friendsPhotos);
			} else {
				globalVariables.FBLogged = false;
				Debug.Log ("FB not logged in");
			}
			dealWithThings (FB.IsLoggedIn);
		}
	}

	void userId(IResult result){
		if (result.Error == null) {
			string id = result.ResultDictionary ["id"].ToString();
			globalVariables.userFbId = id;

			string name = result.ResultDictionary ["name"].ToString ();
			globalVariables.fbName = name;

			var obj = Json.Deserialize (result.RawResult) as Dictionary<string,object>;
			var picture = obj ["picture"] as IDictionary;
			var data = picture ["data"] as IDictionary;
			string playerPictureUrl = data ["url"] as string;
			globalVariables.playerPictureUrl = playerPictureUrl;

			Debug.Log (playerPictureUrl);
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
				globalVariables.ghostsUrls.Add(url);

			}

			/*this.gameObject.AddComponent<CharactersAvatars> ();
			CharactersAvatars ca = this.GetComponent<CharactersAvatars> ();
			ca.setTextures ();
			*/

			this.gameObject.AddComponent<CharactersAvatarController> ();
			CharactersAvatarController controller = this.gameObject.GetComponent<CharactersAvatarController> ();
			controller.setTextures();

			this.gameObject.AddComponent<storeAndRetrieveData> ();
			storeAndRetrieveData s = this.GetComponent<storeAndRetrieveData> ();
			s.showScore ();
		}
	}

	void dealWithThings(bool isLogged){
		if (isLogged) {
			GameObject loginButton = GameObject.Find ("Login with Facebook");
			loginButton.GetComponentInChildren<Text> ().text = "Logout";
			ghost1.SetActive (true);
			ghost2.SetActive (true);
			ghost3.SetActive (true);
			pacmanJPG.SetActive (true);
			if (GameObject.Find ("InputName") != null) {
				GameObject.Find ("InputName").SetActive (false);
			}
		} else {
			GameObject loginButton = GameObject.Find ("Login with Facebook");
			loginButton.GetComponentInChildren<Text> ().text = "Play with Facebook";
			ghost1.SetActive (false);
			ghost2.SetActive (false);
			ghost3.SetActive (false);
			pacmanJPG.SetActive (false);
		}
	}
		

}


	