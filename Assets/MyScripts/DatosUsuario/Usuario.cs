using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usuario : MonoBehaviour
{
    public static string playerName;
    //string score;
    //string date;

    public static void setPlayerName(string player){
        playerName = player;
    }

    public static string getPlayerName(){
        return playerName;
    }
}
