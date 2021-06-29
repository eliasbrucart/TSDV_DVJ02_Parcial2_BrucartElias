using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels = new List<GameObject>();
    int choice = 0;

    private void Start()
    {
        ChoiceLevel();
    }

    public void ChoiceLevel()
    {
        levels[0].SetActive(false);
        levels[1].SetActive(false);
        levels[2].SetActive(false);
        choice = Random.Range(0,3);
        if (choice == 3)
            choice = 2;
        levels[choice].SetActive(true);
    }
}
