using System;
using UnityEngine;

public class UICrash : MonoBehaviour
{
    public static event Action RespawnPlayer;
    public void ContinueToLevel()
    {
        ScenesManager.instanceScenesManager.UnloadSceneAsy("Crash");
        Time.timeScale = 1;
        RespawnPlayer?.Invoke();
    }
}
