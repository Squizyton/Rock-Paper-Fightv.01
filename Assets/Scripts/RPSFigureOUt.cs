using UnityEngine;
using System.Collections;

public class RPSFigureOUt : MonoBehaviour
{
    void Update()
    {

        if (Player.state == Player.HAS_PICKED && ComputerAI.state == ComputerAI.HAS_PICKED)

        {
            int p = Player.currentPick;
            int c = ComputerAI.currentPick;
            int pr = Player.PICK_ROCK;
            int pp = Player.PICK_PAPER;
            int ps = Player.PICK_SCISSORS;
            int cr = ComputerAI.PICK_ROCK;
            int cp = ComputerAI.PICK_PAPER;
            int cs = ComputerAI.PICK_SCISSORS;
            int playerWon = 0;
            int computerWon = 1;
            int tie = 2;

            int result =
                p == pr ?
                    c == cr ? tie :
                    (c == cp ? computerWon : playerWon) :
                p == pp ?
                    c == cr ? playerWon :
                    (c == cp ? tie : computerWon) :
                c == cr ? computerWon :
                    (c == cp ? playerWon : tie);
                 

        }
                //if (Player.PlayerRock == true && ComputerAI.CpuScizzors == true)
                //{
                //    Player.PlayerCanFight = true;
                //    Player.PlayerIsReady = false;
                //    ComputerAI.CPUisReady = false;
                //}
                //if (Player.PlayerScizzors == true && ComputerAI.CpuPaper == true)
                //{
                //    Player.PlayerCanFight = true;
                //    Player.PlayerIsReady = false;
                //    ComputerAI.CPUisReady = false;
                //}
                //if (Player.PlayerPaper == true && ComputerAI.CpuRock == true)
                //{
                //    Player.PlayerCanFight = true;
                //    Player.PlayerIsReady = false;
                //    ComputerAI.CPUisReady = false;
                //}
                //if (Player.PlayerPaper == true && ComputerAI.CpuScizzors == true)
                //{
                //    ComputerAI.ComputerWon = true;
                //    Player.PlayerIsReady = false;
                //    ComputerAI.CPUisReady = false;


            //}
            //if (Player.PlayerScizzors == true && ComputerAI.CpuRock == true)
            //{
            //    ComputerAI.ComputerWon = true;
            //    Player.PlayerIsReady = false;
            //    ComputerAI.CPUisReady = false;

            //}
            //if (Player.PlayerRock == true && ComputerAI.CpuPaper == true)
            //{
            //    ComputerAI.ComputerWon = true;
            //    Player.PlayerIsReady = false;
            //    ComputerAI.CPUisReady = false;
            //}

            //if (Player.PlayerScizzors == true && ComputerAI.CpuScizzors == true)
            //{
            //    Player.CanPick = true;
            //    ComputerAI.PickAgain = true;
            //    Player.PlayerIsReady = false;
            //    ComputerAI.CPUisReady = false;

            //}
            //if (Player.PlayerPaper == true && ComputerAI.CpuPaper == true)
            //{
            //    Player.CanPick = true;
            //    ComputerAI.PickAgain = true;
            //    Player.PlayerIsReady = false;
            //    ComputerAI.CPUisReady = false;
            //}
            //if (Player.PlayerRock == true && ComputerAI.CpuRock == true)
            //{
            //    Player.CanPick = true;
            //    ComputerAI.PickAgain = true;
            //    Player.PlayerIsReady = false;
            //    ComputerAI.CPUisReady = false;
            //}









    }
}
