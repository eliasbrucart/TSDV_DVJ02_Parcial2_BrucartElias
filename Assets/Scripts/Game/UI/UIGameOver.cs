using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayAgain()
    {
        ScenesManager.instanceScenesManager.UnloadSceneAsy("GameOver");
        GameManager.instanceGameManager.ResetGamePlay();
        Time.timeScale = 1;
    }

    public void MainMenuBtn()
    {
        ScenesManager.instanceScenesManager.UnloadSceneAsy("GameOver");
        ScenesManager.instanceScenesManager.ChangeScene("MainMenu");
        Time.timeScale = 1;
    }

    public void QuitBtn()
    {
        ScenesManager.instanceScenesManager.OnClickQuit();
    }
}
