using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsSele : MonoBehaviour
{
    public SceneFader fader;
    public Button[] levelButton;

    public AudioClip SelecLevel;
    public AudioSource playAudio;

    public void SelectLevel(string levelname)
    {
        playAudio.PlayOneShot(SelecLevel, 1.0f);
        fader.FadeTo(levelname);
    }
    // Start is called before the first frame update
    void Start()
    {
        playAudio = GetComponent<AudioSource>();
        int levelReached = PlayerPrefs.GetInt("levelReached", 2);
        for (int i = 0; i < levelButton.Length; i++) 
        {
            if (i+1 > levelReached)
            {
                levelButton[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
