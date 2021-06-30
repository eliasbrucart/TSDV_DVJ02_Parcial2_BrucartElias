using TMPro;
using UnityEngine;

public class UIHighScore : MonoBehaviour
{
    private GameManager gm;
    public TMP_Text newScore;
    int score;
    int highscore;
    public struct Highscore
    {
        public int Score;
    }
    Highscore h = new Highscore();
    void Start()
    {
        gm = GameManager.instanceGameManager;
        score = gm.score;
        SaveManager.Load(ref h.Score);
        highscore = h.Score;
    }

    void Update()
    {
        newScore.text = "High Score: " + highscore.ToString();
        //currentHighscore.text = "Highscore: " + highscore.ToString() + " by " + highscoreName;
    }
}
