using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public string SampleScene;
    public void LoadScene()
    {
         SceneManager.LoadScene(SampleScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
