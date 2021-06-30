using System;
using UnityEngine;

public class UICrash : MonoBehaviour
{
    public static event Action RespawnPlayer;

    private ScenesManager sc;
    private GameManager gm;
    private void Start()
    {
        sc = ScenesManager.instanceScenesManager;
        gm = GameManager.instanceGameManager;
    }

    public void ContinueToLevel()
    {
        sc.UnloadSceneAsy("Crash");
        Time.timeScale = 1;
        RespawnPlayer?.Invoke();
    }
}
