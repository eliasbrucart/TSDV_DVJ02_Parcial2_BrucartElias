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
        ScenesManager.instanceScenesManager.ChangeSceneAdditive("Pause");
    }

}
