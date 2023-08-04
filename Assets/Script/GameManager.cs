using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get;private set;}

    [SerializeField] private TextMeshProUGUI _textTimer;
    int timer;
    public int finalScore ;
    private List<int> scores = new List<int>();

    private void AddScore(int newScore)
    {
        scores.Add(newScore);
        UpdateLeaderboard();
    }
    void UpdateLeaderboard()
    {
        scores.Sort((a, b) => b.CompareTo(a));

        string leaderboardText = "Leaderboard:\n";
        int count = Mathf.Min(scores.Count, 10); 

        for (int i = 0; i < count; i++)
        {
            leaderboardText += $"{i + 1}. {scores[i]}\n";
        }

        _textTimer.text = leaderboardText;
    }

    private void Awake() {
        if(!Instance){
            Instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }

    private void Start() {
       StartCoroutine(Timer());
    }
    public void GameOver()
    {
         finalScore = timer;
        AddScore(finalScore);
    }
    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            timer+=1;
            if(timer<10){
                _textTimer.text = "0:0" + timer.ToString();
            }
            if(timer>=10 && timer<60){
                _textTimer.text = "0:" + timer.ToString();
            }else
            {
                int lastDigit = timer/60;
                int lastDigit2 = timer - 60*lastDigit;
                if(lastDigit2<10){
                    _textTimer.text = (lastDigit).ToString() +":0" + (lastDigit2).ToString();
                }else
                {
                       _textTimer.text = (lastDigit).ToString() +":" + (lastDigit2).ToString();
                }
            }
        }
    }

}
