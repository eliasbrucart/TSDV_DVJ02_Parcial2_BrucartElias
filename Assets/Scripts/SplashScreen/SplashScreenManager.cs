using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameSplash;
    [SerializeField] private CanvasGroup companySplash;
    [SerializeField] private float maxTime = 2.0f;
    private float timer;
    private ScenesManager sm;
    void Start()
    {
        gameSplash.alpha = 0;
        companySplash.alpha = 0;
        StartCoroutine(Splash());
        sm = ScenesManager.instanceScenesManager;
    }

    IEnumerator Splash()
    {
        while (timer < maxTime)
        {
            SetAlpha1(companySplash);
            yield return null;
        }
        timer = 0;
        yield return new WaitForSeconds(0.5f);

        while (timer < maxTime)
        {
            SetAlpha0(companySplash);
            yield return null;
        }
        timer = 0;
        yield return new WaitForSeconds(0.1f);

        while (timer < maxTime)
        {
            SetAlpha1(gameSplash);
            yield return null;
        }
        timer = 0;
        yield return new WaitForSeconds(0.5f);

        while (timer < maxTime)
        {
            SetAlpha0(gameSplash);
            yield return null;
        }
        timer = 0;
        LoadMainMenu();
    }
    
    private void LoadMainMenu()
    {
        sm.ChangeScene("MainMenu");
    }

    private void SetAlpha1(CanvasGroup canvasG)
    {
        timer += Time.deltaTime;
        canvasG.alpha = Mathf.Lerp(0, 1, timer);
    }

    private void SetAlpha0(CanvasGroup canvasG)
    {
        timer += Time.deltaTime;
        canvasG.alpha = Mathf.Lerp(1, 0, timer);
    }


}
