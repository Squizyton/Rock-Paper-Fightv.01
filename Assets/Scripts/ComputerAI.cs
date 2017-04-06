using UnityEngine;
using System.Collections;

public class ComputerAI : MonoBehaviour
{

    public static bool CpuRock = false;
    public static bool CpuPaper = false;
    public static bool CpuScizzors = false;
    public static bool HasPicked = false;
    public float RandomPicker = 0;
    public static bool CPUisReady = false;
    public static float AttackHitterThing = 0;
    public static bool CpuCanFight = false;
    public static bool CpuCanPick = true;
    public static bool ComputerWon = false;
    public static float cpuhealth = 20;
    public static bool Dontpickagain = false;
    public static bool PickAgain = false;
    public float RandomGenerator = 0;
    public static bool ComputerGotHit = false;
    public Texture DeathTexture;


    public const int PICK_NONE = 0;
    public const int PICK_ROCK = 1;
    public const int PICK_PAPER = 2;
    public const int PICK_SCISSORS = 3;


    public const int IDLE = 0;
    public const int ATTACK = 1;
    public const int PICK = 2;
    public const int HAS_PICKED = 3;
    public const int GETTING_ATTACKED = 4;
    public const int DEATH = 5;



    public static int state = IDLE;
    public static int currentPick = PICK_NONE;



    void Start()
    {
    }

    void Dying()
    {
        Player.state = Player.HAS_WON;

        Debug.Log("Computer is dying");

        GUI.DrawTexture(new Rect(Screen.width / 2 - 50, 0, 80, 50), DeathTexture);
        if (GUI.Button(new Rect(Screen.width * .40f, Screen.height * .35f, 100, 100), "PlayAgain?"))
        {

            Debug.Log("Play Again was Picked.");

        }

    }

    void PickComputer()
    {
        switch (Random.Range(1, 4))
        {

            case 1:

                currentPick = PICK_ROCK;
                break;
            case 2:
                currentPick = PICK_PAPER;
                break;
            case 3:
                currentPick = PICK_SCISSORS;
                break;

        }
        state = HAS_PICKED;

    }
    void Attacking()
    {
        int ThisIsAnAttack = Random.Range(1, 5);
        Player.GettingAttacked(ThisIsAnAttack);
        Debug.Log("Computer Hit Player for" + ThisIsAnAttack);
        state = IDLE;
        Player.state = Player.IDLE_PICK;
    }
    public static void TakeDamage(int damage)
    {
        cpuhealth -= damage;
    }

    void Update()
    {
        switch (Player.state)
        {
            case Player.HAS_PICKED:
                PickComputer();
                break;
        }
        switch (state)
        {
            case ATTACK:
                Attacking();
                break;

        }
        if (cpuhealth <= 0)
        {
            state = DEATH;
        }
    
    }

    void OnGUI()
    {
        //Debug.Log("OnGUI in ComputerAI Sanity Check");
        string cpuState = state == IDLE ? "IDLE" :
                          state == ATTACK ? "ATTACK" :
                          state == PICK ? "PICK" :
                          state == HAS_PICKED ? "HAS_PICKED" :
                          state == GETTING_ATTACKED ? "GETTING_ATTACKED" :
                          "IDFK";
        GUI.Label(new Rect(10, 10, 500, 20), "Computer State: " + cpuState);
        GUI.Label(new Rect(500, 10, 200, 20), "Computer's Health:" + cpuhealth);

        switch (state)
        {
            case DEATH:
                Dying();
                break;

        }

    }


}
