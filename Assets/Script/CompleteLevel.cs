﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;

    public string nextLevel = "Level2";
    public int levelToUnclock = 2;

    public string menuSceneName = "MainMenu";

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnclock);
        sceneFader.FadeTo(nextLevel);
    }
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
    
}
