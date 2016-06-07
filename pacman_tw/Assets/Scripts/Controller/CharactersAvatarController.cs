using UnityEngine;
using System.Collections;

public class CharactersAvatarController : CharactersAvatarElement {


	public void setTextures(){

		StartCoroutine (ShowGhosts ());
	}

	// Use this for initialization
	public IEnumerator ShowGhosts (){

		WWW ghost1 = new WWW (globalVariables.ghostsUrls[0]);
		WWW ghost2 = new WWW (globalVariables.ghostsUrls[1]);
		WWW ghost3 = new WWW (globalVariables.ghostsUrls[2]);
		WWW pacmanTex = new WWW (globalVariables.playerPictureUrl);

		yield return ghost1;
		yield return ghost2;
		yield return ghost3;
		yield return pacmanTex;

		Texture2D ghostOneTex = new Texture2D (200, 200);
		Texture2D ghostTwoTex = new Texture2D (200, 200);
		Texture2D ghostThreeTex = new Texture2D (200,200);
		Texture2D pacmanJPGTex = new Texture2D (200,200);

		ghostOneTex = ghost1.texture;
		ghostOneTex.anisoLevel=9;
		app.view.ghostOne.GetComponent<Renderer> ().material.SetTexture ("_MainTex", ghostOneTex);

		ghostTwoTex = ghost2.texture;
		ghostTwoTex.anisoLevel = 9;
		app.view.ghostTwo.GetComponent<Renderer> ().material.SetTexture("_MainTex",ghostTwoTex);

		ghostThreeTex = ghost3.texture;
		ghostThreeTex.anisoLevel = 9;
		app.view.ghostThree.GetComponent<Renderer> ().material.SetTexture("_MainTex",ghostThreeTex);

		pacmanJPGTex = pacmanTex.texture;
		pacmanJPGTex.anisoLevel = 9;
		app.view.pacmanJPG.GetComponent<Renderer> ().material.SetTexture ("_MainTex", pacmanJPGTex);
	}
}
