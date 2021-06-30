using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    private GameManager gm;
    private ScenesManager sc;
    void Start()
    {
        gm = GameManager.instanceGameManager;
        sc = ScenesManager.instanceScenesManager;
    }

    public void PlayAgain()
    {
        sc.UnloadSceneAsy("GameOver");
        gm.ResetGamePlay();
        Time.timeScale = 1;
    }

    public void MainMenuBtn()
    {
        sc.UnloadSceneAsy("GameOver");
        sc.ChangeScene("MainMenu");
        Time.timeScale = 1;
    }

    public void QuitBtn()
    {
        sc.OnClickQuit();
    }
}
