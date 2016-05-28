using UnityEngine;
using System.Collections;

public class generateLabyrinth : MonoBehaviour {
	int boardHeight;
	int boardWidth;
	// Use this for initialization
	void Start () {
		boardHeight = (int)GameObject.Find ("Cube").transform.localScale.z;
		boardWidth = (int)GameObject.Find ("Cube").transform.localScale.x;

		int[,] map = mapGen(5,boardHeight,boardWidth);

		for(int z=-boardHeight/2;z<=boardHeight/2;z++){
			for(int x=-boardWidth/2;x<=boardWidth/2;x++){
				GameObject wall = (GameObject)Instantiate(Resources.Load("wallPiece"));
				wall.transform.position = new Vector3(x,5,z);
				wall.SetActive (map [boardHeight / 2 - z, boardWidth / 2 - x] == 1 ? true : false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	private int[,] mapGen(int spawnersNr,int height,int width){
		int[] spawners = new int[spawnersNr];
		int iterator = 0;

		int[,] map = new int[height, width];
		for (int i = 0; i < height; i++)
			for (int j = 0; j < width; j++)
				map[i, j] = 1;

		while(iterator<spawners.Length){
			bool iterated=false;
			int randomHeight = Random.Range (1, height-1);
			int randomWidth = Random.Range (1, width-1);

			Spawner spawner = new Spawner ();
			int[] buildersDistance = spawner.getBuildersDistance ();

			while(!iterated) {
				int buildersNumber=0;
				bool passed0 = false;
				bool passed1 = false;
				bool passed2 = false;
				bool passed3 = false;
				bool overLap = false;
				int countFinishedBuilder = 0;

				while (buildersNumber < spawner.getBuilders ()) {
					int cellsToGo = buildersDistance [buildersNumber];
					int randomDirection = Random.Range (0,spawner.getBuilders ()+1);
					if (randomDirection == 0) {
						if (passed0) {
							overLap = true;
							break;
						}
						for (int togo = 0; togo < cellsToGo; togo++) {
							map [randomHeight - togo - 1, randomWidth] = 0;
						}
						passed0 = true;
						countFinishedBuilder++;
					} else if (randomDirection == 1) {
						if (passed1) {
							overLap = true;
							break;
						}
						for (int togo = 0; togo < cellsToGo; togo++) {
							map [randomHeight, randomWidth + togo + 1] = 0;
						}
						passed1 = true;
						countFinishedBuilder++;
					} else if (randomDirection == 2) {
						if (passed2) {
							overLap = true;
							break;
						}
						for (int togo = 0; togo < cellsToGo; togo++) {
							map [randomHeight + togo + 1, randomWidth] = 0;
						}
						passed2 = true;
						countFinishedBuilder++;
					} else if (randomDirection == 3) {
						if (passed3) {
							overLap = true;
							break;
						}
						for (int togo = 0; togo < cellsToGo; togo++) {
							map [randomHeight, randomWidth - togo - 1] = 0;
						}
						passed3 = true;
						countFinishedBuilder++;
					}
					if (!overLap)
						buildersNumber++;
					else
						continue;
				}
				if (countFinishedBuilder == buildersNumber)
					iterated = true;
			}
			iterator++;
			map[randomHeight,randomWidth] = 0;

		}


		return map;
	}
}

public class Spawner{
	private int builders;
	private int[] buildersDistance;

	public Spawner(){
		builders = Random.Range (2, 5);
	
		buildersDistance = new int[builders];
		for (int i = 0; i < builders; i++) {
			buildersDistance [i] = Random.Range (2, 5);
			Debug.Log (buildersDistance [i]);
		}
		
	}

	public int getBuilders(){
		return builders;
	}

	public int[] getBuildersDistance(){
		return buildersDistance;
	}
}
