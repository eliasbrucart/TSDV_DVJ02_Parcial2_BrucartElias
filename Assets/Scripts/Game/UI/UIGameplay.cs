using TMPro;
using UnityEngine;

public class UIGameplay : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public TMP_Text fuelText;
    public TMP_Text altitudeText;
    public TMP_Text verticalSpeedText;
    public TMP_Text horizontalSpeedText;

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
