using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.UI;
using System.IO;

public class SaveScore : MonoBehaviour
{
    public SaveJSON sv;

    public Text ScoreTag;
    //public TextMeshProUGUI ScoreTag;

    public string playerName;
    int score;
    void Start()
    {
        sv = this.GetComponent<SaveJSON>();
        //int.TryParse(ScoreTag.text, out score);
        //string ts = ScoreTag.text;
        
        
        
        
    }

    public void saveData(){
        score = ShootTarget.getScoreSaved();
        playerName = Usuario.getPlayerName();
        
        Debug.Log("TS: "+score);
        Score newData = new Score();
        newData.score = score;
        newData.player = Usuario.playerName;
        newData.date = System.DateTime.Now.ToShortDateString().ToString();

        sv.saveJSON(newData);
    }

    
}

