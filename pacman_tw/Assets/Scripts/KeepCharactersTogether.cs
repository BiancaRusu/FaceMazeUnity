using UnityEngine;
using System.Collections;

public class KeepCharactersTogether : MonoBehaviour {

	public GameObject pacman;
	public GameObject pacmanPhoto;

	public GameObject ghostOne;
	public GameObject ghostOnePhoto;

	public GameObject ghostTwo;
	public GameObject ghostTwoPhoto;

	public GameObject ghostThree;
	public GameObject ghostThreePhoto;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		pacmanPhoto.transform.position = new Vector3 (pacman.transform.position.x, 3.5f, pacman.transform.position.z);

		ghostOnePhoto.transform.position = new Vector3 (ghostOne.transform.position.x, 3.5f, ghostOne.transform.position.z);
		ghostTwoPhoto.transform.position = new Vector3 (ghostTwo.transform.position.x, 3.5f, ghostTwo.transform.position.z);
		ghostThreePhoto.transform.position = new Vector3 (ghostThree.transform.position.x, 3.5f, ghostThree.transform.position.z);
	}
}
