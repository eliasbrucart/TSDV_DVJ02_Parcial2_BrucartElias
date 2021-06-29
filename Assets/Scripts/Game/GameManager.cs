using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instanceGameManager;

    public static GameManager Instance { get { return instanceGameManager; } }

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
    }

    private void CheckGameOver()
    {
        ScenesManager.instanceScenesManager.ChangeScene("GameOver");
    }

    private void OnDisable()
    {
        Player.PlayerDie -= CheckGameOver;
    }
}
