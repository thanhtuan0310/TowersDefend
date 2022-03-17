using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGames : MonoBehaviour
{
    public GameObject main, option;
    public string levelToLoad = "MainMenu";

    public SceneFader scenefader;
    public void Play()
    {
        FindObjectOfType<SceneFader>().FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void Option()
    {
        main.SetActive(false);
        option.SetActive(true);
    }

    public void NgonNgu()
    {
        scenefader.FadeTo("Language");
    }
    public void BacktoMenu()
    {
        main.SetActive(true);
        option.SetActive(false);
    }
}
