using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instanceGameManager;

    public static GameManager Instance { get { return instanceGameManager; } }

    public int scoreLanded;
    public int scoreLanded2;
    public int scoreLanded4;
    public int scoreLanded5;

    private int score;

    private void Awake()
    {
        if (instanceGameManager != this && instanceGameManager != null)
            Destroy(this.gameObject);
        else
            instanceGameManager = this;
    }
    void Start()
    {
        Player.PlayerDie += CheckGameOver;
        Player.PlayerLanded += Landed;
    }

    private void Landed()
    {
        score += scoreLanded;
        ScenesManager.instanceScenesManager.ChangeScene("Landed");
    }

    private void CheckGameOver()
    {
        ScenesManager.instanceScenesManager.ChangeScene("GameOver");
    }

    private void OnDisable()
    {
        Player.PlayerDie -= CheckGameOver;
        Player.PlayerLanded -= Landed;
    }
}
