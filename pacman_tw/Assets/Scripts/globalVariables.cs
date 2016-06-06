using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class globalVariables{

	//ghosts business;
	public static List<string> ghostsUrls = new List<string>();
	public static List<string> ghostsNames = new List<string>();

	public static bool loaded;

	//player business
	public static string userFbId;
	public static string fbName;
	public static string playerPictureUrl;
	public static int score;
	public static int totalScore;
	public static int bestScore;
	public static bool FBLogged;
	public static bool gameStarted;

	//map
	public static int[,] map;
	public static int boardheight;
	public static int boardwidth;
}
