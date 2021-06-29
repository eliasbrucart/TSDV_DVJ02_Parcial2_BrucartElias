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

    public Player player;

    void Start()
    {
        
    }

    void Update()
    {
        scoreText.text = "Score: " + GameManager.instanceGameManager.score;
        timeText.text = "Time: " + GameManager.instanceGameManager.timer.ToString("F2");
        fuelText.text = "Fuel: " + player.GetFuel().ToString("F2");
        altitudeText.text = "Altitude: " + player.GetAltitude().ToString("F2");
        verticalSpeedText.text = "Vertial Speed: " + Mathf.Abs(player.GetRB().velocity.y).ToString("F2");
        horizontalSpeedText.text = "Horizontal Speed: " + Mathf.Abs(player.GetRB().velocity.x).ToString("F2");
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
