[System.Serializable]

public class Score
{
    public int score;
    public string player;
    public string date;

    public string toString(){
        string aux = "Score: "+score+" Player: "+player+" Date: "+date;
        return aux;
    }
}
