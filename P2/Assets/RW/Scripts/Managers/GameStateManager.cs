using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    [HideInInspector]
    public int sheepSaved;

    [HideInInspector]
    public int sheepDropped;

    public int sheepDroppedBeforeGameOver;
    public SheepSpawner sheepSpawner;

    private bool IsGameOver;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
    {
        SceneManager.LoadScene("Title");

    }
    if (Input.GetKeyDown(KeyCode.Return) && IsGameOver == true)
    {
        SceneManager.LoadScene("Game");

    }
    }

    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();

    }

    private void GameOver()
    {
        sheepSpawner.canSpawn = false;
        sheepSpawner.DestroyAllSheep();
        IsGameOver = true;

        UIManager.Instance.ShowGameOverWindow();

    }

    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateSheepDropped();
        if (sheepDropped/2 == sheepDroppedBeforeGameOver)
        {
            GameOver();
        }
    }
    
}
