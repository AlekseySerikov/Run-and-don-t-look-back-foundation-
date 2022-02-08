using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIRestart : MonoBehaviour
{
    private void Start()
    {
    }

    public void MenuBack()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
 public void ExitGame()
    {
        Application.Quit();
    }
}
