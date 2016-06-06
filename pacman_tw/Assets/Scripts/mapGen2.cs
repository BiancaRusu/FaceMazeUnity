using UnityEngine;
using System.Collections;

public class mapGen2 : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		mapGen ();
	}


	
	// Update is called once per frame
	void Update () {


	}

	int[,] mapBorder(int height,int width){
		int[,] map = new int[height, width];
		for (int i = 0; i < height; i++)
			for (int j = 0; j < width; j++)
				if (i == 0 || j == 0 || i == height - 1 || j == width - 1)
					map [i, j] = 1;
				else
					map [i, j] = 0;

		return map;
	}

	public void mapGen(){
		int boardHeight = (int)GameObject.Find ("board").transform.localScale.z;
		int boardWidth = (int)GameObject.Find ("board").transform.localScale.x;

		globalVariables.boardheight = boardHeight;
		globalVariables.boardwidth = boardWidth;

		int randomZ;
		int randomX;
		bool ok;
		int toGen;
		int[,] map = mapBorder(boardHeight,boardWidth);

		for(int z=-boardHeight/2;z<=boardHeight/2;z++){
			for(int x=-boardWidth/2;x<=boardWidth/2;x++){
				GameObject wall = (GameObject)Instantiate(Resources.Load("wallPiece"));
				wall.transform.position = new Vector3(x,0.75f,z);
				wall.SetActive (map [boardHeight / 2 - z, boardWidth / 2 - x] == 1 ? true : false);
			}
		}


		//generare forme plus
		toGen = 0;
		while (toGen<=5) {
			randomZ = Random.Range (-boardHeight/2+3,boardHeight/2-3);
			randomX = Random.Range (-boardWidth/2+3,boardWidth/2-3);
			ok = true;
			for (int i = -3; i <= 3; i++) {
				if (map [boardHeight / 2 + randomZ + i, boardWidth / 2 + randomX] == 1)
					ok = false;
				if (map [boardHeight / 2 + randomZ, boardWidth / 2 + randomX + i] == 1)
					ok = false;
				//check the offset of model
				if (i != 0) {
					if (map [boardHeight / 2 + randomZ + i, boardWidth / 2 + randomX + 1] == 1)
						ok = false;
					if (map [boardHeight / 2 + randomZ + i, boardWidth / 2 + randomX - 1] == 1)
						ok = false;
					if (map [boardHeight / 2 + randomZ + 1, boardWidth / 2 + randomX + i] == 1)
						ok = false;
					if (map [boardHeight / 2 + randomZ - 1, boardWidth / 2 + randomX + i] == 1)
						ok = false;
				}
			}

			if (ok) {
				GameObject plus = (GameObject)Instantiate (Resources.Load ("+"));
				plus.transform.position = new Vector3 (randomX, 0.75f, randomZ);

				for (int i = -2; i <= 2; i++) {
					//map [boardHeight / 2 + randomZ -1, boardWidth / 2 + randomX+i] = 1;
					//map [boardHeight / 2 + randomZ +1, boardWidth / 2 + randomX +i] = 1;
					map [boardHeight / 2 + randomZ, boardWidth / 2 + randomX +i] = 1;
					map [boardHeight / 2 + randomZ+i, boardWidth / 2 + randomX] = 1;

					//map [boardHeight / 2 + randomZ+i, boardWidth / 2 + randomX +1] = 1;
					//map [boardHeight / 2 + randomZ+i, boardWidth / 2 + randomX -1] = 1;
				}


				toGen++;
			}
		}

		//generare forma L
		toGen = 0;
		while (toGen <= 5) {
			randomZ = Random.Range (-boardHeight/2+3,boardHeight/2-3);
			randomX = Random.Range (-boardWidth/2+3,boardWidth/2-3);
			ok = true;

			//search for an area
			for (int i = -2; i <= 2; i++) {
				if (map [boardHeight / 2 + randomZ - 1, boardWidth / 2 + randomX - i] == 1)
					ok = false;
				if (map [boardHeight / 2 + randomZ + i, boardWidth / 2 + randomX +1] == 1)
					ok = false;
				if (map [boardHeight / 2 + randomZ - 2, boardWidth / 2 + randomX + i] == 1)
					ok = false;
				if (map [boardHeight / 2 + randomZ + i, boardWidth / 2 + randomX +2 ] == 1)
					ok = false;
			}

			for (int i = 0; i <= 2; i++) {
				if (map [boardHeight / 2 + randomZ, boardWidth / 2 + randomX - i] == 1)
					ok = false;
				if (map [boardHeight / 2 + randomZ + i, boardWidth / 2 + randomX ] == 1)
					ok = false;
			}

			if (ok) {
				GameObject l = (GameObject)Instantiate(Resources.Load("L"));
				l.transform.position = new Vector3 (randomX, 0.75f, randomZ);

				for (int i = -1; i <= 1; i++) {
					map [boardHeight / 2 + randomZ - 1, boardWidth / 2 + randomX + i] = 1;
					map [boardHeight / 2 + randomZ + i, boardWidth / 2 + randomX + 1] = 1;
				}



				toGen++;
			}

		}

		//generare forma T
		toGen=0;
		while (toGen <= 5) {
			randomZ = Random.Range (-boardHeight/2+3,boardHeight/2-3);
			randomX = Random.Range (-boardWidth/2+3,boardWidth/2-3);
			ok = true;
			for (int i = -2; i <= 2; i++) {
				if (map [boardHeight / 2 + randomZ + i, boardWidth / 2 + randomX] == 1) 
					ok = false;
				if (map [boardHeight / 2 + randomZ - 1, boardWidth / 2 + randomX+i] == 1)
					ok = false;
				if (map [boardHeight / 2 + randomZ +i, boardWidth / 2 + randomX-1] == 1)
					ok = false;
				if (map [boardHeight / 2 + randomZ +i, boardWidth / 2 + randomX+1] == 1)
					ok = false;
				if (!ok)
					break;
			}
			if (map [boardHeight / 2 + randomZ, boardWidth / 2 + randomX+2] == 1)
				ok = false;
			if (map [boardHeight / 2 + randomZ, boardWidth / 2 + randomX-2] == 1)
				ok = false;
			if (map [boardHeight / 2 + randomZ-2, boardWidth / 2 + randomX-2] == 1)
				ok = false;
			if (map [boardHeight / 2 + randomZ-2, boardWidth / 2 + randomX+2] == 1)
				ok = false;

			if (ok) {
				GameObject cube = (GameObject)Instantiate (Resources.Load ("T"));
				cube.transform.position = new Vector3 (randomX, 0.75f, randomZ);
				for (int i = -1; i <= 1; i++) {
					map [boardHeight / 2 + randomZ + i, boardWidth / 2 + randomX] = 1;
					map [boardHeight / 2 + randomZ - 1, boardWidth / 2 + randomX +i] = 1;
				}

				toGen++;
			}

		}

		//generare forma I
		toGen = 0;
		while (toGen <= 5) {
			randomZ = Random.Range (-boardHeight / 2 + 3, boardHeight / 2 - 3);
			randomX = Random.Range (-boardWidth / 2 + 3, boardWidth / 2 - 3);
			ok = true;

			for (int i = 0; i <= 4; i++) {
				if (map [boardHeight / 2 + randomZ - 1 + i, boardWidth / 2 + randomX] == 1) {
					ok = false;
				}
				if (map [boardHeight / 2 + randomZ - 1 + i, boardWidth / 2 + randomX - 1] == 1) {
					ok = false;

				}
				if (map [boardHeight / 2 + randomZ - 1 + i, boardWidth / 2 + randomX + 1] == 1) {
					ok = false;

				}
			}


			if (ok) {
				GameObject l = (GameObject)Instantiate(Resources.Load("I"));
				l.transform.position = new Vector3 (randomX, 0.75f, randomZ);
				for (int i = 0; i <= 2; i++) {
					map [boardHeight / 2 + randomZ + i, boardWidth / 2 + randomX] = 1;
				}


				toGen++;
			}

		}

		//generare forma cub
		toGen = 0;
		while (toGen <= 5) {
			randomZ = Random.Range (-boardHeight/2+3,boardHeight/2-3);
			randomX = Random.Range (-boardWidth/2+3,boardWidth/2-3);
			ok = true;

			for (int i = -1; i <= 1; i++) {
				if (map [boardHeight / 2 + randomZ - 1, boardWidth / 2 + randomX + i] == 1)
					ok = false;
				if (map [boardHeight / 2 + randomZ , boardWidth / 2 + randomX + i] == 1)
					ok = false;
				if (map [boardHeight / 2 + randomZ +1, boardWidth / 2 + randomX + i] == 1)
					ok = false;
			}

			if (ok) {
				GameObject cube = (GameObject)Instantiate (Resources.Load ("labPiece"));
				cube.transform.position = new Vector3 (randomX, 0.75f, randomZ);
				map [boardHeight / 2 + randomZ, boardWidth / 2 + randomX] = 1;


				toGen++;
			}

		}


		//generare monezi
		globalVariables.map = map;

		toGen = 0;
		while (toGen <= 50) {
			randomZ = Random.Range (-boardHeight / 2 + 3, boardHeight / 2 - 3);
			randomX = Random.Range (-boardWidth / 2 + 3, boardWidth / 2 - 3);
			ok = true;
			if (map [boardHeight / 2 + randomZ, boardWidth / 2 + randomX] == 1 || map [boardHeight / 2 + randomZ, boardWidth / 2 + randomX] == 2)
				ok = false;

			if (ok) {
				GameObject coin = (GameObject)Instantiate (Resources.Load ("coin"));
				coin.transform.position = new Vector3 (randomX, 0.75f, randomZ);
				map [boardHeight / 2 + randomZ, boardWidth / 2 + randomX] = 2;
				toGen++;
			}

		}


		//functie testare
		/*
		 for (int i = 0; i < 25; i++)
			for (int j = 0; j < 35; j++) {
				if(map[i,j]==1){
					GameObject piece = (GameObject)Instantiate (Resources.Load ("wallPiece"));
					piece.transform.position = new Vector3 (-17+j, 1f, -12 + i);
				}
			}
		 */
	
	}
}
