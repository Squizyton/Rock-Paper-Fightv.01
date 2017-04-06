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

    const int IDLE_PICK = 0;
    const int ATTACK = 1;
    const int ATTACK_MAGIC = 2;
    const int HAS_PICKED = 3;

    const int PICK_NONE = 0;
    const int PICK_ROCK = 1;
    const int PICK_PAPER = 2;
    const int PICK_SCISSORS = 3;
    

    public int state = IDLE_PICK;
    public int currentPick = PICK_NONE;
   
    void Start()
    {

    }

    void Update()
    {
        if (PlayerGotHit == true)
        {
            PlayerHealth = -ComputerAI.AttackHitterThing;
            PlayerGotHit = false;
        }
    }


    void renderButtons()
    {
        if (GUI.Button(new Rect(Screen.width * .30f, Screen.height * .35f, 100, 100), "Rock"))
        {
            PlayerRock = true;
            PlayerIsReady = true;
            CanPick = false;
            Debug.Log("Rock was pick");
            currentPick = PICK_ROCK;
            state = HAS_PICKED;
        }
        if (GUI.Button(new Rect(Screen.width * .40f, Screen.height * .35f, 100, 100), "Paper"))
        {
            PlayerPaper = true;
            PlayerIsReady = true;
            CanPick = false;
            Debug.Log("Paper was Picked.");
            currentPick = PICK_PAPER;
            state = HAS_PICKED;

        }

        if (GUI.Button(new Rect(Screen.width * .50f, Screen.height * .35f, 100, 100), "Scissors"))
        {
            PlayerScizzors = true;
            PlayerIsReady = true;
            CanPick = false;
            Debug.Log("Scissors was picked!");
            currentPick = PICK_SCISSORS;
            state = HAS_PICKED;

        }
    }

    void AttackButtons()
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

    void MagicButtons()
    {
        AttackButtons();

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

    }

    void OnGUI()
    {
        // its the players turn

        switch (state)
        {
            case IDLE_PICK:
                renderButtons();
                break;
            case ATTACK:
                AttackButtons();
                break;
            case ATTACK_MAGIC:
                MagicButtons();
                break;
        }
        if (PlayerCanFight == true)
        {
            GUI.Label(new Rect(10, 10, 100, 20), "Player Health:" + PlayerHealth);
        }
    }
}


