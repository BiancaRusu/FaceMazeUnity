using UnityEngine;
using System.Collections;


public class GhostMovement : MonoBehaviour {
	public GameObject ghostBall;
	public GameObject ghostPhoto;
	int[,] map;
	float x,z;
	string fromWhere;
	int direction; 
	int cellsTogo;
	int iterator=0;
	int width;
	int height;



	float speed;
	// Use this for initialization
	void Start () {
		height = globalVariables.boardheight;
		width = globalVariables.boardwidth;

		map = globalVariables.map;

		x = width - ((int)ghostBall.transform.position.x+width/2)-1;
		z = height - ((int)ghostBall.transform.position.z + height / 2)-1;

	}

	// Update is called once per frame
	void Update(){
		//StartCoroutine (wait ());


		if (globalVariables.gameStarted) {
			StartCoroutine (move ());
		}

	}
		


	IEnumerator move(){

		cellsTogo = globalVariables.cellsToGo;

		switch( Random.Range (0, 4)){
		//dreapta
		case 0:
			{
				if (fromWhere != "right") {
					while (iterator < cellsTogo) {
						if (map [height - 1 - (int)z, width - (int)x] != 1) {
							speed += Time.deltaTime;
							Vector3 vec = new Vector3 (ghostBall.transform.position.x + 1f, 0.75f, ghostBall.transform.position.z);
							ghostBall.transform.position =Vector3.Lerp(ghostBall.transform.position,vec,0.04f);
							//ghostPhoto.transform.position = new Vector3 (ghostBall.transform.position.x, 3.5f, ghostBall.transform.position.z);
							x=x-0.035f;
							fromWhere = "left";
							yield return null;
						} else {
							iterator=cellsTogo;
						}
						iterator++;

					}
				}
				break;
			}

			//jos
		case 1:
			{
				if (fromWhere != "down") {
					while (iterator < cellsTogo) {
						if (map [height - 2 - (int)z, width - 1 - (int)x] != 1) {
							speed += Time.deltaTime;
							Vector3 vec = new Vector3 (ghostBall.transform.position.x, 0.75f, ghostBall.transform.position.z - 1f);
							ghostBall.transform.position = Vector3.Lerp(ghostBall.transform.position,vec,0.04f);
							//ghostPhoto.transform.position = new Vector3 (ghostBall.transform.position.x, 3.5f, ghostBall.transform.position.z);
							z=z+0.035f;
							fromWhere = "up";
							yield return null;
						} else {
							iterator=cellsTogo;

						}
						iterator++;

					}
				}
				break;
			}


			//stanga
		case 2:
			{
				if (fromWhere != "left") {
					while (iterator < cellsTogo) {
						if (map [height - 1 - (int)z, width - 2 - (int)x] != 1) {
							speed += Time.deltaTime;
							Vector3 vec = new Vector3 (ghostBall.transform.position.x - 1f, 0.75f, ghostBall.transform.position.z);
							ghostBall.transform.position = Vector3.Lerp(ghostBall.transform.position,vec,0.04f);
							//ghostPhoto.transform.position = new Vector3 (ghostBall.transform.position.x, 3.5f, ghostBall.transform.position.z);
							x=x+0.035f;
							fromWhere = "right";
							yield return null;
						} else {
							iterator=cellsTogo;

						}
						iterator++;

					}
				}
				break;
			}


			//sus
		case 3:
			{
				if (fromWhere != "up") {
					while (iterator < cellsTogo) {
						if (map [height - (int)z, width - 1 - (int)x] != 1) {
							speed += Time.deltaTime;
			
							Vector3 vec = new Vector3 (ghostBall.transform.position.x, 0.75f, ghostBall.transform.position.z + 1f);
							ghostBall.transform.position = Vector3.Lerp(ghostBall.transform.position,vec,0.04f);

							//ghostPhoto.transform.position = new Vector3 (ghostBall.transform.position.x, 3.5f, ghostBall.transform.position.z);
							z=z-0.035f;
							fromWhere = "down";
							yield return null;

						} else {
							iterator=cellsTogo;

						}
						iterator++;

					}
				}
				break;
			}

		default:
			{
				break;
			}

		}
		iterator = 0;
	}


}
	
