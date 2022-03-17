using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
   
    public SceneFader sceneFader;
    public string mainMenu = "MainMenu";

    public AudioClip endSound;
    public AudioSource playAudio;

   

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);

    }

    public void Menu()
    {
        sceneFader.FadeTo(mainMenu);
    }
    // Start is called before the first frame update
    void Start()
    {
        playAudio = GetComponent<AudioSource>();
    }
}
