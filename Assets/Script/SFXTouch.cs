using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTouch : MonoBehaviour
{
    public string SfxName;
    private float lastTime = 0f;
    public float TriggierTime = 20f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time - lastTime > TriggierTime)
        {
            //Debug.Log("Play Audio");
            AudioManger.Instance.PlaySFX(SfxName);
        }
        lastTime = Time.time;
    }
}
