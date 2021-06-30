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
        gm.ResetGamePlay();
        sc.UnloadSceneAsy("Landed");
    }

    public void GoToMenu()
    {
        sc.ChangeScene("MainMenu");
    }

}
