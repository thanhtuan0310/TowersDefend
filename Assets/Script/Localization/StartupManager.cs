using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour
{
    public SceneFader scenefader;
    
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        while (!LocalizationManager.instance.GetIsReady())
        {
            yield return null;
        }

        scenefader.FadeTo("MainMenu");
       
    }

}
