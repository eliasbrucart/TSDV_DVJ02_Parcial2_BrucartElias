using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instanceGameManager;

    public static GameManager Instance { get { return instanceGameManager; } }

    public int scoreLanded;
    public int scoreLanded2;
    public int scoreLanded4;
    public int scoreLanded5;
    public LevelManager lm;
    public Player player;

    public float timer;
    public int score { get; set; }

    private ScenesManager sc;

    private void Awake()
    {
        if (instanceGameManager != this && instanceGameManager != null)
            Destroy(this.gameObject);
        else
            instanceGameManager = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Player.PlayerDie += CheckPlayerDie;
        Player.PlayerLanded += Landed;
        Player.PlayerLanded2 += Landed2;
        Player.PlayerLanded4 += Landed4;
        Player.PlayerLanded5 += Landed5;
        Player.outOfFuel += OutOfFuel;
        sc = ScenesManager.instanceScenesManager;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void Landed()
    {
        score += scoreLanded;
        Time.timeScale = 0;
        sc.ChangeSceneAdditive("Landed");
    }

    private void Landed2()
    {
        score += scoreLanded2;
        Time.timeScale = 0;
        sc.ChangeSceneAdditive("Landed");
    }

    private void Landed4()
    {
        score += scoreLanded4;
        Time.timeScale = 0;
        sc.ChangeSceneAdditive("Landed");
    }

    private void Landed5()
    {
        score += scoreLanded5;
        Time.timeScale = 0;
        sc.ChangeSceneAdditive("Landed");
    }

    private void CheckPlayerDie()
    {
        sc.ChangeSceneAdditive("Crash");
        Time.timeScale = 0;
    }

    private void OutOfFuel()
    {
        sc.ChangeSceneAdditive("GameOver");
        Time.timeScale = 0;
    }

    public void ResetGamePlay()
    {
        lm.ChoiceLevel();
        timer = 0.0f;
        score = 0;
        player.Respawn();
    }

    private void OnDisable()
    {
        Player.PlayerDie -= CheckPlayerDie;
        Player.PlayerLanded -= Landed;
        Player.PlayerLanded2 -= Landed2;
        Player.PlayerLanded4 -= Landed4;
        Player.PlayerLanded5 -= Landed5;
        Player.outOfFuel -= OutOfFuel;
    }
}
