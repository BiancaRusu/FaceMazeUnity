using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class globalVariables{

	//ghosts business;
	public static List<string> ghostsUrls = new List<string>();
	public static List<string> ghostsNames = new List<string>();

	public static bool loaded;

	//player business
	public static string userFbId;
	public static string fbName;
    public static string profilePictureUrl;
	public int score;
	public int bestScore;
}
