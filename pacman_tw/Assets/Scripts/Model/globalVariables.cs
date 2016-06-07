using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class globalVariables{

	//ghosts business;
	public static List<string> ghostsUrls = new List<string>();
	public static List<string> ghostsNames = new List<string>();
	public static int cellsToGo=15;
	public static bool loaded;
	public static string theGhostThatAteMe;

	//player business
	public static string userFbId;
	public static string fbName;
	public static string playerPictureUrl;
	public static int score;
	public static int totalScore;
	public static int bestScore;
	public static bool FBLogged;
	public static bool gameStarted;
	public static bool hit;

	//map
	public static int[,] map;
	public static int boardheight;
	public static int boardwidth;

	public static int T=5;
	public static int L = 5;
	public static int I=5;
	public static int Plus=5;
	public static int Cubes=5;
	public static int Coins = 20;

	//audio
	public static bool paused=true;
}
