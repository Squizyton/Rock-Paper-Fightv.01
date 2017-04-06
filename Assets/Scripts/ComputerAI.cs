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
    public float cpuhealth = 20;
    public static bool Dontpickagain = false;
    public static bool PickAgain = false;
    public float RandomGenerator = 0;
    public static bool ComputerGotHit = false;


    const int IDLE = 0;
    const int ATTACK = 1;
    const int PICK = 2;

    public int state = IDLE;

    void Start()
    {
    }
    void Update()
    {

        if (PickAgain == true)
        {
            RandomPicker = Random.Range(1, 4);
            PickAgain = false;
        }

        if (Player.PlayerIsReady == true)
        {

            RandomPicker = Random.Range(1, 4);
            if (RandomPicker == 1)
            {
                CpuRock = true;
                CPUisReady = true;
                CpuCanPick = false;
                Dontpickagain = true;
            }
            if (RandomPicker == 2)
            {
                CpuPaper = true;
                CPUisReady = true;
                CpuCanPick = false;
                Dontpickagain = true;
            }
            if (RandomPicker == 3)
            {
                CpuScizzors = true;
                CPUisReady = true;
                CpuCanPick = false;
                Dontpickagain = true;
            }
        }
        if (ComputerWon == true)
        {
            if (Player.CanPick == false)
            {
                //This is the Computer AI battle System
                //It will first check it's own health. If it then generate a random number sytem if its below a certain point
                //of health. Then it will throw some dice. And If the dice equal a certain amount. It will heal.
                if (cpuhealth <= 13)

                    RandomGenerator = Random.Range(1, 20);

                if (RandomGenerator >= 14)
                {
                    cpuhealth += Random.Range(1, 5);
                    Player.CanPick = true;
                    ComputerWon = false;
                }
                if (cpuhealth >= 0)
                {
                    AttackHitterThing = Random.Range(1, 5);
                    Player.PlayerGotHit = true;
                    Debug.Log("The Computer hit the player foooorr " + AttackHitterThing);
                    AttackHitterThing = 0;
                    ComputerWon = false;
                    Player.CanPick = true;
                    Player.PlayerIsReady = false;

                }
            }
            if (ComputerGotHit == true)
            {
                cpuhealth -= Player.AttackRandomNumber;
                ComputerGotHit = false;
            }
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(500, 10, 100, 20), "Computer's Health:" + cpuhealth);
    }


}
