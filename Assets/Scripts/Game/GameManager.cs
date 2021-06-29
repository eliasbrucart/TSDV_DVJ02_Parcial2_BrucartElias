using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instanceGameManager;

    public static GameManager Instance { get { return instanceGameManager; } }

    public int scoreLanded;
    public int scoreLanded2;
    public int scoreLanded4;
    public int scoreLanded5;

    private float timer;
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
        Player.PlayerLanded2 += Landed2;
        Player.PlayerLanded4 += Landed4;
        Player.PlayerLanded5 += Landed5;
    }

    private void Landed()
    {
        score += scoreLanded;
        ScenesManager.instanceScenesManager.ChangeScene("Landed");
    }

    private void Landed2()
    {
        score += scoreLanded2;
        Debug.Log("Landed2");
        ScenesManager.instanceScenesManager.ChangeScene("Landed");
    }

    private void Landed4()
    {
        score += scoreLanded4;
        Debug.Log("Landed4");
        ScenesManager.instanceScenesManager.ChangeScene("Landed");
    }

    private void Landed5()
    {
        score += scoreLanded5;
        Debug.Log("Landed5");
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
        Player.PlayerLanded2 -= Landed2;
        Player.PlayerLanded4 -= Landed4;
        Player.PlayerLanded5 -= Landed5;
    }
}
