using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restrat : MonoBehaviour
{
    public GameObject WinnerPlane;
    public GameObject ScorePlane;

    public ScrollWheel scroll;

    

    void Start()
    {
        WinnerPlane.SetActive(false);
        ScorePlane.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WinnerPlane.SetActive(true);
        GameManager.Instance.GameOver();

        PauseAndCloseInput();
        AudioManger.Instance.PlaySFX("win");
    }

    public void OpenRank()
    {
        ScorePlane.SetActive(true);
        AudioManger.Instance.PlaySFX("open");
        GameManager.Instance.UpdateLeaderboard();
        PauseAndCloseInput();
    }

    public void CloseRank()
    {
        ScorePlane.SetActive(false);
        GameManager.Instance.CloseTimeUI();
        //ContinueAndStartInput();
    }

    public void PauseAndCloseInput()
    {
        Time.timeScale = 0f;
        scroll.InputStop();
    }

    public void ContinueAndStartInput()
    {
        Time.timeScale = 1f;
        scroll.InputStart();
    }

    public void GameReStart()
    {
        ContinueAndStartInput();
        SceneManager.LoadScene("Open");
    }
}
