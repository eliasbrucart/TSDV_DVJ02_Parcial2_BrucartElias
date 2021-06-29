using TMPro;
using UnityEngine;

public class UILanded : MonoBehaviour
{
    public TMP_Text scoreText;
    void Start()
    {
        
    }

    void Update()
    {
        scoreText.text = "Score: " + GameManager.instanceGameManager.score;
    }

    public void PlayAgainBtn()
    {
        Time.timeScale = 1;
        GameManager.instanceGameManager.ResetGamePlay();
        ScenesManager.instanceScenesManager.UnloadSceneAsy("Landed");
    }

}
