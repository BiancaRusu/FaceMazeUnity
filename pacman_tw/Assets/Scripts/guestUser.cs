using UnityEngine;
using System.Collections;

public class guestUser : MonoBehaviour {
	public GameObject inputField;

		public void Start () {
		inputField.SetActive (!inputField.activeInHierarchy);
	}
	

}
