using UnityEngine;
using System.Collections;

public class ScoreTracker : MonoBehaviour {

	public static float Player_Wins = 0;
	public static float Computer_Wins = 0;
	public static float NumberOfWins = 10	;
	public float PWins = Player_Wins;
	public float CWins = Computer_Wins;
	public static bool PlayerWon = false;
	public static bool CPUWon = false;
	void Start () 
	{
	
	//If for some reason score is at 10 when game is started
	//This will reset it. More of a fail safe then anything	
	if (Player_Wins == 10)
		{
		Player_Wins = 0;
		}
	if(Computer_Wins == 10)		
		{
		Computer_Wins = 0;
		}

	}
			void Update () 
			{



			}
}
