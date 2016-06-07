using UnityEngine;
using System.Collections;

public class CharactersPositionApplication : MonoBehaviour {

	public CharactersPositionView view;
	public CharactersPositionModel model;
	public CharactersPositionController controller;
}

public class CharactersPositionElement : MonoBehaviour{
	public CharactersPositionApplication app{
		get{
			return GameObject.FindObjectOfType<CharactersPositionApplication> ();
		}
	}
}