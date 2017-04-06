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
    public bool SpellSelection = false;
    public bool FightMenu = true;
    public static float PlayerHealth = 20;
    public static bool PlayerGotHit = false;
    public Sprite Base;
    public Texture Rock,Paper, Scissors, DeathTexture;

    //const i swear
    public const int IDLE_PICK = 0;
    public const int ATTACK = 1;
    public const int ATTACK_MAGIC = 2;
    public const int HAS_PICKED = 3;
    public const int GETTING_ATTACKED = 4;
    public const int DEATH = 5;


    //const i swear
    public const int PICK_NONE = 0;
    public const int PICK_ROCK = 1;
    public const int PICK_PAPER = 2;
    public const int PICK_SCISSORS = 3;

    public static int state = IDLE_PICK;
    public static int currentPick = PICK_NONE;

    void Start()
    {   

    }

    void Update()
    {

    }

   public static void GettingAttacked(int damage)
    {

        PlayerHealth -= damage;

    }
    

    

    void renderButtons()
    {
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        if (GUI.Button(new Rect(Screen.width * .30f, Screen.height * .35f, 100, 100), Rock))
        {
            PlayerRock = true;
            PlayerIsReady = true;
            CanPick = false;
            Debug.Log("Rock was pick");
            currentPick = PICK_ROCK;
            state = HAS_PICKED;
        }
        if (GUI.Button(new Rect(Screen.width * .40f, Screen.height * .35f, 100, 100), Paper))
        {
            PlayerPaper = true;
            PlayerIsReady = true;
            CanPick = false;
            Debug.Log("Paper was Picked.");
            currentPick = PICK_PAPER;
            state = HAS_PICKED;

        }

        if (GUI.Button(new Rect(Screen.width * .50f, Screen.height * .35f, 100, 100), Scissors))
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

        if (GUI.Button(new Rect(Screen.width * .35f, Screen.height * .35f, 100, 100), "Melee"))
        {

            int AttackRandomNumber = Random.Range(1, 5);
            ComputerAI.TakeDamage(AttackRandomNumber);
            Debug.Log("The computer was attacked for " + AttackRandomNumber);
            state = IDLE_PICK;
            ComputerAI.state = ComputerAI.IDLE;
        }
        if (GUI.Button(new Rect(Screen.width * .15f, Screen.height * .15f, 100, 100), "Magic"))
        {
            state = ATTACK_MAGIC;
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

    void OnDeath()
    {

       GUI.DrawTexture(new Rect(Screen.width / 2 - 50, 0, 80, 50), DeathTexture);
        if (GUI.Button(new Rect(Screen.width * .40f, Screen.height * .35f, 100, 100), "Player Again?"))
        {
            
            Debug.Log("Play Again was Picked.");
            
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
            case DEATH:
                OnDeath();
                break;
        }
        //if (PlayerCanFight == true)
        //{
        //    GUI.Label(new Rect(10, 10, 100, 20), "Player Health:" + PlayerHealth);
        //}


        // lil thing to show the state?
        string cpuState = state == IDLE_PICK ? "IDLE" :
                          state == ATTACK ? "ATTACK" :
                          state == HAS_PICKED ? "HAS_PICKED" :
                          state == ATTACK_MAGIC ? "ATTACK_MAGIC" :
                          state == GETTING_ATTACKED ? "GETTING_ATTACKED" : 
                          "IDFK";
        GUI.Label(new Rect(10, 30, 500, 20), "Computer State: " + cpuState);
    }
}


