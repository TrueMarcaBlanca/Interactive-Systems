using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text sheepSavedText;
    public Text sheepDroppedText;
    public GameObject gameOverWindow;

    private int trueSheepDropped;

    void Awake()
    {
        Instance = this;

        sheepDroppedText.text = GameStateManager.Instance.sheepDroppedBeforeGameOver.ToString();
    }

    public void UpdateSheepSaved()
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped()
    {
        trueSheepDropped = GameStateManager.Instance.sheepDroppedBeforeGameOver - GameStateManager.Instance.sheepDropped/2;
        sheepDroppedText.text = trueSheepDropped.ToString();
    }

    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }


}
