using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public static bool PlayerRock = false;
    public static bool PlayerPaper = false;
    public static bool PlayerScizzors = false;
    public static bool PlayerIsReady = false;
    public static bool PlayerCanFight = false;
    public static bool CanPick = true;
    public bool Picked = false;
    public static bool PlayerWon = false;
    public static float AttackRandomNumber = 0;
    public bool SpellSelection = false;
    public bool FightMenu = true;
    public float PlayerHealth = 20;
    public static bool PlayerGotHit = false;
    public Sprite Base;


    void Start()
    {
        Debug.Log("Please Press R for Rock,P for Paper, or S for Scizzors");


    }

    void Update()
    {
        /*if(CanPick 	== true)
		{	
			if(Input.GetKeyDown(KeyCode.R))
				{
					PlayerRock = true;
					PlayerIsReady = true;
					CanPick = false;
				//This is a Debug Line. This does absolutely nothing but tell me if Code was working.
				// V
				Picked = true;
			}
				if(Input.GetKeyDown(KeyCode.P))
					{
						PlayerPaper = true;
						PlayerIsReady = true;
						CanPick = false;
                Picked = true;
            }
					if(Input.GetKeyDown(KeyCode.S)) 
						{
							PlayerScizzors	 = true;
							PlayerIsReady = true;
							CanPick = false;
						}		
	*/
        if (PlayerGotHit == true)
        {
            PlayerHealth = -ComputerAI.AttackHitterThing;
            PlayerGotHit = false;
        }
    }
    void OnGUI()
    {
        if (CanPick == true)
        {

            if (GUI.Button(new Rect(Screen.width * .30f, Screen.height * .35f, 100, 100), "Rock"))
            {
                PlayerRock = true;
                PlayerIsReady = true;
                CanPick = false;
                Debug.Log("Rock was pick");
            }
            if (GUI.Button(new Rect(Screen.width * .40f, Screen.height * .35f, 100, 100), "Paper"))
            {
                PlayerPaper = true;
                PlayerIsReady = true;
                CanPick = false;
                Debug.Log("Paper was Picked.");

            }

            if (GUI.Button(new Rect(Screen.width * .50f, Screen.height * .35f, 100, 100), "Scissors"))
            {
                PlayerScizzors = true;
                PlayerIsReady = true;
                CanPick = false;
                Debug.Log("Scissors was picked!");

            }
        }
        if (PlayerCanFight == true)
        {
            GUI.Label(new Rect(10, 10, 100, 20), "Player Health:" + PlayerHealth);

            if (FightMenu == true)
            {
                if (GUI.Button(new Rect(Screen.width * .35f, Screen.height * .35f, 100, 100), "Fight"))
                {
                    FightMenu = false;
                    AttackRandomNumber = Random.Range(1, 5);
                    ComputerAI.ComputerGotHit = true;
                    Debug.Log("The computer was attacked for " + AttackRandomNumber);
                    CanPick = true;
                    ComputerAI.Dontpickagain = false;
                }
                if (GUI.Button(new Rect(Screen.width * .15f, Screen.height * .15f, 100, 100), "Magic"))
                {

                    FightMenu = false;
                    SpellSelection = true;
                }

            }

        }

        if (FightMenu == false && SpellSelection == true)
        {

            if (GUI.Button(new Rect(Screen.width * .35f, Screen.height * .16f, 100, 100), "Landslide"))
            {
            }

            if (GUI.Button(new Rect(Screen.width * .15f, Screen.height * .15f, 100, 100), "Cure"))
            {

                if (PlayerHealth <= 20)
                {
                    PlayerHealth += Random.Range(1, 7);
                    CanPick = true;
                    ComputerAI.Dontpickagain = false;

                }
            }

            if (GUI.Button(new Rect(Screen.width * 0f, Screen.height * .0f, 100, 100), "Back"))
            {

                FightMenu = true;
                SpellSelection = false;

            }
        }
    }
}


