using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShowScores : MonoBehaviour
{

    public TextMeshProUGUI name1;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI date1;

    public TextMeshProUGUI name2;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI date2;

    public TextMeshProUGUI name3;
    public TextMeshProUGUI score3;
    public TextMeshProUGUI date3;

    public TextMeshProUGUI name4;
    public TextMeshProUGUI score4;
    public TextMeshProUGUI date4;

    public TextMeshProUGUI name5;
    public TextMeshProUGUI score5;
    public TextMeshProUGUI date5;

    public TextMeshProUGUI name6;
    public TextMeshProUGUI score6;
    public TextMeshProUGUI date6;

    public TextMeshProUGUI name7;
    public TextMeshProUGUI score7;
    public TextMeshProUGUI date7;

    List<TextMeshProUGUI> nombres;

    List<TextMeshProUGUI> scoresText;

    List<TextMeshProUGUI> dates;


    void Start()
    {
        nombres = new List<TextMeshProUGUI>();
        scoresText = new List<TextMeshProUGUI>();
        dates = new List<TextMeshProUGUI>();

        nombres.Add(name1);
        nombres.Add(name2);
        nombres.Add(name3);
        nombres.Add(name4);
        nombres.Add(name5);
        nombres.Add(name6);
        nombres.Add(name7);

        scoresText.Add(score1);
        scoresText.Add(score2);
        scoresText.Add(score3);
        scoresText.Add(score4);
        scoresText.Add(score5);
        scoresText.Add(score6);
        scoresText.Add(score7);

        dates.Add(date1);
        dates.Add(date2);
        dates.Add(date3);
        dates.Add(date4);
        dates.Add(date5);
        dates.Add(date6);
        dates.Add(date7);


        //Carga de Scores
        List<Score> scores = SaveJSON.ObtenerListaScores<Score>();

        if (scores != null)
        {
            Debug.Log("Score Before: " + scores.Count());
            scores.Sort((x, y) => y.score.CompareTo(x.score));
            for (int i = 0; i <= 6; i++)
            {

                bool isNull = false;
                //Si el score existe
                try
                {
                    isNull = scores.ElementAt(i).player == null;
                }
                catch (Exception e)
                {
                    isNull = true;
                }
                //Debug.Log("Prueba NULL: "+ scores.ElementAt(i).player);
                if (!isNull)
                {

                    if (scores.ElementAt(i).player.CompareTo("") == 0)
                    {
                        nombres.ElementAt(i).text = "Guest";
                    }
                    else {
                        nombres.ElementAt(i).text = scores.ElementAt(i).player;
                    }
                    scoresText.ElementAt(i).text = scores.ElementAt(i).score.ToString();
                    dates.ElementAt(i).text = scores.ElementAt(i).date;
                }
                else
                {
                    nombres.ElementAt(i).text = "-";
                    scoresText.ElementAt(i).text = "-";
                    dates.ElementAt(i).text = "-";
                }

            }
        }
        else
        {
            for (int i = 0; i <= 6; i++)
            {
                nombres.ElementAt(i).text = "-";
                scoresText.ElementAt(i).text = "-";
                dates.ElementAt(i).text = "-";
            }
        }

    }

}

