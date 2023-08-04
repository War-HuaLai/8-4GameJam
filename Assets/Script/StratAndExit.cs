using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StratAndExit : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void GameStart()
    {
        SceneManager.LoadScene("Level1");
    }
}
