using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying_Script : MonoBehaviour
{

    //This script will keep track of Health. Simple script.

    public Texture PlayerDeathText;


    int Death = 0;
    const int PlayerDeath = 1;
    const int Computer_Death = 2;

    void PlayerDying()
    {
        //    GUI.DrawTexture(new Rect(10, 10, 60, 60), PlayerDeathText);
    }



    void onGUI()
    {

        if (Player.PlayerHealth <= 0)
        {
            Player.state = Player.DEATH;
            Death = PlayerDeath;
        }
        if (ComputerAI.cpuhealth <= 0)
        {
            ComputerAI.state = ComputerAI.DEATH;
            Death = Computer_Death;
        }
        switch (Death)
        {

            case PlayerDeath:
                PlayerDying();
                break;
        }
    }
}
