using TMPro;
using UnityEngine;

public class UILanded : MonoBehaviour
{
    public TMP_Text scoreText;
    private GameManager gm;
    private ScenesManager sc;
    void Start()
    {
        gm = GameManager.instanceGameManager;
        sc = ScenesManager.instanceScenesManager;
    }

    void Update()
    {
        scoreText.text = "Score: " + gm.score;
    }

    public void PlayAgainBtn()
    {
        Time.timeScale = 1;
        sc.UnloadSceneAsy("Landed");
        gm.ResetGamePlay();
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        gm.ResetTimer();
        sc.ChangeScene("MainMenu");
    }

}
