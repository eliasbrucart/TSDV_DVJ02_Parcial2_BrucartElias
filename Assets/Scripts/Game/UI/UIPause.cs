using UnityEngine;

public class UIPause : MonoBehaviour
{
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        ScenesManager.instanceScenesManager.UnloadSceneAsy("Pause");
    }
}
