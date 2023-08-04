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
