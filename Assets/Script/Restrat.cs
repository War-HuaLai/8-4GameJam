using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restrat : MonoBehaviour
{
    public GameObject WinnerPlane;
    public GameObject ScorePlane;
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
        AudioManger.Instance.PlaySFX("");
    }
    public void GameReStart()
    {
        SceneManager.LoadScene("Open");
    }
}
