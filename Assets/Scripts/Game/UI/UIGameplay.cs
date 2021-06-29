using UnityEngine;

public class UIGameplay : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PauseGame()
    {
        if(Time.timeScale == 1)
        {
            ScenesManager.instanceScenesManager.ChangeSceneAdditive("Pause");
            Time.timeScale = 0;
        }
    }

}
