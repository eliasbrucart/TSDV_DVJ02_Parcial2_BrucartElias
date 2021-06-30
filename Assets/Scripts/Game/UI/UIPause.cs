using UnityEngine;

public class UIPause : MonoBehaviour
{
    public ScenesManager sc;

    private void Start()
    {
        sc = ScenesManager.instanceScenesManager;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        sc.UnloadSceneAsy("Pause");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        sc.ChangeScene("MainMenu");
    }
}
