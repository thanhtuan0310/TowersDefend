using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGames : MonoBehaviour
{
    public static bool gameEnded;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    // Start is called before the first frame update
    void Start()
    {
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
        {
            return;
        }
        if(PlayerStarts.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
        Debug.Log("Game Over!");
    }

    public void WinLevel()
    {
        gameEnded = true;
        completeLevelUI.SetActive(true); 
    }
}
