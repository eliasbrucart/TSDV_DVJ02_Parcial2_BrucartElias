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

    private GameManager gm;
    private ScenesManager sc;

    void Start()
    {
        gm = GameManager.instanceGameManager;
        sc = ScenesManager.instanceScenesManager;
    }

    void Update()
    {
        scoreText.text = "Score: " + gm.score;
        timeText.text = "Time: " + gm.timer.ToString("F2");
        fuelText.text = "Fuel: " + player.GetFuel().ToString("F2");
        altitudeText.text = "Altitude: " + player.GetAltitude().ToString("F2");
        verticalSpeedText.text = "Vertial Speed: " + Mathf.Abs(player.GetRB().velocity.y).ToString("F2");
        horizontalSpeedText.text = "Horizontal Speed: " + Mathf.Abs(player.GetRB().velocity.x).ToString("F2");
    }

    public void PauseGame()
    {
        if(Time.timeScale == 1)
        {
            sc.ChangeSceneAdditive("Pause");
            Time.timeScale = 0;
        }
    }

}
