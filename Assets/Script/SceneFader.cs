using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;
     

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while(t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, t);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, t);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
