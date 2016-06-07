using UnityEngine;
using System.Collections;

public class CharactersAvatarApplication : MonoBehaviour {

	public CharactersAvatarController controller;
	public CharactersAvatarModel model;
	public CharactersAvatarView view;
}

public class CharactersAvatarElement : MonoBehaviour{
	public CharactersAvatarApplication app{
		get{
			return GameObject.FindObjectOfType<CharactersAvatarApplication> ();
		}
	}
}
