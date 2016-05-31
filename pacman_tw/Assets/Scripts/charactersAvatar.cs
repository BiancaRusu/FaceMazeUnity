using UnityEngine;
using System.Collections;

public class charactersAvatars : MonoBehaviour {


	public charactersAvatars(){}
	// Use this for initialization
	public void ShowGhosts (){
	    GameObject ghostOne = GameObject.Find("ghostOne");
		GameObject ghostTwo = GameObject.Find ("ghostTwo");
	    GameObject ghostThree = GameObject.Find("ghostThree");
		GameObject pacmanJPG = GameObject.Find ("pacmanJPG");

		Texture2D ghostOneTex = new Texture2D (10, 10);
		Texture2D ghostTwoTex = new Texture2D (10, 10);
		Texture2D ghostThreeTex = new Texture2D (10, 10);
		Texture2D pacmanJPGTex = new Texture2D (10, 10);

		var ghost1 = new WWW (globalVariables.ghostsUrls[0]);
		var ghost2 = new WWW (globalVariables.ghostsUrls[1]);
		var ghost3 = new WWW (globalVariables.ghostsUrls[2]);
		var pacmanTex = new WWW (globalVariables.playerPictureUrl);

		/*...wait until downloaded...*/
		while (!ghost1.isDone || !ghost2.isDone || !ghost3.isDone || !pacmanTex.isDone);

		ghost1.LoadImageIntoTexture (ghostOneTex);
		ghostOne.GetComponent<Renderer> ().material.SetTexture("_MainTex",ghostOneTex);

		ghost2.LoadImageIntoTexture (ghostTwoTex);
		ghostTwo.GetComponent<Renderer> ().material.SetTexture("_MainTex",ghostTwoTex);

		ghost3.LoadImageIntoTexture (ghostThreeTex);
		ghostThree.GetComponent<Renderer> ().material.SetTexture("_MainTex",ghostThreeTex);

		pacmanTex.LoadImageIntoTexture (pacmanJPGTex);
		pacmanJPG.GetComponent<Renderer> ().material.SetTexture ("_MainTex", pacmanJPGTex);
	}
		
}
